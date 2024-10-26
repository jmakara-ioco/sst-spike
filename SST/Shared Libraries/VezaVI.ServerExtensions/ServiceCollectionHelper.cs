using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VezaVI.Light.ServerExtensions
{
    public class ServiceCollectionHelper
    {
        private readonly IServiceCollection _services;
        public ServiceCollectionHelper(IServiceCollection services)
        {
            _services = services;
        }

        public T GetInstanceOf<T>()
        {
            var serviceDescriptor = _services.FirstOrDefault(x => typeof(T).IsAssignableFrom(x.ServiceType));
            if (serviceDescriptor == null)
                throw new Exception($"Service of Type {typeof(T).ToString()} not found");
            var instance = (T)serviceDescriptor.ImplementationInstance;
            return instance;
        }
    }
}
