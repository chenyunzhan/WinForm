using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;
using System.Windows.Forms;

namespace Page
{


    class Pages
    {
        public int numPerPage { get; set; }
        public int fromPage { get; set; }
        public int toPage { get; set; }


        //count pages by qty per page
        public int count(int qty)
        {
            double res = Double.Parse(rows().ToString()) / Double.Parse(qty.ToString());

            if (res.ToString().Contains("."))
            {
                res += 1;
            }
            return (int)res;
        }

        //count rows in database
        public int rows()
        {

            OracleConnection connection = new OracleConnection("DATA SOURCE=fids3;Persist Security Info=True;USER ID=fids3;Password=1");
            OracleCommand cmd = connection.CreateCommand();

            connection.Open();
            cmd.CommandText = "select * from airport t";

            OracleDataReader reader = cmd.ExecuteReader();

            var rows = 0;
            while (reader.Read())
            {
                rows++;
            }
            return rows;
        }


        public string getText(int toPage)
        {
            return " of " + toPage;
        }


        public void load(ListView lv)
        {

            OracleConnection connection = new OracleConnection("DATA SOURCE=fids3;Persist Security Info=True;USER ID=fids3;Password=1");
            OracleCommand cmd = connection.CreateCommand();

            string queryString = @"SELECT *
                                      FROM (SELECT A.*, ROWNUM RN
                                              FROM (SELECT * FROM AIRPORT) A
                                             WHERE ROWNUM <= " + toPage + @")
                                     WHERE RN >= " + fromPage;
            connection.Open();
            cmd.CommandText = queryString;

            OracleDataReader dr = cmd.ExecuteReader();

            lv.Items.Clear();
            while (dr.Read())
            {
                ListViewItem with_1 = lv.Items.Add((dr["ARPT_IATA"]).ToString());
                with_1.SubItems.Add(dr["ARPT_BRIEF_C"].ToString());
                with_1.SubItems.Add(dr["ARPT_BRIEF_E"].ToString());
            }
        }
    }
}
