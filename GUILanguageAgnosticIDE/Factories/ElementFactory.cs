using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILanguageAgnosticIDE.Factories
{
	public abstract class ElementFactory
	{
		public abstract Element CreateElement(string elementType, string content, int top, int left, int height, int width);
	}
}
