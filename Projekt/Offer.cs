using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt
{
    public class Offer
    {
        public int Offer_id { get; set; }
        public int Company_Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Position_name { get; set; }
        public string Position_level { get; set; }
        public string Type_of_contract { get; set; }
        public string Employment { get; set; }
        public string Type_of_Job { get; set; }
        public string Salary { get; set; }
        public string Days { get; set; }
        public string Hours { get; set; }
        public DateTime Expired { get; set; }
        public List<string> Duties { get; set; }
        public List<string> Requirements { get; set; }
        public List<string> Benefits { get; set; }
        public int Application_Count { get; set; }
        public List<int> Applications { get; set; }
    }
}
