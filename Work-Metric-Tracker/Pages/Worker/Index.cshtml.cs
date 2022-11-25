using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient; 

namespace Work_Metric_Tracker.Pages.Worker
{
    public class IndexModel : PageModel
    {
        public List<workerInfo> workers = new List<workerInfo>();


        public void OnGet()
        {
            try
            {


                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=workers;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "SELECT * FROM workers";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                workerInfo worker = new workerInfo();

                                worker.ID = reader.GetInt32(0);
                                worker.name = reader.GetString(1);
                                worker.applecare = reader.GetInt32(2);
                                worker.business = reader.GetInt32(3);
                                worker.connected = reader.GetInt32(4);
                                worker.created_at = reader.GetDateTime(5).ToString();

                                workers.Add(worker);

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //some exception
            }
        } 
    }


    public class workerInfo
    {
        public int ID;
        public String name;
        public int applecare;
        public int business;
        public int connected;
        public string created_at; 
    }
}
