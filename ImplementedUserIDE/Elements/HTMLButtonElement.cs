using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
	public class HTMLButtonElement : Element
	{
		public HTMLButtonElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
		{
		}

		public override string GetElementData()
		{
			return "<button style=\"position:absolute;left:" + this.Left + "px;top:" + this.Top + "px;width:" + this.Width + "px;height:" + this.Height + "px\">" + this.Content + "</button>";
		}
	}
}
