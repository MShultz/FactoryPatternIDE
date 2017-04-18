using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
    public class SwingTextElement : Element
    {
		public int ID { get; set; }
		private static int ElementCounter = 0;
        public SwingTextElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
        {
            ElementCounter++;
			ID = ElementCounter;
        }

        public override string GetElementData()
        {
            return string.Format("JLabel jLabel{0} = new JLabel(" + this.Content + ");" + 
                        "jLabel{0}.setLocation(" + this.Left + "," + this.Top + ");" +
                        "jLabel{0}.setSize(new Dimension(" + this.Width + "," + this.Height + ");", ID);
        }
    }
}
