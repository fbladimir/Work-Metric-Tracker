using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using Work_Metric_Tracker.Pages.Worker.Home;

namespace Work_Metric_Tracker.Pages.Worker.Operations
{
    public class AddModel : PageModel
    {
        public workerInfo worker = new workerInfo(); 
        public String successMessage = "";
        public String errorMessage = ""; 

        public void OnGet()
        {

        }

        public void OnPost()
        {
            //use request to get information 
            worker.name = Request.Form["name"];
            worker.applecare = Convert.ToInt32(Request.Form["applecare"]);
            worker.business = Convert.ToInt32(Request.Form["business"]);
            worker.connected = Convert.ToInt32(Request.Form["connected"]);

            //check for any length errors then show message 

            if (worker.name.Length == 0)
            {
                errorMessage = "Name needs to be filled!";
                return; 
            }

            //save new clients into database use try and catch
            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=workers;Integrated Security=True"; 

                using(SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "INSERT INTO workers " +  "(name, applecare, business, connected) VALUES " + "(@name, @applecare, @business, @connected);";


                    using (SqlCommand command = new SqlCommand(sql,connection))
                    {
                        command.Parameters.AddWithValue("@name", worker.name);
                        command.Parameters.AddWithValue("@applecare", worker.applecare);
                        command.Parameters.AddWithValue("@business", worker.business);
                        command.Parameters.AddWithValue("@connected", worker.connected); 

                        command.ExecuteNonQuery();
                    }
                }
            } catch (Exception ex)
            {
                errorMessage = ex.Message;
                return; 
            }

            worker.name = "";
            worker.applecare = 0;
            worker.business = 0;
            worker.connected = 0;




            successMessage = "You have successfully added a new worker ";   

        }
    }
}
