using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace AppSettings
{
    public static class Settings
    {
        /// <summary>
        /// Creates an instance of an object and binds values from the configuration.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="configuration"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns>Instance of an object</returns>
        public static T Load<T>(string key, IConfiguration? configuration = null)
        {
            var settings = Activator.CreateInstance<T>();
            SettingsFactory.Create(configuration).GetSection(key).Bind(settings, opt => {
                opt.BindNonPublicProperties = true;
            });
            return settings;
        }
    }
}