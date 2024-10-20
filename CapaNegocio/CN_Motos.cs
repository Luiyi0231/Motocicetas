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
    }
}
