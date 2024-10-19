using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Motos
    {
        public int IdMotos {  get; set; }
        public string CodigoChasis { get; set; }

        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string  Motor {  get; set; }
        public DateTime FechaCompra {  get; set; } = DateTime.Now;
    }
}
