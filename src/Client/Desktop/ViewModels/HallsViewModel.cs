using System;
using System.Collections.Generic;

namespace ViewModels
{
    public class HallModel
    {
        public string HallId { get; set; } = string.Empty;
        public string HallName { get; set; } = string.Empty;
        public string Building { get; set; } = string.Empty;
        public string Floor { get; set; } = string.Empty;
    }

    public class HallsViewModel
    {
        public List<HallModel> HallsList { get; set; }

        public HallsViewModel()
        {
            HallsList = new List<HallModel>();
        }

        public bool AddHall(string name, string build, string floor, out string errorMsg)
        {
            errorMsg = "";

            if (string.IsNullOrEmpty(name) || name.Trim() == "" || name == "Halls Name")
            {
                errorMsg = "Enter Name of Hall Please : ";
                return false;
            }
            if (string.IsNullOrEmpty(floor) || floor.Trim() == "")
            {
                errorMsg = "Enter Floor of Hall Please : ";
                return false;
            }
            if (string.IsNullOrEmpty(build) || build.Trim() == "")
            {
                errorMsg = "Enter Building of Hall Please : ";
                return false;
            }

            var newHall = new HallModel
            {
                HallId = Guid.NewGuid().ToString(),
                HallName = name.Trim(),
                Building = build.Trim(),
                Floor = floor.Trim()
            };

            HallsList.Add(newHall);
            return true;
        }
    }
}