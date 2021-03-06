﻿using GUILanguageAgnosticIDE.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILanguageAgnosticIDE.Models;
using ImplementedUserIDE.Outputs;

namespace ImplementedUserIDE.Factories
{
	public class ProgramOutputFactory : OutputFactory
	{
		public override List<string> CreateAvailableElementList(string outputType)
		{
            List<string> availableElements;
			switch (outputType.ToLower())
			{
				case "html":
					availableElements = new List<string> { "button", "text", "dropdown", "image"};
					break;
				case "swing":
					availableElements = new List<string> { "button", "text" };
					break;
				default:
					throw new ArgumentException("No such output type has been implemented!");
			}
			return availableElements;
		}

		public override Output CreateOutput(string outputType)
		{
			Output output = null;
			switch (outputType.ToLower())
			{
				case "html":
					output = new HTMLOutput();
					break;
                case "swing":
                    output = new SwingOutput();
                    break;
				default:
					throw new ArgumentException("No such output type has been implemented!");
			}
			return output;
		}
	}
}
