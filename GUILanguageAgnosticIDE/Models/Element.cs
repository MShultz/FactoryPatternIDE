using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILanguageAgnosticIDE.Models
{
	public abstract class Element
	{
		public string Content { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
		public int Top { get; set; }
		public int Left { get; set; }
		public abstract string GetElementData();

		public Element(string content, int top, int left, int height, int width)
		{
			Content = content;
			Top = top;
			Left = left;
			Height = height;
			Width = width;
		}
	}
}
