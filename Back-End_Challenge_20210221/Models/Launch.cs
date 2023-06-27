namespace Back_End_Challenge_20210221.Models
{
    public class Launch
    {
        public string Id { get; set; }
        public string Url { get; set; }
        public int? Launch_Library_Id { get; set; }
        public string Slug { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }
        public DateTime Net { get; set; }
        public DateTime Window_End { get; set; }
        public DateTime Window_Start { get; set; }
        public bool Inhold { get; set; }
        public bool Tbdtime { get; set; }
        public bool Tbddate { get; set; }
        public int? Probability { get; set; }
        public string Holdreason { get; set; }
        public string Failreason { get; set; }
        public string Hashtag { get; set; }
        public Launch_Service_Provider Launch_Service_Provider { get; set; }
        public Rocket Rocket { get; set; }
        public Mission Mission { get; set; }
        public Pad Pad { get; set; }
        public bool Webcast_Live { get; set; }
        public string Image { get; set; }
        public string Infographic { get; set; }
        public Program Program { get; set; }
        public DateTime Imported_t { get; set; }
        public Enums.Import_Status Import_Status { get; set; }
    }
}
