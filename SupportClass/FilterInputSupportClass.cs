using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.SupportClass
{
    class FilterInputSupportClass
    {


        public bool ContainsSimilarSubstring(string text, string query, int threshold = 0)
        {
            int len1 = query.Length;
            int len2 = text.Length;

            if (len1 > len2) return false; // Query can't be longer than text

            for (int i = 0; i <= len2 - len1; i++)
            {
                string substring = text.Substring(i, len1);
                if (ComputeLevenshtein(query, substring) <= threshold)
                    return true; // Found a similar match
            }

            return false;
        }

        public bool LevenshteinDistance(string s1, string s2, int threshold = 2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;

            if (len1 > len2) return false; // s1 can't be more similar if it's longer

            for (int i = 0; i <= len2 - len1; i++)
            {
                string substring = s2.Substring(i, len1);
                if (ComputeLevenshtein(s1, substring) <= threshold)
                    return true; // Found a similar match
            }

            return false;
        }

        private int ComputeLevenshtein(string s1, string s2)
        {
            int len1 = s1.Length;
            int len2 = s2.Length;
            int[,] dp = new int[len1 + 1, len2 + 1];

            for (int i = 0; i <= len1; i++)
                dp[i, 0] = i;
            for (int j = 0; j <= len2; j++)
                dp[0, j] = j;

            for (int i = 1; i <= len1; i++)
            {
                for (int j = 1; j <= len2; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j] + 1, dp[i, j - 1] + 1), dp[i - 1, j - 1] + cost);
                }
            }
            return dp[len1, len2];
        }


        public void ValidateNumericInput(TextBox textBox)
        {
            if (textBox == null) return;

            string input = textBox.Text;
            string filteredInput = "";
            bool decimalFound = false;

            foreach (char c in input)
            {
                if (char.IsDigit(c))
                {
                    filteredInput += c;
                }
                else if (c == '.' && !decimalFound)
                {
                    filteredInput += c;
                    decimalFound = true;
                }
            }
            if (filteredInput.Length > 1 && filteredInput[0] == '0' && filteredInput[1] != '.')
            {
                filteredInput = filteredInput.Substring(1);
            }
            if (textBox.Text != filteredInput)
            {
                int cursorPosition = textBox.SelectionStart - (textBox.Text.Length - filteredInput.Length);
                textBox.Text = filteredInput;
                textBox.SelectionStart = Math.Max(0, cursorPosition);
            }
        }


        public void SanitizeSQLInput(TextBox textBox)
        {
            if (textBox == null) return;

            textBox.Text = RemoveSQLInjectionRisks(textBox.Text);
            textBox.SelectionStart = textBox.Text.Length;
        }
        public void SanitizeSQLInput(RichTextBox textBox)
        {
            if (textBox == null) return;

            textBox.Text = RemoveSQLInjectionRisks(textBox.Text);
            textBox.SelectionStart = textBox.Text.Length;
        }

        public void SanitizeSQLInput(ComboBox comboBox)
        {
            if (comboBox == null) return;

            string sanitizedText = RemoveSQLInjectionRisks(comboBox.Text);
            if (comboBox.Text != sanitizedText)
            {
                comboBox.Text = sanitizedText;

                if (comboBox.Items.Contains(sanitizedText))
                {
                    comboBox.SelectedItem = sanitizedText;
                }
                else
                {
                    comboBox.SelectedIndex = -1; 
                }
            }
        }

        public string RemoveSQLInjectionRisks(string input)
        {
            if (string.IsNullOrWhiteSpace(input)) return input; // Preserve empty input

            // List of SQL keywords to remove if they appear as whole words
            string[] blacklistedWords = {
        "SELECT", "INSERT", "UPDATE", "DELETE", "DROP", "ALTER", "CREATE",
        "EXEC", "UNION", "GRANT", "REVOKE", "DECLARE", "CAST"
    };

            // Remove SQL keywords (preserve spaces)
            foreach (var word in blacklistedWords)
            {
                input = System.Text.RegularExpressions.Regex.Replace(input, $@"\b{word}\b", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }

            // Remove special characters used in SQL Injection attacks
            string[] blacklistedSymbols = { "--", ";", "/*", "*/", "@", "'" };
            foreach (var symbol in blacklistedSymbols)
            {
                input = input.Replace(symbol, ""); // Directly remove dangerous symbols
            }

            return System.Text.RegularExpressions.Regex.Replace(input, @"\s+", " ").Trim(); // Normalize spaces
        }


        public bool AreAllInputsFilled(params object[] controls)
        {
            foreach (var control in controls)
            {
                if (control is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text))
                    return false;
                if (control is ComboBox comboBox && string.IsNullOrWhiteSpace(comboBox.Text))
                    return false;
                if (control is RichTextBox richTextBox && string.IsNullOrWhiteSpace(richTextBox.Text))
                    return false;
            }
            return true;
        }
    }
}
