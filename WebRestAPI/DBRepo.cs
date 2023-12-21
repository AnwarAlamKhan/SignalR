using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.SignalR;
using WebRestAPI.HubConfig;
using TableDependency.SqlClient.Base;
using TableDependency.SqlClient;

namespace WebRestAPI
{
    public class DBRepo
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private IHubContext<SingnalRHub> _hub;

        public DBRepo(IConfiguration configuration, IHubContext<SingnalRHub> hub)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");
            _hub = hub;


        }
        public List<SubscriberData> GetSubscribers()
        {
            SqlConnection db = new SqlConnection(_connectionString);

            db.Open();
            //SqlDependency.Start(_connectionString);

            string cmdText = "Select * from  dbo.SubscriberData";
            SqlCommand cmd = new SqlCommand(cmdText, db);

            
            //SqlTableDependency<SubscriberData> tableDependency = new SqlTableDependency<SubscriberData>(_connectionString);
            //tableDependency.OnChanged += TableDependency_OnChanged;
            //tableDependency.OnError += TableDependency_OnError;
            //tableDependency.Start();


            var readData = cmd.ExecuteReader();
            var lstData = new List<SubscriberData>();
            while (readData.Read())
            {
                lstData.Add(new SubscriberData()
                {
                    Id = readData.GetInt32("Id"),
                    SubscriberName = readData.GetString("SubscriberName"),
                    RecievedData = readData.GetString("RecievedData")
                });

            }
            //db.Close();
            return lstData;

        }
        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(SubscriberData)} SqlTableDependency error: {e.Error.Message}");
        }

        private async void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<SubscriberData> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                _hub.Clients.All.SendAsync("ReceiveSubscriber");
            }
        }
        //private void DbChangeNotification(object sender, SqlNotificationEventArgs e)
        //{
        //    var notification = e.ToString();

        //    _hub.Clients.All.SendAsync("ReceiveProduct");
        //}

    }
    public class SubscriberData
    {
        public int Id { get; set; }
        public string SubscriberName { get; set; }
        public string RecievedData { get; set; }
    }
}
