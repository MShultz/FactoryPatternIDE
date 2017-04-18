using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
    class SwingButtonElement : Element
    {
        public SwingButtonElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
        {
        }

        public override string GetElementData()
        {
            return "new JButton(\"" + this.Content + "\");" +
                   "button.setLocation(" + this.Top + "," + this.Left + ");" +
                   "button.setPreferredSize(new Dimension(" + this.Width + "," + this.Height + ");";

        }
    }
}
