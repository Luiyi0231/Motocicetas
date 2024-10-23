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
                                Fecha_Compra = Convert.ToDateTime(reader["Fecha_Compra"]).ToString("yyyy-MM-dd"),
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


        public int Registrar(Moto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            int idautogenerado = 0;            
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("registrarMotos", conexion);
                    cmd.Parameters.AddWithValue("Codigo_Chasis", obj.Codigo_Chasis);
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("Motor", obj.Motor);
                    cmd.Parameters.AddWithValue("Fecha_Compra", obj.Fecha_Compra);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
                    cmd.Parameters.Add("Resultado", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    cmd.ExecuteNonQuery();
                    idautogenerado = Convert.ToInt32(cmd.Parameters["Resultado"].Value);                    

                }
                
            }catch(Exception ex)
            {
                Mensaje = ex.Message;
                idautogenerado =0;
            }

            return idautogenerado;
        }


        public bool Editar(Moto obj, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool resultado = false;
            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("editarMoto", conexion);                    
                    cmd.Parameters.AddWithValue("Id_Moto", obj.Id_Moto); 
                    cmd.Parameters.AddWithValue("Codigo_Chasis", obj.Codigo_Chasis);
                    cmd.Parameters.AddWithValue("Marca", obj.Marca);
                    cmd.Parameters.AddWithValue("Modelo", obj.Modelo);
                    cmd.Parameters.AddWithValue("Motor", obj.Motor);
                    cmd.Parameters.AddWithValue("Fecha_Compra", obj.Fecha_Compra);
                    cmd.Parameters.AddWithValue("Stock", obj.Stock);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;

                    conexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    resultado = Convert.ToBoolean(cmd.Parameters["Resultado"].Value);
                    
                    
                }

            }
            catch(Exception ex)
            {
                Mensaje = ex.Message;
                resultado = false;
            }

            return resultado;
        }

        public bool Eliminar(int Id_Moto, out string Mensaje)
        {
            Mensaje = string.Empty;
            bool resultado = false;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Conexion.cn))
                {
                    SqlCommand cmd = new SqlCommand("delete top(1) from Moto where Id_Moto = @id", conexion);
                    cmd.Parameters.AddWithValue("@id", Id_Moto);
                    cmd.Parameters.Add("Resultado", SqlDbType.Bit).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.Text;

                    conexion.Open();
                    resultado = cmd.ExecuteNonQuery() > 0 ? true : false;                    
                }
            }
            catch (Exception ex)
            {
                Mensaje = ex.Message;
                resultado = false;
            }

            return resultado;
        }


    }
}
