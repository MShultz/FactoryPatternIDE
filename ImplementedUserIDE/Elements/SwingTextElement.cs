using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
    class SwingTextElement : Element
    {
        public SwingTextElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
        {
        }

        public override string GetElementData()
        {
            return "new JLabel(" + this.Content + ");" + 
                        "jLabel.setLocation(" + this.Left + "," + this.Top + ");" +
                        "jLabel.setSize(new Dimension(" + this.Width + "," + this.Height + ");";
        }
    }
}
