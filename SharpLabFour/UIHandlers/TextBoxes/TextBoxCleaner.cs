using System.Collections.Generic;
using System.Windows.Controls;

namespace SharpLabFour.UIHandlers.TextBoxes
{
    public static class TextBoxCleaner
    {
        public static void CleanTextBox(TextBox textBox)
        {
            textBox.Text = string.Empty;
        }
        public static void CleanTextBoxes(params TextBox[] textBoxes)
        {
            foreach (TextBox textBox in textBoxes)
                textBox.Text = string.Empty;
        }
    }
}