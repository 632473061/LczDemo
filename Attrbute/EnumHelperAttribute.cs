using System;
using System.Collections.Generic;
using System.Text;

namespace Attrbute
{
    [AttributeUsage(AttributeTargets.Field,AllowMultiple =false)]
   public class EnumHelperAttribute:Attribute
    {
        public string Name { get; set; }

        public EnumHelperAttribute(string name)
        {
            this.Name = name;
        }
    }
}
