using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace library
{
    class CADProduct
    {
        private string constring { get; set; }
        public CADProduct()
        {
            // Obtener la cadena de conexión desde el archivo Web.config
            constring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }
        bool Create(ENProduct eNProduct)
        {
            return false;
        }
        bool Update(ENProduct eNProduct)
        {
            return false;
        }
        bool Delete(ENProduct eNProduct)
        {
            return false;
        }
        bool read(ENProduct eNProduct)
        {
            return false;
        }
        bool readFirst(ENProduct eNProduct)
        {
            return false;
        }
        bool readNext(ENProduct eNProduct)
        {
            return false;
        }
        bool readPrev(ENProduct eNProduct)
        {
            return false;
        }

    }
}
