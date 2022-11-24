using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Work_Metric_Tracker.Pages.Worker.Home
{
    public class IndexModel : PageModel
    {

        public List<workerInfo> workerList = new List<workerInfo>(); 



        public void OnGet()
        {  


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
