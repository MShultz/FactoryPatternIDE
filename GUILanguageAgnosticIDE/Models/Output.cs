using GUILanguageAgnosticIDE.Factories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILanguageAgnosticIDE.Models
{
	public abstract class Output
	{
		public ElementFactory Factory { get; set; }
		public List<Element> Elements { get; set; }
		public Output()
		{
			this.Elements = new List<Element>();
		}
		public abstract void AddElement(string elementType, string content, int top, int left, int height, int width);
		public abstract void CompileFile();
	}
}
