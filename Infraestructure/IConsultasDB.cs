using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructure
{
    public interface IConsultasDB
    {
        DataSet ejecutar_Consulta();
    }
}
