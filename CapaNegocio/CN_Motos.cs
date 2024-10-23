using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class CN_Motos
    {
        private CD_Motos objCapaDato = new CD_Motos();

        public List<Moto> Listar()
        {
            return objCapaDato.Listar();
        }

        public int Registrar(Moto obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Codigo_Chasis) || string.IsNullOrWhiteSpace(obj.Codigo_Chasis))
            {
                Mensaje = "El Codigo_Chasis no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Marca) || string.IsNullOrWhiteSpace(obj.Marca))
            {
                Mensaje = "La Marca no puede ser vacía";
            }
            else if (string.IsNullOrEmpty(obj.Modelo) || string.IsNullOrWhiteSpace(obj.Modelo))
            {
                Mensaje = "El Modelo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Motor) || string.IsNullOrWhiteSpace(obj.Motor))
            {
                Mensaje = "El Motor no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Fecha_Compra) || string.IsNullOrWhiteSpace(obj.Fecha_Compra))
            {
                Mensaje = "La Fecha de compra no puede ser vacía";
            }      
            
            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Registrar(obj, out Mensaje);
            }else
            {
                return 0; 
            }
                                 
            
        }

        public bool Editar(Moto obj,  out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Codigo_Chasis) || string.IsNullOrWhiteSpace(obj.Codigo_Chasis))
            {
                Mensaje = "El Codigo_Chasis no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Marca) || string.IsNullOrWhiteSpace(obj.Marca))
            {
                Mensaje = "La Marca no puede ser vacía";
            }
            else if (string.IsNullOrEmpty(obj.Modelo) || string.IsNullOrWhiteSpace(obj.Modelo))
            {
                Mensaje = "El Modelo no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Motor) || string.IsNullOrWhiteSpace(obj.Motor))
            {
                Mensaje = "El Motor no puede ser vacío";
            }
            else if (string.IsNullOrEmpty(obj.Fecha_Compra) || string.IsNullOrWhiteSpace(obj.Fecha_Compra))
            {
                Mensaje = "La Fecha de compra no puede ser vacía";
            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool Eliminar(int Id_Moto, out string Mensaje)
        {
            return objCapaDato.Eliminar(Id_Moto, out Mensaje);
        }

    }
}
