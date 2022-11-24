using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace Work_Metric_Tracker.Pages.Worker
{
    public class IndexModel : PageModel
    {

        public List<WorkerInfo> workerList = new List<WorkerInfo>(); 


        //get method - get database data using try and catch
        public void OnGet()
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
                        while (reader.Read() )
                        {
                            WorkerInfo workerInfo = new WorkerInfo();

                            workerInfo.workerID = reader.GetInt32(0);
                            workerInfo.name = reader.GetString(1);
                            workerInfo.connected = reader.GetInt32(2); 
                            //missing apple care, business 

                        }
                    }
                }
            }

        }


        //open the connection 

        //create sql string to select all from table 

        //use sqlcommand with both sql saved string and sql string connection 

        //use sqldatareader 

        //use while loop to read information from database and add into workerInfo 

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
