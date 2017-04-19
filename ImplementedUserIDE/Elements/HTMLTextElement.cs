using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
	public class HTMLTextElement : Element
	{
		public HTMLTextElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
		{
		}

		public override string GetElementData()
		{
			return "<div style=\"position:absolute;left:" + this.Left + "px;top:" + this.Top + "px;width:" + this.Width + "px;height:" + this.Height + "px\"><p>" + this.Content + "</p></div>";
		}
	}
}
