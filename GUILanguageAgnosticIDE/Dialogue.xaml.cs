using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUILanguageAgnosticIDE
{
    /// <summary>
    /// Interaction logic for Dialogue.xaml
    /// </summary>
    public partial class Dialogue : Window
    {
        public Dialogue()
        {
			InitializeComponent();
			ResponseTextBox.GotFocus += TextBox_OnFocused;
			HeightTextBox.GotFocus += TextBox_OnFocused;
			WidthTextBox.GotFocus += TextBox_OnFocused;
		}

        public string ResponseText
        {
            get { return ResponseTextBox.Text; }
            set { ResponseTextBox.Text = value; }
        }
        public string HeightText
        {
            get { return HeightTextBox.Text; }
            set { HeightTextBox.Text = value; }
        }
        public string WidthText
        {
            get { return WidthTextBox.Text; }
            set { WidthTextBox.Text = value; }
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
			int isNumeric = 0;
			DialogResult = int.TryParse(HeightText, out isNumeric) && int.TryParse(WidthText, out isNumeric);
			if (!DialogResult.Value)
			{
				MessageBox.Show("Dimensions are invalid!");
			}
        }

		private void TextBox_OnFocused(object sender, RoutedEventArgs e)
		{
			TextBox box = (TextBox)e.Source;
			box.Text = string.Empty;
			box.GotFocus -= TextBox_OnFocused;
		}
    }
}
