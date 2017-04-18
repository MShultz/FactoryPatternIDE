using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILanguageAgnosticIDE.Models
{
	public class AgnosticElement : Element
	{
		private string ElementType { get; set; }
		public AgnosticElement(string elementType, string content, int top, int left, int height, int width) : base(content, top, left, height, width)
		{
			ElementType = elementType
		}

		public override string GetElementData()
		{
			return ElementType;
		}
	}
}
