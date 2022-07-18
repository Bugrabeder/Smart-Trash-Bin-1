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
using System.Net.Mail;
using System.Net.Http;
using Newtonsoft.Json;
using Akllı_Çöp_Kutusu;
using System.Net.Http.Json;

namespace denemebilmemmkaççç
{
    
    public partial class Arayüz : Form
    {
       
        public Arayüz()
        {
            InitializeComponent();
        }

        Socket s3 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        
       
        public Socket serverVeriAlma()
        {
            int port = 75;
            IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Any, port);
            s3.Bind(ipEndPoint);
            s3.Listen(5);
            MessageBox.Show("Server Başlatıldı.");
            return s3;
        }
        
        
       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="socket5"></param>
        public void genelVeriYazma(Socket socket5)
        {
            Socket handler = socket5.Accept();
            string data = null;
            byte[] bytes = new byte[1024];
            handler.Receive(bytes, bytes.Length, 0);
            data = Encoding.UTF8.GetString(bytes);
            handler.Close();
            char ayrac = ',';
            string[] veriler = data.Split(ayrac);
            textBoxsigaradumanı.Text = veriler[0];
            textBoxdoluluk.Text = veriler[1];
            textBoxatesolcer.Text = veriler[2];
            textBoxsıcaklık.Text = veriler[3];
        }
       /// <summary>
       /// 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>

        private void Arayüz_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button6_Click(object sender, EventArgs e)
        {
            int port = 90;
            Socket buzzer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.Resolve("ip Adress");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            buzzer.Connect(ipEndPoint);
            string mesaj = "2";
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(mesaj);
            buzzer.Send(bytes);
            MessageBox.Show("Fan 10 Saniye çalışacak");
        }

        

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button8_Click(object sender, EventArgs e)
        {
            serverVeriAlma();
        }

        private void buttonyavas_Click(object sender, EventArgs e)
        {
            int port = 90;
            Socket buzzer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.Resolve("ip Adress");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            buzzer.Connect(ipEndPoint);
            string mesaj = "4";
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(mesaj);
            buzzer.Send(bytes);
            MessageBox.Show("Fan 10 Saniye çalışacak");
        }

        private void buttonorta_Click(object sender, EventArgs e)
        {
            int port = 90;
            Socket buzzer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.Resolve("ip Adress");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            buzzer.Connect(ipEndPoint);
            string mesaj = "3";
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(mesaj);
            buzzer.Send(bytes);
            MessageBox.Show("Fan 10 Saniye çalışacak");
        }

        private void buttonmailgonder_Click(object sender, EventArgs e)
        {
            SmtpClient sc = new SmtpClient();
            sc.Port = 587;
            sc.Host = "smtp.gmail.com";
            sc.EnableSsl = true;
            string konu = ($"Doluluk oranı:{textBoxdoluluk},Sıcaklık degeri:{textBoxsıcaklık},sigara dumanı durumu:{textBoxsigaradumanı},ateş durumu:{textBoxatesolcer}");
            sc.Credentials = new NetworkCredential("Mail Adresi", "Şifre");
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("Mail Adress", "Şifre");
            mail.To.Add("bugrabeder0@gmail.com");
            mail.Subject = "Sensor Verileri";
            mail.IsBodyHtml = true;
            mail.Body = konu;
            sc.Send(mail);
        }

        private void buttonbuzzer_Click(object sender, EventArgs e)
        {
            int port = 90;
            Socket buzzer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.Resolve("ip Adress");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            buzzer.Connect(ipEndPoint);
            string mesaj = "0";
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(mesaj);
            buzzer.Send(bytes);
            MessageBox.Show("Buzzer 5 saniye Çalışacak");
        }

        

        private void buttonkapakac_Click(object sender, EventArgs e)
        {
            int port = 90;
            Socket kapakac1 = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPHostEntry iPHost = Dns.Resolve("ip Adress");
            IPAddress ipAddr = iPHost.AddressList[0];
            IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
            kapakac1.Connect(ipEndPoint);
            string mesaj = "1";
            byte[] bytes = new byte[1024];
            bytes = Encoding.UTF8.GetBytes(mesaj);
            kapakac1.Send(bytes);
            MessageBox.Show("Kapak Açılıyor. 10 Saniye açık kalacak.");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            genelVeriYazma(s3);
        }

        

        
    }
}
