using Attrbute;
using System;
using System.ComponentModel;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
         var list=   EnumHelper.GetList(typeof(Attrbute.enum1));
            list = EnumHelper.GetList(typeof(int));
            Console.WriteLine( EnumHelper.GetDescription(Attrbute.enum1.name2));
            Console.WriteLine(EnumHelper.GetDescription(Attrbute.enum2.name2));
            var aa=Attrbute.enum1.name2.GetType().GetFields();

            var ab = Attrbute.enum2.name1.GetType().GetFields();

            foreach (var name in Enum.GetNames(typeof(Attrbute.enum1)))
            {
                Console.WriteLine(name);
            }
            foreach (var value in Enum.GetValues(typeof(Attrbute.enum1)))
            {
                Console.WriteLine(string.Format("{0}={1}", value.ToString(), Convert.ToInt32(value)));
            }

            foreach (var value in Enum.GetValues(typeof(Attrbute.enum1)))
            {
                object[] objAttrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                if (objAttrs != null &&
                    objAttrs.Length > 0)
                {
                    DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
                    Console.WriteLine(string.Format("[{0}]", descAttr.Description));
                }
                Console.WriteLine(string.Format("{0}={1}", value.ToString(), Convert.ToInt32(value)));
            }

            //var t=typeof(Attrbute.enum1);
            //var CustomAttributes = t.CustomAttributes;
            //foreach (var item in CustomAttributes)
            //{
            //    var l = item.AttributeType.Name;
            //    Console.WriteLine(l);
            //}

            //Console.WriteLine(t.FullName);
            Console.Read();
        }
    }
}
