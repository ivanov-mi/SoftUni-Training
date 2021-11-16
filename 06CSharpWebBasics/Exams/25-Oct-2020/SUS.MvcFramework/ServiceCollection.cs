using System;
using System.Collections.Generic;
using System.Linq;

namespace SUS.MvcFramework
{
    public class ServiceCollection : IServiceCollection
    {
        private readonly Dictionary<Type, Type> dependencyContainer = new Dictionary<Type, Type>();
        public void Add<TSource, TDestination>()
        {
            this.dependencyContainer[typeof(TSource)] = typeof(TDestination);
        }

        public object CreateInstance(Type type)
        {
            if (this.dependencyContainer.ContainsKey(type))
            {
                type = this.dependencyContainer[type];
            }

            var constructor = type.GetConstructors()
                .OrderBy(x => x.GetParameters().Count())
                .FirstOrDefault();

            var paramethers = constructor.GetParameters();
            var parametherValues = new List<object>();
            foreach (var parameter in paramethers)
            {
                var parameterValue = CreateInstance(parameter.ParameterType);
                parametherValues.Add(parameterValue);
            }

            var obj = constructor.Invoke(parametherValues.ToArray());
            return obj;
        }
    }
}
