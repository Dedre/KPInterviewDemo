namespace School.Infrastructure.Config
{
    public class ConnectionStrings
    {
        public ConnectionStrings(string sqlServer) {
            this.SqlServer = sqlServer;
        }
        public string SqlServer { get; set; }
    }
}
