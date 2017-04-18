using GUILanguageAgnosticIDE.Factories;
using GUILanguageAgnosticIDE.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUILanguageAgnosticIDE
{
    /// <summary>
    /// Interaction logic for MainGUIWindow.xaml
    /// </summary>
    public partial class MainGUIWindow : UserControl
    {
		public string CurrentLanguage { get; set; }
		public List<string> AvailableLanguages { get; set; }
		public List<string> AvailableElements
		{
			get
			{
				return FileOutputFactory.CreateAvailableElementList(CurrentLanguage);
			}
		}
		public OutputFactory FileOutputFactory { get; set; }
		public MainGUIWindow(OutputFactory outputFactory, List<string> availableLanguages)
        {
            InitializeComponent();
			FileOutputFactory = outputFactory;
			AvailableLanguages = availableLanguages;
        }

		public void RunGUI()
		{
			Output output = FileOutputFactory.CreateOutput(CurrentLanguage);
            output.AddElement("image", "https://crouton.net/crouton.png", 100, 100, 100, 100);
			output.CompileFile();
		}
    }
}
