using GUILanguageAgnosticIDE.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUILanguageAgnosticIDE.Models;

namespace ImplementedUserIDE.Factories
{
    class SwingElementFactory : ElementFactory
    {
        public override Element CreateElement(string elementType, string content, int top, int left, int height, int width)
        {
            throw new NotImplementedException();
        }
    }
}
