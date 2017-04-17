using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE
{
	public class HTMLOutput : Output
	{
		public HTMLOutput(List<Element> elements) : base(elements)
		{
		}

		public override void CompileFile()
		{
			string fileContent = "<!DOCTYPE html><html><head><title>IDEGeneratedWebPage</title></head><body>";
			foreach (Element e in Elements)
			{
				fileContent += e.GetElementData();
			}
			fileContent += "</body></html>";
			using(StreamWriter sw = new StreamWriter("test.html"))
			{
				sw.Write(fileContent);
			}
			Process.Start(Path.GetFullPath("test.html"));
		}
	}
}
