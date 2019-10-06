using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Chat2
{
    public partial class Form1 : Form
    {

        public delegate void UpdateText(String texto);
        String[] cargando = new String[4];
        String miNombre;

        Thread t1, t2, t3, t4;
        public bool conectado = false;
        public bool server = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChatSocket.GetPanel(panel1);
            ChatSocket.GetTextBox(textBox3);
            panel2.BringToFront();
            panel1.BringToFront();
            panel3.BringToFront();
            try
            {
                miNombre = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Temp\SimpleChatName.txt");
            }
            catch
            {

            }
            textBox5.Text = miNombre;

            //if (System.Windows.Forms.Application.MessageLoop)
            //{
            //    // WinForms app
            //    System.Windows.Forms.Application.Exit();
            //}
            //else
            //{
            //    // Console app
            //    System.Environment.Exit(1);
            //}
        }

        private void ThreadStart()
        {
            ChatSocket.StartServer(miNombre);
            conectado = true;
            server = true;
            t1 = new Thread(ChatSocket.RecieveMessage);
            t1.Start();
        }

        private void ThreadRecieve()
        {
            ChatSocket.RecieveMessage();
        }

        private void UpdateLabel(String message)
        {
            label1.Text = message;
        }



        private void Cargando()
        {
            int i = 0;
            while (conectado == false)
            {
                label1.Invoke(new UpdateText(this.UpdateLabel), cargando[i++]);
                if (i == 4)
                {
                    i = 0;
                }
                Thread.Sleep(500);
            }
        }



        private void IniciarServer(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                label1.Visible = true;
                cargando[0] = "Esperando conexiones";
                cargando[1] = "Esperando conexiones.";
                cargando[2] = "Esperando conexiones..";
                cargando[3] = "Esperando conexiones...";

                t4 = new Thread(Cargando);
                t4.Start();

                t1 = new Thread(ThreadStart);
                t1.Start();

                

            }
        }

        private void IniciarCliente(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text = "localhost";
                }
                ChatSocket.StartClient(miNombre, textBox2.Text);
                server = false;
                t3 = new Thread(ChatSocket.ClientRecieveMessage);
                t3.Start();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void EnterMensaje(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendMessage(textBox1.Text.Trim());
                textBox1.Text = null;
                textBox1.Multiline = false;
                textBox1.Multiline = true;
                //MessageBox.Show(textBox1.SelectionStart.ToString());
            }
        }



        private void SendMessage(String message)
        {
            //MessageBox.Show("Eres un " + (server == true ? "server" : "cliente"));
            if (message != "")
            {
                if (server)
                {
                    t2 = new Thread(ChatSocket.ServerSendMessage);
                    t2.Start();
                    ChatSocket.GetString(message);
                }
                else
                {
                    ChatSocket.SendMessage(message);
                }
            }
        }




        private void IngresarNombre(object sender, KeyPressEventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (e.KeyChar == (char)13)
                {
                    miNombre = textBox5.Text;
                    System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Temp\SimpleChatName.txt", miNombre);
                    panel3.Visible = false;
                    //notifyIcon1.Visible = true;
                    //notifyIcon1.BalloonTipTitle = "Has recibido un mensaje";
                    //notifyIcon1.BalloonTipText = "Da clic para verlo";
                    //notifyIcon1.ShowBalloonTip(1000);
                }
            }
        }

    }
}
