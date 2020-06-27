namespace SqlFormatter
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    using Microsoft.Win32;

    public class Formatter
    {
        private const string KeyName = "Software\\alr\\SqlFormatter";
        private readonly Regex prefixInfoRegex = new Regex(@"^.+?\|NHibernate.SQL\|", RegexOptions.Compiled);
        private readonly Regex paramRegex = new Regex(@"(\:p\d+) = (.+?) \[Type\:.+?\]\,?\s?", RegexOptions.Compiled | RegexOptions.IgnoreCase);
        private readonly Regex dateRegex = new Regex(@"\d{2}\.\d{2}\.\d{4}(\s\d{2}:\d{2}:\d{2})?", RegexOptions.Compiled);

        public bool IsBeautify { get; set; }
        public bool UseClipboard { get; set; }

        public event EventHandler InitProgressBar = (sender, args) => { };

        public event EventHandler IncrementProgressBar = (sender, args) => { };

        public async Task<string> Convert(string inputText)
        {
            if (string.IsNullOrWhiteSpace(inputText))
            {
                return string.Empty;
            }

            return await Task.Run(() => this.ConvertInternal(inputText));
        }

        private string ConvertInternal(string inputText)
        {
            var sb = new StringBuilder(inputText);

            var matches = this.paramRegex.Matches(inputText).Cast<Match>().Reverse()
                .ToList();

            var firstParam = matches.LastOrDefault();
            if (firstParam?.Success ?? false)
            {
                sb.Remove(firstParam.Index, inputText.Length - firstParam.Index);
            }

            var prefixMatch = this.prefixInfoRegex.Match(inputText);
            if (prefixMatch.Success)
            {
                sb.Remove(0, prefixMatch.Index + prefixMatch.Length);
            }

            this.InitProgressBar(matches.Count, EventArgs.Empty);

            foreach (var match in matches)
            {
                if (match.Success)
                {
                    var group = match.Groups;
                    var paramName = group[1].Value;
                    var paramValue = group[2].Value;
                    var dateMatch = this.dateRegex.Match(paramValue);
                    if (dateMatch.Success)
                    {
                        paramValue = $"'{paramValue}'";
                    }

                    sb.Replace(paramName, paramValue);
                }

                this.IncrementProgressBar(match, EventArgs.Empty);
            }

            var outputText = sb.ToString().TrimEnd().TrimEnd('|');
            if (string.IsNullOrWhiteSpace(outputText))
            {
                return string.Empty;
            }

            return this.IsBeautify
                ? NSQLFormatter.Formatter.Format(outputText).Replace("\n", "\r\n")
                : outputText;
        }

        public void ReadConfig()
        {
            using (var subKey = Registry.CurrentUser.CreateSubKey(KeyName))
            {
                this.IsBeautify = this.GetBoolValue(subKey, nameof(this.IsBeautify), true);
                this.UseClipboard = this.GetBoolValue(subKey, nameof(this.UseClipboard), true);
            }
        }

        public void WriteConfig()
        {
            using (var subKey = Registry.CurrentUser.CreateSubKey(KeyName))
            {
                subKey.SetValue(nameof(this.IsBeautify), this.IsBeautify, RegistryValueKind.DWord);
                subKey.SetValue(nameof(this.UseClipboard), this.UseClipboard, RegistryValueKind.DWord);
            }
        }

        private bool GetBoolValue(RegistryKey key, string name, bool defaultValue)
        {
            var value = key.GetValue(name);
            if (value == null)
            {
                return defaultValue;
            }

            try
            {
                return System.Convert.ToBoolean(value);
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}