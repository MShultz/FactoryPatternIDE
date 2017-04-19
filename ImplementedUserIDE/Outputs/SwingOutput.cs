using GUILanguageAgnosticIDE.Models;
using ImplementedUserIDE.Factories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Outputs
{
    class SwingOutput : Output
    {
        public SwingOutput() : base()
        {
            Factory = new SwingElementFactory();
        }
        public override void AddElement(string elementType, string content, int top, int left, int height, int width)
        {
            Elements.Add(Factory.CreateElement(elementType, content, top, left, height, width));
        }

        public override void CompileFile()
        {
            String fileContent = "import java.awt.Dimension;" +
                                 "import javax.swing.JButton;" +
                                 "import javax.swing.JFrame;" +
                                 "import javax.swing.JLabel;" +
                                 "public class Main { " +
                                 "public static void main(String[] args){" +
                                 "JFrame frame = new JFrame();" +
                                 "frame.setLocationRelativeTo(null);" +
                                 "frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);" +
                                 "frame.setSize(500, 500);";

            foreach (Element e in Elements)
            {
                fileContent += e.GetElementData();
            }

            fileContent += "frame.setVisible(true);}}";

            using (StreamWriter sw = new StreamWriter("Main.java"))
            {
                sw.Write(fileContent);
            }

            Process.Start("javac", Path.GetFullPath("Main.java"));
            String fileToRun = "java " + Path.GetFullPath("Main.java").Replace(".java", "");
          //  Process.Start(fileToRun);
        }

    }

}
