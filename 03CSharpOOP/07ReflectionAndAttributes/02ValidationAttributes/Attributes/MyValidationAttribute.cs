namespace ValidationAttributes.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Property)]
    public abstract class MyValidationAttribute : System.Attribute
    {
        public abstract bool IsValid(object obj);
    }
}
