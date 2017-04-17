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
		public List<Element> Elements { get; set; }
		public Output(List<Element> elements)
		{
			this.Elements = elements;
		}
		public abstract void CompileFile();
	}
}
