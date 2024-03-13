using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectAvtoPark.Models;

namespace ProjectAvtoPark.Models
{
    public class Connection
    {
        public AvtoParkEntities1 auth = new AvtoParkEntities1();
    }
   
}
