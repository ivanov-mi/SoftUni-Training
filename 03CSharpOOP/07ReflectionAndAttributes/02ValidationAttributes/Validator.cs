namespace ValidationAttributes
{
    using System.Linq;
    using Attributes;

    public static class Validator
    {
        public static bool IsValid(object obj) 
        {
            var objProperties = obj.GetType()
                .GetProperties();

            foreach (var property in objProperties)
            {
                var propAttributes = property.GetCustomAttributes(true)
                    .Where(attrb => attrb is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()  
                    .ToArray();

                foreach (var attributes in propAttributes)
                {
                    var result = attributes.IsValid(property.GetValue(obj));
                    
                    if (result == false)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
