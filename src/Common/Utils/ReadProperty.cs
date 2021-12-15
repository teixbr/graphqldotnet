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
        public static string SQL_SERVER_STRING = GetValue("Property", "SQLServerConnection");
        public static string POSTGRESQL_HOST = GetValue("PostgreSQL", "Host");
        public static int POSTGRESQL_PORT = GetValueInt("PostgreSQL", "Port");
        public static string POSTGRESQL_USER = GetValue("PostgreSQL", "User");
        public static string POSTGRESQL_PASSWORD = GetValue("PostgreSQL", "Password");
        public static string POSTGRESQL_DATABASE = GetValue("PostgreSQL", "Database");
        public static string DATABASE_ENGINE = GetValue("Property", "Database");
        
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
        
        private static int GetValueInt(string key, string name)
        {
            _logger.Debug("IN - GetValueInt()");
            var answer = int.MinValue;

            try
            {
                using (StreamReader r = new StreamReader("appsettings.json"))
                {
                    string json = r.ReadToEnd();
                    var @object = JObject.Parse(json);

                    answer = (int)@object[key]?[name];
                }
            }
            catch (Exception e)
            {
                _logger.Error(e);
            }

            _logger.Debug("OUT - GetValueInt()");

            return answer;
        }
    }
}