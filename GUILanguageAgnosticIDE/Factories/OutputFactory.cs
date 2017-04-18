using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUILanguageAgnosticIDE.Factories
{
	public abstract class OutputFactory
	{
		public abstract Output CreateOutput(string outputType);

		public abstract List<string> CreateAvailableElementList(string outputType);
	}
}
