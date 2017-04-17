using GUILanguageAgnosticIDE.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILanguageAgnosticIDE.Models;

namespace ImplementedUserIDE.Factories
{
	public class ProgramOutputFactory : OutputFactory
	{
		public override Output CreateOutput(string outputType, List<Element> elements)
		{
			Output output = null;
			switch (outputType.ToLower())
			{
				case "html":
					output = new HTMLOutput(elements);
					break;
				default:
					throw new ArgumentException("No such output type has been implemented!");
			}
			return output;
		}
	}
}
