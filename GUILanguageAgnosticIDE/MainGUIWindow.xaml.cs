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
        public List<Label> ElementsOnPage { get; set;}
		public List<string> AvailableElements
		{
			get
			{
				return FileOutputFactory.CreateAvailableElementList(CurrentLanguage);
			}
		}
		public List<AgnosticElement> Elements { get; set; }
		public OutputFactory FileOutputFactory { get; set; }
		public MainGUIWindow(OutputFactory outputFactory, List<string> availableLanguages)
        {
            InitializeComponent();
            FileOutputFactory = outputFactory;
            AvailableLanguages = availableLanguages;
			CurrentLanguage = AvailableLanguages[0];
            Setup();
        }

        private void Setup()
        {
            GuiCanvas.MouseDown += CanvasClickHandler;
            ElementDropDown.HorizontalContentAlignment = HorizontalAlignment.Center;
            ElementDropDown.SelectionChanged += LanguageChangeHandler;
            foreach (string languages in AvailableLanguages)
            {
                LangCombo.Items.Add(languages);
            }
                LangCombo.SelectedItem = LangCombo.Items.GetItemAt(0);
            foreach (string s in AvailableElements)
            {
                Label label = new Label();
                label.MouseDown += ElementClickHandler;
                label.Height = 60;
                label.Margin = new Thickness(5);
                label.Background = Brushes.DarkGray;
                label.Content = s;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 24;
                label.Width = 240;
                ElementDropDown.Items.Add(label);
            }
        }

        private void CanvasClickHandler(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LanguageChangeHandler(object sender, SelectionChangedEventArgs e)
        {
            CurrentLanguage = ((string)e.Source);
            //ElementDropDown.SelectedItem = CurrentLanguage;
        }

        private void ElementClickHandler(object sender, MouseButtonEventArgs e)
        {
           //((Label)e.Source).
        }

        public void RunGUI()
		{
			Output output = FileOutputFactory.CreateOutput(CurrentLanguage);
			foreach(Element element in Elements)
			{
				output.AddElement(element.GetElementData(), element.Content, element.Top, element.Left, element.Height, element.Width);
			}
			output.CompileFile();
		}
    }
}
