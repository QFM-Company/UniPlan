using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    internal class HallsViewModel
    {
        public class HallModel
        {
            public string HallId { get; set; }    
            public string HallName { get; set; }  
            public string Building { get; set; }   
            public string Floor { get; set; }     

        }


        internal class HallsviewModel
        { 
            public List<HallModel> HallsList { get; set; }
            public HallsviewModel()
            {
                HallsList = new List<HallModel>();
            }

            public bool AddHall(string name, string Build, string Floor,out string errorMsg) {
                errorMsg = "";
                if (string.IsNullOrEmpty(name) || name.Trim() == "" || name == "Halls Name")
                {
                    errorMsg = "Enter Name  of Hall Pleas  :  ";
                    return false;
                }
                if(string.IsNullOrEmpty(Floor) || Floor.Trim()== " ")
                {
                    errorMsg = "Enter Floor of Hall Please :  ";
                    return false;
                }
                if(string.IsNullOrEmpty(Build) || Build.Trim()== " ")
                {
                    errorMsg = "Enter Building of Hall Please :  ";
                    return false;
                }



               
            }
        }
    }
}
