using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LambdaPractice
{
    public class ReflectionLearning
    {

       

        public void WriteObject(Object  orionObject)
        {

            IEnumerable<PropertyInfo> propertyInfos = orionObject.GetType().GetProperties();
            foreach (var propertyInfo in propertyInfos)
            {
                Console.WriteLine("Type " + propertyInfo.PropertyType.FullName);
                Console.WriteLine("Name " + propertyInfo.Name);
                Console.WriteLine("Value " + propertyInfo.GetValue(orionObject));
                Console.WriteLine("IsPrimitive: " + propertyInfo.PropertyType.IsPrimitive);
                Console.WriteLine("IsCollection: " + IsPropertyAnArray(propertyInfo));
                Console.WriteLine("IsString: " + IsPropertyAString(propertyInfo));
                Console.WriteLine("IsCustomAttribute: " + ContainsCustomAnnotation(propertyInfo));
                if (IsPropertyAnArray(propertyInfo))
                {
                    Console.WriteLine("=======ITERATE ARRAY========");
                    IterateArray(propertyInfo, orionObject);

                }
                if (ContainsCustomAnnotation(propertyInfo))
                {
                    Console.WriteLine("=======ITERATE Custom Attributes========");
                    IEnumerable<OrionAnnotation> customAttributes = GetCustomAttribute<OrionAnnotation>(propertyInfo);
                    customAttributes.ToList().ForEach(x => Console.WriteLine(x.XmlNodeName));
                }
                Console.WriteLine("===============");
            }
        }

        public void IterateArray(PropertyInfo property, Object orionObject)
        {
            var getMethod = property.GetGetMethod();
            var arrayObject = getMethod.Invoke(orionObject, null);
            foreach (object element in (Array)arrayObject)
            {
                foreach (PropertyInfo arrayObjPinfo in element.GetType().GetProperties())
                {
                    Console.WriteLine(arrayObjPinfo.Name + ":" + arrayObjPinfo.GetGetMethod().Invoke(element, null).ToString());
                }
            }
        }

        public bool IsPropertyAnArray(PropertyInfo property)
        {   var getMethod = property.GetGetMethod();
            return getMethod.ReturnType.IsArray;
        }

        public bool IsPropertyAString(PropertyInfo property)
        {
            return property.PropertyType == typeof(string);
        }

        public bool ContainsCustomAnnotation(PropertyInfo property)
        {
            IEnumerable<Attribute> customAttributes = property.GetCustomAttributes();
            return customAttributes.Any();
        }


        public IEnumerable<T> GetCustomAttribute<T>(PropertyInfo property)
        {
            Object[] customAttributes = property.GetCustomAttributes(typeof(T), true); 
            return customAttributes.OfType<T>();
        }




        public void CustomAttributes(Type targetType, Object orionObject)
        {

            IEnumerable<Type> customObject = targetType.GetNestedTypes();


            WriteObject(orionObject);
            
        }

        public void CustomObject(Type targetType, Object orionObject)
        {
            IEnumerable<PropertyInfo> propertyInfos = targetType.GetProperties();
        }
    }
}
