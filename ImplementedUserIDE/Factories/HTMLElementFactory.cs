using GUILanguageAgnosticIDE.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILanguageAgnosticIDE.Models;
using ImplementedUserIDE.Elements;

namespace ImplementedUserIDE.Factories
{
	public class HTMLElementFactory : ElementFactory
	{
		public override Element CreateElement(string elementName, string content, int top, int left, int height, int width)
		{
			Element element = null;
			switch (elementName.ToLower())
			{
				case "button":
					element = new HTMLButtonElement(content, top, left, height, width);
					break;
				case "text":
					element = new HTMLTextElement(content, top, left, height, width);
					break;
                case "dropdown":
                    element = new HTMLDropdownElement(content, top, left, height, width);
                    break;
				default:
					throw new ArgumentException("Element type unknown!");
			}
			return element;
		}
	}
}
