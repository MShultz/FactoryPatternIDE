using GUILanguageAgnosticIDE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImplementedUserIDE.Elements
{
    class HTMLDropdownElement : Element
    {
        public HTMLDropdownElement(string content, int top, int left, int height, int width) : base(content, top, left, height, width)
        {
        }

        public override string GetElementData()
        {
            return "<select style=\"position:absolute;left:" + this.Left + "px;top:" + this.Top + "px;width:" + this.Width + "px;height:" + this.Height + "px\">" + PopulateOptions(this.Content) + "</select>";
        }

        private string PopulateOptions(string content)
        {
            string options = "";
            foreach (string option in content.Split(','))
            {
                options += "<Option value=\"" + option + "\">" + option + "</Option>";
            }
            return options;
        }
    }
}
