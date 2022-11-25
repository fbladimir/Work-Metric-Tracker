using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient; 

namespace Work_Metric_Tracker.Pages.Worker
{
    public class AddModel : PageModel
    {
        public string successMessage = "";
        public string errMessage = "";

        public workerInfo worker = new workerInfo();





        public void OnGet()
        {
        }

        public void OnPost()
        {
            //get info from form by request.form 

            worker.name = Request.Form["name"];
            worker.applecare = Convert.ToInt32(Request.Form["applecare"]);
            worker.business = Convert.ToInt32(Request.Form["business"]);
            worker.connected = Convert.ToInt32(Request.Form["connected"]);



            //check for length and if not show error message 

            if (worker.name.Length == 0)
            {
                errMessage = "You need to fill all fields!";
                return;
            }

            //save new clients into database use try and catch 

            try
            {
                String connectionString = "Data Source=.\\sqlexpress;Initial Catalog=workers;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    String sql = "INSERT INTO workers (name, applecare, business, connected) VALUES (@name, @applecare, @business, @connected);";

                    using (SqlCommand command = new SqlCommand(sql, connection))
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
                errMessage = ex.Message;
                return;
            }

            worker.name = "";
            worker.applecare = 0;
            worker.business = 0;
            worker.connected = 0;

            successMessage = "You have successfully added a new worker";

            }

        } 

        
}
