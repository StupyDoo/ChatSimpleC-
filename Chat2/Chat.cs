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
        String miNombre;
        public Thread t1, t2, t3, t4;

        public bool conectado = false;
        public bool server = false;
        public static String ipLocal, puerto;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            server = false;
            ChatSocket.panelConection = this.panel_Connection;
            ChatSocket.txtbox = this.txt_HistorialMensajes;
            panel_Chat.BringToFront();
            panel_Connection.BringToFront();
            panel_Inicio.BringToFront();

            try
            {
                miNombre = System.IO.File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Temp\SimpleChatName.txt");
            }
            catch
            {

            }
            txt_Nombre.Text = miNombre;

        }

        private void ThreadStart()
        {
            ChatSocket.StartServer(miNombre, txt_DireccionIpLocal.Text, txt_PuertoLocal.Text);
            conectado = true;
            server = true;
            t1 = new Thread(ChatSocket.RecieveMessage);
            t1.Start();
        }

        private void UpdateLabel(String message)
        {
            lbl_ServerState.Text = message;
        }

        private void IniciarServer(object sender, EventArgs e)
        {
            if (check_IniciarServer.Checked == true)
            {
                t1 = new Thread(ThreadStart);
                t1.Start();

                Thread.Sleep(100);
                lbl_ServerState.ForeColor = Color.Green;
                lbl_CircleServerState.ForeColor = Color.Green;
                lbl_ServerState.Text = "Servidor encendido";
                txt_DireccionIpLocal.ReadOnly = true;
                txt_PuertoLocal.ReadOnly = true;
                server = true;
            }
            else
            {
                //Apagar server
            }
        }

        private void StartClient()
        {
            if (txt_DireccionIpRemota.Text == "")
            {
                txt_DireccionIpRemota.Text = "localhost";
            }
            ChatSocket.StartClient(miNombre, txt_DireccionIpRemota.Text, txt_PuertoRemoto.Text);
            server = false;
            t3 = new Thread(ChatSocket.ClientRecieveMessage);
            t3.Start();
        }

        private void IniciarCliente(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                StartClient();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
            t1.Abort();
            t2.Abort();
            t3.Abort();
            t4.Abort();
            ChatSocket.t3.Abort();
            ChatSocket.t4.Abort();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            txt_EscribirMensaje.ForeColor = Color.Black;
            txt_EscribirMensaje.Text = "";
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            txt_EscribirMensaje.ForeColor = Color.DarkGray;
            txt_EscribirMensaje.Text = "Escribe tu mensaje...";
        }

        private void TextBox6_MouseEnter(object sender, EventArgs e)
        {
            toolTip1.Active = true;
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = false;
            toolTip1.Show("Ingresa una IP propia", this, 20,145);
        }

        private void TextBox6_MouseLeave(object sender, EventArgs e)
        {
            toolTip1.Active = false;
        }

        private void TextBox7_Enter(object sender, EventArgs e)
        {
            if (!server)
            {
                txt_PuertoLocal.Text = "";
            }
            txt_PuertoLocal.ForeColor = Color.Black;
        }

        private void Txt_Puerto_Leave(object sender, EventArgs e)
        {
            if (txt_PuertoLocal.Text == "")
            {
                txt_PuertoLocal.Text = "11000";
                txt_PuertoLocal.ForeColor = Color.DarkGray;
            }
        }

        private void Txt_DireccionIpLocal_Enter(object sender, EventArgs e)
        {
            if (!server)
            {
                txt_DireccionIpLocal.Text = "";
            }
            txt_DireccionIpLocal.ForeColor = Color.Black;
        }

        private void Txt_DireccionIpLocal_Leave(object sender, EventArgs e)
        {
            if (txt_DireccionIpLocal.Text == "")
            {
                txt_DireccionIpLocal.Text = ipLocal;
                txt_DireccionIpLocal.ForeColor = Color.DarkGray;
            }
        }

        private void Txt_PuertoRemoto_Enter(object sender, EventArgs e)
        {
            if (txt_PuertoRemoto.Text != "")
            {
                txt_PuertoRemoto.Text = "";
                txt_PuertoRemoto.ForeColor = Color.Black;
            }
        }

        private void Txt_PuertoRemoto_Leave(object sender, EventArgs e)
        {
            if (txt_PuertoRemoto.Text == "")
            {
                txt_PuertoRemoto.Text = "11000";
                txt_PuertoRemoto.ForeColor = Color.DarkGray;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {

        }

        private void IniciarCliente(object sender, EventArgs e)
        {
            StartClient();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void EnterMensaje(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                SendMessage(txt_EscribirMensaje.Text.Trim());
                txt_EscribirMensaje.Text = null;
                txt_EscribirMensaje.Multiline = false;
                txt_EscribirMensaje.Multiline = true;
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
                    ChatSocket.data = message;
                }
                else
                {
                    ChatSocket.SendMessage(message);
                }
            }
        }




        private void IngresarNombre(object sender, KeyPressEventArgs e)
        {
            if (txt_Nombre.Text != "")
            {
                if (e.KeyChar == (char)13)
                {
                    miNombre = txt_Nombre.Text;
                    System.IO.File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\AppData\Local\Temp\SimpleChatName.txt", miNombre);
                    panel_Inicio.Visible = false;
                    ChatSocket.SetupServer();
                    txt_DireccionIpLocal.Text = ipLocal;
                    txt_PuertoLocal.Text = "11000";
                }
            }
        }
    }
}

