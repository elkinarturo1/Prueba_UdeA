using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ConexionDB_Model
    {

        public string strConexion { get; set; }
        public string sp { get; set; }
        public string[] parameter { get; set; }

    }
}
