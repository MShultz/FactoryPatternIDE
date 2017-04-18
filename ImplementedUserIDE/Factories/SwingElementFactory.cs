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
    class SwingElementFactory : ElementFactory
    {
        public override Element CreateElement(string elementType, string content, int top, int left, int height, int width)
        {
			Element element = null;
			switch (elementType.ToLower())
			{
				case "button":
					element = new SwingButtonElement(content, top, left, height, width);
					break;
				case "text":
					element = new SwingTextElement(content, top, left, height, width);
					break;
				default:
					throw new ArgumentException("Element type unknown!");
			}
			return element;
		}
    }
}
