using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Clase_1_Persona
{
    public class Persona
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        public Persona(int pId, string pNombre, string pApellido, int pEdad)
        {
            Id = pId;
            Nombre = pNombre;
            Apellido = pApellido;
            Edad = pEdad;
        }

        public static List<Persona> Listar()
        {
            Acceso acceso = new Acceso();

            List<Persona> Personas = new List<Persona>();



            SqlCommand command = new SqlCommand("SELECT * FROM PERSONA", acceso.Abrir());

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Persona pPersona = new Persona(int.Parse(reader["ID_PERSONA"].ToString()), reader["NOMBRE"].ToString(), reader["APELLIDO"].ToString(), int.Parse(reader["Edad"].ToString()));
                Personas.Add(pPersona);
            }

            reader.Close();

            acceso.Cerrar();


            return Personas;
        }

        public static void DarAlta(string pNombre, string pApellido, int pEdad) 
        {
            Acceso acceso = new Acceso();
            SqlCommand command = new SqlCommand($"INSERT INTO PERSONA (NOMBRE, APELLIDO, Edad) VALUES ('{pNombre}','{pApellido}', '{pEdad}')", acceso.Abrir());

            command.ExecuteNonQuery();

            

        }

        public static void DarBaja(Persona pPerson)
        {
            Acceso acceso = new Acceso();
            SqlCommand command = new SqlCommand($"DELETE FROM PERSONA WHERE ID_PERSONA = {pPerson.Id}", acceso.Abrir());

            command.ExecuteNonQuery();

            

        }

        public static void Modificar(Persona pPersona, string pNuevoNombre, string pNuevoApellido, int pNuevaEdad)
        {
            Acceso acceso = new Acceso();
            SqlCommand command = new SqlCommand($"UPDATE PERSONA SET NOMBRE = {pNuevoNombre}, APELLIDO = {pNuevoApellido}, Edad = {pNuevaEdad} WHERE ID_PERSONA = {pPersona.Id}", acceso.Abrir());

            command.ExecuteNonQuery();


        }

    }
}