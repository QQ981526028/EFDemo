using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace EFDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\KTStore.mdf;integrated security=True;connect timeout=30;MultipleActiveResultSets=True;App=EntityFramework";
            SqlConnection conn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM Product", conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable datatable = new DataTable();
            da.Fill(datatable);
            conn.Close();
            da.Dispose();
            Console.WriteLine("商品数据项数：{0}\n", datatable.Rows.Count);
            foreach (DataRow row in datatable.Rows)
            {
                int id = int.Parse(row["Id"].ToString());
                string name = row["Name"].ToString();
                int price = int.Parse(row["Price"].ToString());
                string categotry = row["Category"].ToString();
                Console.WriteLine("{3}\t定价：{2}\t{0}\t{1}", id, name, price, categotry);
            }
            Console.ReadKey();
        }
    }
}
