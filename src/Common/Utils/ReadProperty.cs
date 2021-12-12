using System;
using System.IO;
using log4net;
using Newtonsoft.Json.Linq;

namespace BlogPostsManagementSystem.Common.Utils
{
    public class ReadProperty
    {
        private static readonly ILog _logger = LogManager.GetLogger(typeof(ReadProperty));
        
        #region Attributes

        //PROPERTY
        public static string DB_CONNECTION = GetValue("Property", "DBConnection");
        
        //JWT
        public static string JWT_ISSUER = GetValue("JWT", "Issuer");

        #endregion 
        
        private static string GetValue(string key, string name)
        {
            _logger.Debug("IN - GetProperty()");
            var answer = string.Empty;

            try
            {
                if (key != null)
                {
                    using (StreamReader r = new StreamReader("appsettings.json"))
                    {
                        string json = r.ReadToEnd();
                        var @object = JObject.Parse(json);

                        answer = (string)@object[key]?[name];
                    }   
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.Debug("OUT - GetProperty()");

            return answer;
        }
    }
}