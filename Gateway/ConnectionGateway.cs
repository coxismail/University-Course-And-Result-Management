using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityManagementApp.Gateway
{
    public class ConnectionGateway
    {
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public SqlDataReader Reader { get; set; }

        public ConnectionGateway()
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["UniversityManagmentDB"].ConnectionString;
            Connection = new SqlConnection(ConnectionString);
        }
    }
}