using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace CustomControls
{
    public class NumericTextBox : TextBox
    {
        public NumericTextBox()
        {
            this.PreviewTextInput += new TextCompositionEventHandler(NumericTextBox_PreviewTextInput);
        }

        void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!IsAllValidNumbers(e.Text))
                e.Handled = true;
            base.OnPreviewTextInput(e);
        }

        private bool IsAllValidNumbers(string p)
        {
            foreach (char c in p)
            {
                if (!char.IsNumber(c))
                    return false;
            }

            return true;
        }
    }
}
