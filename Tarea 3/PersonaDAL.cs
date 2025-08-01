using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Tarea_3
{
    public class PersonaDAL
    {
        public static int AgregarPersona(Persona persona)
        {
            int retorna = 0;

            using (SqlConnection conexion = BDgeneral.ObtnerConexion())
            {
                String query = "insert into Persona (Nombre, Edad, Telefono) values ('"+persona.Nombre+"' , "+persona.Edad+", '"+persona.Telefono+"') ";
                SqlCommand cmd = new SqlCommand(query,conexion);

                retorna = cmd.ExecuteNonQuery();
            }

            return retorna;
        }


        public static List<Persona> Presentar()
        {
            List<Persona> Lista = new List<Persona>();

            using (SqlConnection conexion = BDgeneral.ObtnerConexion())
            {
                string query = "select * From Persona"; 
                SqlCommand cmd = new SqlCommand(query, conexion);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Persona persona = new Persona();
                    persona.id = reader.GetInt32(0);
                    persona.Nombre = reader.GetString(1);
                    persona.Edad = reader.GetInt32(2);
                    persona.Telefono = reader.GetString(3);

                    Lista.Add(persona);

                }
                conexion.Close();
                return Lista;
            }
        }

        public static int Modificar(Persona persona) 
        {
            int result = 0;
            using (SqlConnection conexion = BDgeneral.ObtnerConexion())
            {
                
                string query = "update Persona set nombre='"+persona.Nombre+"', edad="+persona.Edad+", telefono='"+persona.Telefono+"' where id = "+persona.id+"";
                SqlCommand cmd = new SqlCommand(query,conexion);


                result = cmd.ExecuteNonQuery();
                conexion.Close();
            }
            return result;
        }

        public static int Eliminar(int id)
        {
            int retorna = 0;

            using (SqlConnection conexion = BDgeneral.ObtnerConexion())
            {
                String query = "delete from Persona where id='"+id+"'";
                SqlCommand cmd = new SqlCommand(query, conexion);

                retorna = cmd.ExecuteNonQuery();
            }

            return retorna;
        }



    }
}
