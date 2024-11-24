using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WF.ChessUI
{
    public partial class Host : Form
    {
        private LANMode lanMode;
        private IPAddress ipAddress;
        private int port;

        // Constructor that accepts LANMode as the previous form
        public Host(LANMode previousForm)
        {
            InitializeComponent();
            lanMode = previousForm;
            BackButton.Click += BackButton_Click;

            ipAddress = IPAddress.Parse(GetLocalIPAddress());
            port = GetFreePort();

            textBox1.Text = port.ToString();
            textBox2.Text = ipAddress.ToString();
        }

        // Event when the Back button is clicked
        private void BackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            if (lanMode != null && !lanMode.IsDisposed)
            {
                lanMode.Show();
            }
        }

        // Event when the Start button is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            string ipString = textBox2.Text.Replace(" ", "");
            ipAddress = IPAddress.Parse(ipString);
            MainWindow mainWindow = new MainWindow("server", ipAddress, port);
            mainWindow.Show();
            this.Hide();

            mainWindow.FormClosed += (s, args) =>
            {
                // Kiểm tra MainWindow có bị disposed không trước khi gọi Close
                if (mainWindow != null && !mainWindow.IsDisposed)
                {
                    this.Close();
                }
            };
        }

        private string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            if (ipAddress == null)
            {
                throw new Exception("Can't find local IP address!");
            }
            return ipAddress.ToString();
        }

        private int GetFreePort()
        {
            TcpListener listener = new TcpListener(IPAddress.Loopback, 0);
            listener.Start();
            int port = ((IPEndPoint)listener.LocalEndpoint).Port;
            listener.Stop();
            return port;
        }
    }
}
