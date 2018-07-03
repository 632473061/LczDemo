using System;
using System.Collections.Generic;
using System.Text;

namespace Attrbute
{
    [AttributeUsage(AttributeTargets.Interface)]
   public class LczAttribute: Attribute
    {
        public string name { get; set; }

        public LczAttribute() { }

        public LczAttribute(string name)
        {
            this.name = name;
        }
    }
}
