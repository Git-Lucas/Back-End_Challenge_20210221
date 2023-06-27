namespace Back_End_Challenge_20210221.Models
{
    public class Mission
    {
        public int Id { get; set; }
        public string Launch_Library_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Launch_Designator { get; set; }
        public string Type { get; set; }
        public Orbit Orbit { get; set; }
    }
}
