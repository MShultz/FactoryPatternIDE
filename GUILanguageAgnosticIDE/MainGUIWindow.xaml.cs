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
        public List<Label> ElementsOnPage { get; set; }
        private string SelectedElement;
        private int ElementCounter;
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
            Remove.Click += RemoveElements;
            ElementListView.HorizontalContentAlignment = HorizontalAlignment.Center;
            Elements = new List<AgnosticElement>();
            ElementsOnPage = new List<Label>();
            Compile.Click += RunGUI;
            foreach (string languages in AvailableLanguages)
            {
                LangCombo.Items.Add(languages);
            }
            LangCombo.SelectedItem = LangCombo.Items.GetItemAt(0);
            LangCombo.SelectionChanged += LanguageChangeHandler;
            CreateLablesForLanguage();
        }

        private void RemoveElements(object sender, RoutedEventArgs e)
        {
            GuiCanvas.Children.RemoveAt(GuiCanvas.Children.Count - 1);
            Elements.RemoveAt(Elements.Count - 1);
            ElementsOnPage.RemoveAt(ElementsOnPage.Count - 1);
        }

        private void CreateLablesForLanguage()
        {
            foreach (string s in AvailableElements)
            {
                Label label = new Label();
                label.MouseLeftButtonDown += ElementClickHandler;
                label.Height = 60;
                label.Margin = new Thickness(5);
                label.Background = Brushes.DarkGray;
                label.Content = s;
                label.HorizontalContentAlignment = HorizontalAlignment.Center;
                label.VerticalContentAlignment = VerticalAlignment.Center;
                label.FontSize = 24;
                label.Width = 240;
                ElementListView.Items.Add(label);
            }
        }

        private void CanvasClickHandler(object sender, MouseButtonEventArgs e)
        {
            Dialogue dialoguePrompt = new Dialogue();
            double mouseX = e.GetPosition(GuiCanvas).X;
            double mouseY = e.GetPosition(GuiCanvas).Y;
            if (dialoguePrompt.ShowDialog() == true)
            {
                Label canvasLabel = new Label();
                canvasLabel.Name = SelectedElement + ElementCounter++ + "";
                canvasLabel.Content = dialoguePrompt.ResponseText;
                canvasLabel.Height = dialoguePrompt.HeightText;
                canvasLabel.Width = dialoguePrompt.WidthText;
                canvasLabel.Background = Brushes.LightGray;
                canvasLabel.BorderThickness = new Thickness(2);
                canvasLabel.BorderBrush = Brushes.Black;
                canvasLabel.HorizontalContentAlignment = HorizontalAlignment.Center;
                canvasLabel.VerticalContentAlignment = VerticalAlignment.Center;
                ElementsOnPage.Add(canvasLabel);

                Elements.Add(new AgnosticElement(SelectedElement, canvasLabel.Content.ToString(), (int)mouseY, (int)mouseX, (int)canvasLabel.Height, (int)canvasLabel.Width));

                GuiCanvas.Children.Add(canvasLabel);
                Canvas.SetTop(canvasLabel, mouseY);
                Canvas.SetLeft(canvasLabel, mouseX);
            }
        }

        private void LanguageChangeHandler(object sender, SelectionChangedEventArgs e)
        {
            CurrentLanguage = LangCombo.SelectedItem.ToString();
            FileOutputFactory.CreateAvailableElementList(CurrentLanguage);
            ElementListView.Items.Clear();
            CreateLablesForLanguage();
            for (int i = 0; i < Elements.Count; i++)
            {
                if (!AvailableElements.Contains(Elements[i].GetElementData()))
                {
                    //wonky, change if you're not lazy.
                    MessageBox.Show("Will remove all instances of the element of type \"" + Elements[i].GetElementData() + "\"");
                    GuiCanvas.Children.Remove(ElementsOnPage[i]);
                    Elements.RemoveAt(i);
                    ElementsOnPage.RemoveAt(i);
                }
            }
        }

        private void ElementClickHandler(object sender, RoutedEventArgs e)
        {
            SelectedElement = ((Label)e.Source).Content.ToString();
        }

        public void RunGUI(object s, RoutedEventArgs e)
        {
            Output output = FileOutputFactory.CreateOutput(CurrentLanguage);
            foreach (Element element in Elements)
            {
                output.AddElement(element.GetElementData(), element.Content, element.Top, element.Left, element.Height, element.Width);
            }
            output.CompileFile();
        }
    }
}
