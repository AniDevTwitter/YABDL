using System;

namespace YABDL.Tools.XML.Attributes
{
    public delegate object FromStringDelegate(string str);

    public delegate string ToStringDelegate(object obj);

    //Used to override default serialization in diff process
    public sealed class ComplexType : Attribute
    {
        public ComplexType(Type converterType, string toStringName, string fromStringName)
        {
            this.ConvertToString = (ToStringDelegate)Delegate.CreateDelegate(typeof(ToStringDelegate), converterType.GetMethod(toStringName, new[] { typeof(object) }));
            this.ConvertFromString = (FromStringDelegate)Delegate.CreateDelegate(typeof(FromStringDelegate), converterType.GetMethod(fromStringName, new[] { typeof(string) }));
        }

        public FromStringDelegate ConvertFromString { get; set; }

        public ToStringDelegate ConvertToString { get; set; }
    }

    /* Usage
     *
     * public class Foo
     * {
     *      [ComplexType(typeof(AVeryComplexTypeConverter), "ToStringMethodName", "FromStringMethodName")]
     *      public AVeryComplexType complexStuff
     * }
     *
     * public static class AVeryComplexTypeConverter
     * {
     *      public static string ToStringMethodName(object obj)
     *      {
     *          //dostuff
     *      }
     *
     *      public static object FromStringMethodeName(string str)
     *      {
     *          //dostuff
     *      }
     * }
     *
     * */
}

