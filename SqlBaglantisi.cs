using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hastane_Yonetim_Sistemi
{
    class SqlBaglantisi
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-HADN33JH\\SQLEXPRESS;Initial Catalog=HastaneProje;Integrated Security=True");
            baglan.Open();
            return baglan;

        }




    }
}
