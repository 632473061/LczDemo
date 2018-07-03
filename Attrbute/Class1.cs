using System;
using System.ComponentModel;

namespace Attrbute
{
    public class Class1
    {
    }
    [LczAttribute(name ="接口名称1")]
    public interface Itest
    {
        void Method1();
    }
    
    public enum enum1
    {
        [Description("名称1")]
        name1 =0,
        //[Description("名称2")]
        name2 =1,
        [Description("名称3")]
        name3 =2
    }
  
    public enum enum2
    {
       
        name1 = 0,
       
        name2 = 1,
     
        name3 = 2
    }
}
