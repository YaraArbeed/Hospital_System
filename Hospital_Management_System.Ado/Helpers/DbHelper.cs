using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital_Management_System.Ado.Helpers
{
    public static class DbHelper
    {
        private static IConfigurationRoot configuration;

        static DbHelper()
        {
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public static SqlConnection GetConnection()
        {
            string connectionString = configuration.GetSection("constr").Value;
            return new SqlConnection(connectionString);
        }
    }
}
