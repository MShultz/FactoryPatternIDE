using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace ImplementedUserIDE.Elements
{
    public class WPFButtonElement : Element
    {

        public WPFButtonElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width) { }

        public override string GetElementData()
        {
            return "new Button(){Height = " + Height + ", Width = + " + Width + ", Content = " + Content + "};\n ";
        }
    }
}
