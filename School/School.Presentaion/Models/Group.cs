namespace School.Presentaion.Models
{
    public class Group
    {
        public string Name { get; set; } = "";
        public List<string> Permissions { get; set; } = new List<string>();
    }
}
