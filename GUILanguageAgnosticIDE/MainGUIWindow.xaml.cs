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
		private List<Element> Elements { get; set; }
		private ElementFactory GUIElementFactory { get; set; }
		private OutputFactory FileOutputFactory { get; set; }
		public MainGUIWindow(ElementFactory elementFactory, OutputFactory outputFactory)
        {
			Elements = new List<Element>();
            InitializeComponent();
			GUIElementFactory = elementFactory;
			FileOutputFactory = outputFactory;
        }

		public void AddElement(string elementName, string content, int top, int left, int height, int width)
		{
			Elements.Add(GUIElementFactory.CreateElement(elementName, content, top, left, height, width));
		}

		public void RunGUI(string outputType)
		{
			Output output = FileOutputFactory.CreateOutput(outputType, Elements);
			output.CompileFile();
		}
    }
}
