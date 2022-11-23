using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;


namespace Work_Metric_Tracker.Pages.Worker
{
    public class IndexModel : PageModel
    {

        public List<WorkerInfo> listWorkers = new List<WorkerInfo>(); 

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
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                WorkerInfo workerInfo = new WorkerInfo();
                                workerInfo.workerID = reader.GetInt32(0); 
                                workerInfo.name = reader.GetString(1);
                                workerInfo.applecare = reader.GetInt32(2);
                                workerInfo.business = reader.GetInt32(3);
                                workerInfo.connected = reader.GetInt32(4);
                                workerInfo.created_at = reader.GetDateTime(5).ToString();
                                
                                //add all workers into listworkers list 

                                listWorkers.Add(workerInfo); 
                            }
                        }
                    }

                }
            } catch ( Exception ex)
            {

            }
        }
    }

    public class WorkerInfo
    {
        public int workerID;
        public String name;
        public int applecare;
        public int business;
        public int connected;
        public String created_at; 

    }
}
