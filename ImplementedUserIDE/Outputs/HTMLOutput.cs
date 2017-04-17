using GUILanguageAgnosticIDE.Factories;
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

		public HTMLOutput() : base()
		{
			availableElements = new List<string> { "button", "text", "list" };
			Factory = new HTMLElementFactory();
		}

		public override void AddElement(string elementType, string content, int top, int left, int height, int width)
		{
			switch (elementType)
			{
				case "button":
					Elements.Add(Factory.CreateElement("button", content, top, left, height, width));
					break;
				case "text":
					Elements.Add(Factory.CreateElement("text", content, top, left, height, width));
					break;
			}
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
