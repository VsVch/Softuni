using System;
using System.Linq;
using System.Reflection;


namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj) 
        {
           PropertyInfo[] properties =  obj.GetType().GetProperties();

            foreach (var property in properties)
            {
               MyValidationAttribute[] attributes = property.GetCustomAttributes()
                   //.Where(a => a is MyRequiredAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                object velue = property.GetValue(obj);

                foreach (var attribute in attributes)
                {
                    bool isValid = attribute.IsValid(velue);

                    if (!isValid)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
