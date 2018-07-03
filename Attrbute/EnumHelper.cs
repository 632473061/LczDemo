using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Attrbute
{
    public static class EnumHelper
    {
        public static string GetDescription(Enum enumValue)
        {
            string str = enumValue.ToString();
            FieldInfo field = enumValue.GetType().GetField(str);
            object[] objs = field.GetCustomAttributes(typeof(DescriptionAttribute), false);
            if (objs == null || objs.Length == 0) return str;
            DescriptionAttribute da = (DescriptionAttribute)objs[0];
            return da.Description;
        }
        public static Dictionary<int, string> GetList(Type enumType)
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            if (enumType.IsEnum)
            {
                var GetValues = Enum.GetValues(enumType);
                foreach (var value in Enum.GetValues(enumType))
                {
                    var a = value.GetType();
                    var b = value.GetType().GetField(value.ToString());
                    var c = value.GetType().GetFields();

                    int key = Convert.ToInt32(value);
                    string v = value.ToString();
                    object[] objAttrs = value.GetType().GetField(value.ToString()).GetCustomAttributes(typeof(DescriptionAttribute), true);
                    if (objAttrs != null &&
                        objAttrs.Length > 0)
                    {
                        DescriptionAttribute descAttr = objAttrs[0] as DescriptionAttribute;
                        v = descAttr.Description;
                    }
                    result.Add(key, v);
                }
            }
            return result;
        }
    }
}
