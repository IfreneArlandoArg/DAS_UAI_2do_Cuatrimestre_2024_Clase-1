using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Clase_1_Persona
{
    public class Acceso
    {
        
        SqlConnection connection = new SqlConnection();

        
        
        public SqlConnection Abrir() 
        {
            string connectionString = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BASE;Data Source=.\\SQLEXPRESS";
            connection.ConnectionString = connectionString;

            connection.Open();

            return connection;
        }

        public void Cerrar() 
        { 
            connection.Close();
        
        }

        

    }
}