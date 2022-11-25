using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace Work_Metric_Tracker.Pages.Worker.Home
{
    public class IndexModel : PageModel
    {

        public List<workerInfo> workerList = new List<workerInfo>(); 



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
                                workerInfo workers = new workerInfo();
                                workers.ID = reader.GetInt32(0);
                                workers.name = reader.GetString(1);
                                workers.applecare = reader.GetInt32(2);
                                workers.business = reader.GetInt32(3);
                                workers.connected = reader.GetInt32(4);
                                workers.created_at = reader.GetDateTime(5).ToString(); 

                                workerList.Add(workers);

                            }


                        }
                    }
                }

            } catch (Exception ex)
            {
                //some exeception? 
            }

        }
    }

    public class workerInfo
    {
        public int ID;
        public String name;
        public int applecare = 0; // initial value is 0 
        public int business = 0; // initial value is 0 
        public int connected = 0; // initial value is 0 
        public String created_at; 

    }
}
