using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Web;

namespace CommonUtilities
{
    public class ConfigurationHelper : IConfigurationHelper
    {
        public T Get<T>(string key)
        {
            var configuration = ConfigurationManager.AppSettings[key];

            if (!string.IsNullOrWhiteSpace(configuration))
            {
                var converter = TypeDescriptor.GetConverter(typeof(T));
                return (T)(converter.ConvertFromInvariantString(configuration));
            }
            else
                return default(T);
        }
    }

}