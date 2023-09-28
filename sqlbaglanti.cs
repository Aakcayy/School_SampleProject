using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Okul_OrnekProje
{
    internal class sqlbaglanti
    {
        public SqlConnection baglanti()
        {
           SqlConnection baglan=new SqlConnection(@"Data Source=KARTAL\SQLEXPRESS02;Initial Catalog=OkulProje;Integrated Security=True");
            baglan.Open();
            return baglan;
        }
    }
}
