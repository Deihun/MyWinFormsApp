using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWinFormsApp.SupportClass
{
    class FilterInputSupportClass
    {

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

        private string RemoveSQLInjectionRisks(string input)
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
