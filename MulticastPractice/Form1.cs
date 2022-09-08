using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Sockets;

namespace MulticastPractice
{
    public partial class Form1 : Form
    {
        string serverIP { get; set; } = "localhost";
        string port { get; set; } = "8081";

        public Form1()
        {
            InitializeComponent();
        }

        private void ButtonSubmit_Click(object sender, EventArgs e)
        {
            TcpClient tcpClient = new TcpClient(serverIP, Convert.ToInt32(port));

            int byteCount = Encoding.ASCII.GetByteCount(textBox1.Text);

            byte[] sendData = new byte[byteCount];

            sendData = Encoding.ASCII.GetBytes(textBox1.Text);

            NetworkStream networkStream = tcpClient.GetStream();

            networkStream.Write(sendData, 0, sendData.Length);

            networkStream.Close();
            tcpClient.Close();
        }
    }
}

