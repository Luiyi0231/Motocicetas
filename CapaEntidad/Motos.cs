using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Moto
    {
        public int Id_Moto {  get; set; }
        public string Codigo_Chasis { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string  Motor {  get; set; }
        public string Fecha_Compra {  get; set; }

        public int Stock { get; set; }
    }
}
