using GUILanguageAgnosticIDE;
using ImplementedUserIDE.Factories;
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

namespace ImplementedUserIDE
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		MainGUIWindow mgw = null;
		public MainWindow()
		{
			HTMLElementFactory elementFac = new HTMLElementFactory();
			ProgramOutputFactory outputFac = new ProgramOutputFactory();
			mgw = new MainGUIWindow(elementFac, outputFac);
			InitializeComponent();
			this.AddChild(mgw);
			mgw.AddElement("button", "Hello!", 100, 200, 60, 150);
			mgw.AddElement("text", "This is text!", 50, 1000, 75, 120);
			mgw.RunGUI("html");
		}
	}
}
