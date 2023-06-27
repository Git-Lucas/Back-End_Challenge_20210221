using System.Security.Principal;

namespace Back_End_Challenge_20210221.Models
{
    public class Pad
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? Agency_Id { get; set; }
        public string Name { get; set; }
        public string Info_Url { get; set; }
        public string Wiki_Url { get; set; }
        public string Map_Url { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public Location Location { get; set; }
        public string Map_Image { get; set; }
        public int Total_Launch_Count { get; set; }
    }
}
