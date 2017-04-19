using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
    public class SwingButtonElement : Element
    {
		public int ID { get; set; }
		private static int ElementCounter = 0;
        public SwingButtonElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
        {
            ElementCounter++;
			ID = ElementCounter;
        }

        public override string GetElementData()
        {
            return string.Format("JButton button{0} = new JButton(\"" + Content + "\");" +
                   "button{0}.setLocation(" + Top + "," + Left + ");" +
                   "button{0}.setPreferredSize(new Dimension(" + Width + "," + Height + "));" +
                    "frame.getContentPane().add(button{0});", ID);
        }
    }
}
