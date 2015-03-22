using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectRest.Dominio;
using System.Data.SqlClient;

namespace ProjectRest.Persistencia
{
    public class EspecialidadDAO
    {
        public Especialidad Crear(string nombre)
        {
            Especialidad especialidadCreado = new Especialidad();

            string sql = "INSERT INTO ESPECIALIDAD VALUES (@nombre)";
            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@nombre", nombre));
                    com.ExecuteNonQuery();
                }
            }

            especialidadCreado = ObtenerUltimo();

            return especialidadCreado;
        }

        public Especialidad Obtener(int cod)
        {
            Especialidad especialidadEncontrada = new Especialidad();

            string sql = "SELECT * FROM ESPECIALIDAD WHERE Co_Especialidad = @cod";
            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            especialidadEncontrada = new Especialidad()
                            {
                                Co_Especialidad = int.Parse(resultado["Co_Especialidad"].ToString()),
                                No_Especialidad = resultado["No_Especialidad"].ToString(),
                            };
                        }
                    }
                }
            }

            return especialidadEncontrada;
        }

        public string ObtenerNombre(int cod)
        {
            Especialidad especialidadEncontrada = new Especialidad();

            string sql = "SELECT * FROM ESPECIALIDAD WHERE Co_Especialidad = @cod";
            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            especialidadEncontrada = new Especialidad()
                            {
                                Co_Especialidad = int.Parse(resultado["Co_Especialidad"].ToString()),
                                No_Especialidad = resultado["No_Especialidad"].ToString(),
                            };
                        }
                    }
                }
            }

            return especialidadEncontrada.No_Especialidad.ToString();
        }

        public Especialidad ObtenerUltimo()
        {
            List<Especialidad> especialidades = Listar();

            Especialidad especialidadUltimo = especialidades.Last();

            return especialidadUltimo;
        }

        public void Eliminar(int cod)
        {
            string sql = "DELETE FROM ESPECIALIDAD where Co_Especialidad=@cod";
            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    com.ExecuteNonQuery();
                }
            }
        }

        public Especialidad Modificar(int cod, string nombre)
        {

            Especialidad especialidadModificado = new Especialidad();

            string sql = "UPDATE ESPECIALIDAD SET No_Especialidad=@nom where Co_Especialidad=@cod";
            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", cod));
                    com.Parameters.Add(new SqlParameter("@nom", nombre));
                    com.ExecuteNonQuery();
                }
            }

            especialidadModificado = Obtener(cod);

            return especialidadModificado;
        }

        public List<Especialidad> Listar()
        {
            List<Especialidad> especialidades = new List<Especialidad>();
            Especialidad especialidadEncontrada = new Especialidad();
            
            string sql = "select * from ESPECIALIDAD";

            using (SqlConnection con = new SqlConnection(ConexionBD.ObtenerCadena()))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            especialidadEncontrada = new Especialidad()
                            {
                                Co_Especialidad = int.Parse(resultado["Co_Especialidad"].ToString()),
                                No_Especialidad = resultado["No_Especialidad"].ToString(),
                            };
                            especialidades.Add(especialidadEncontrada);
                        }
                    }
                }
            }
            return especialidades;
        }

    }
}