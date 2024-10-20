using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CD_Motos
    {
        public List<Moto> Listar()
        {
            List<Moto> lista = new List<Moto>();

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    string query = "SELECT Id_Moto, Codigo_Chasis, Marca, Modelo, Motor, Fecha_Compra, Stock FROM Moto";
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new Moto()
                            {
                                Id_Moto = Convert.ToInt32(reader["Id_Moto"]), 
                                Codigo_Chasis = reader["Codigo_Chasis"].ToString(),
                                Marca = reader["Marca"].ToString(),
                                Modelo = reader["Modelo"].ToString(),
                                Motor = reader["Motor"].ToString(),
                                Fecha_Compra = Convert.ToDateTime(reader["Fecha_Compra"]).ToString("yy-dd-MM"),
                                Stock = Convert.ToInt32(reader["Stock"])
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {                
                Console.WriteLine(ex.Message);
                lista = new List<Moto>();
            }

            return lista;
        }

    }
}
