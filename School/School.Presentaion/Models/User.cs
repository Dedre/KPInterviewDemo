namespace School.Presentaion.Models
{
    public class User
    {
        public string FullName { get; set; } = "";
        public List<string> Groups { get; set; } = new List<string>();
    }
}
