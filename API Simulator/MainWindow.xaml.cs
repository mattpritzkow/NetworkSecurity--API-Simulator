using API_Simulator.Extensions;
using API_Simulator.Generation;
using API_Simulator.Networking;
using API_Simulator.TournamentData;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace API_Simulator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Tournament Tournament { get; set; }

        private static readonly HttpListener Listener = new HttpListener();

        public WarzoneGenerator TournamentGenerator { get; set; }

        public Dictionary<string, PacketLog> Requests {get; set;}

        public MainWindow()
        {
            InitializeComponent();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            TournamentGenerator = new WarzoneGenerator();

            GenerateTourneyGrid.DataContext = TournamentGenerator;

            Tournament = new Tournament();

            Requests = new Dictionary<string, PacketLog>();
        }

        private void OpenEndpoints()
        {
            Listener.Prefixes.Add("http://localhost:8081/warzone-matches/");
            Listener.Start();
            Listen();
        }

        private async void Listen()
        {
            while (true)
            {
                var context = await Listener.GetContextAsync();
                Console.WriteLine("Client Connected");
                _ = Task.Factory.StartNew(() => ProcessRequest(context));
            }
        }

        private void ProcessRequest(HttpListenerContext context)
        {

            HttpListenerResponse response = context.Response;

            string ip = context.Request.RemoteEndPoint.Address.ToString();
            Console.WriteLine(ip);
            if (Requests.ContainsKey(ip))
            {
                Requests[ip].AddPacket(DateTime.Now);
            }
            else
            {
                Requests.Add(ip, new PacketLog());
                Requests[ip].AddPacket(DateTime.Now);
            }

            string responseString;
            //Check number of recent requests:
            if (Requests[ip].GetNumRecentRequests(5) > 5)
            {
                responseString = "Error: Too many requests. Try again later.";
            }
            else
            {
                string targetPlayer = context.Request.RawUrl.Split('/')[2];
                string AuthKey = context.Request.RawUrl.Split('/')[3];
                Console.WriteLine($"{targetPlayer} data requested - checking AuthKey");


                responseString = Tournament.GetPlayerDataJSON(targetPlayer, AuthKey);//JsonConvert.SerializeObject(test);
            }
            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
            // Get a response stream and write the response to it.
            response.ContentLength64 = buffer.Length;
            System.IO.Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            // You must close the output stream.
            output.Close();
        }

        private void ButtonGenerate_Click(object sender, RoutedEventArgs e)
        {
            Tournament = TournamentGenerator.Generate();
            GenerateTourneyGrid.Visibility = Visibility.Collapsed;
            TourneyStats.Visibility = Visibility.Visible;
            SquadList.ItemsSource = Tournament.Squads;
            OpenEndpoints();
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine(((sender as FrameworkElement).DataContext as Player).Uno);
        }
    }
}
