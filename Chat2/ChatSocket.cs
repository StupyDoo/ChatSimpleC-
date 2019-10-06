using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace Chat2
{
    public static class ChatSocket
    {
        delegate void HidePanel();
        delegate void AddMessage(String message, String user);

        public static String myName;
        public static String userName;

        public static Panel panelConection;
        public static TextBox txtbox;

        public static Thread t3, t4;
        public static string data = null;

        static byte[] bytesSv = new Byte[1024];
        static byte[] bytesCl = new Byte[1024];

        static IPHostEntry ipHostInfoSv;
        static IPAddress ipAddressSv;
        static IPEndPoint localEndPoint;
        static Socket listener;
        static Socket handler;

        static IPHostEntry ipHostInfoCl;
        static IPAddress ipAddressCl;
        static IPEndPoint remoteEP;
        static Socket sender;

        static public void AddMessage1(String message, String user)
        {
            txtbox.Text += (user + ": " + message + "\r\n");
            txtbox.SelectionStart = txtbox.TextLength;
            txtbox.ScrollToCaret();
        }

        static public void AddMessage2(String message, String user)
        {
            txtbox.Invoke(new AddMessage(AddMessage1), message, user);
        }

        static public void HidePanel1()
        {
            panelConection.Visible = false;       
        }

        public static void HidePanel2()
        {
            panelConection.Invoke(new HidePanel(HidePanel1));
        }

        public static void MsgShow()
        {
            MessageBox.Show("Conexión establecida con " + userName);
        }

        public static void SetupServer()
        {
            ipHostInfoSv = Dns.GetHostEntry(Dns.GetHostName());
            ipAddressSv = ipHostInfoSv.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork);
            Form1.ipLocal = ipHostInfoSv.AddressList.FirstOrDefault(a => a.AddressFamily == AddressFamily.InterNetwork).ToString();
        }

        public static void StartServer(String serverName, String ip, String puerto)
        {
            myName = serverName;
            ipAddressSv = IPAddress.Parse(ip);
            int port = Convert.ToInt32(puerto);
            localEndPoint = new IPEndPoint(ipAddressSv, port);
            Form1.puerto = port.ToString();
            Form1.ipLocal = ipAddressSv.ToString();
            listener = new Socket(ipAddressSv.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            Console.WriteLine("Server iniciado en: " + localEndPoint.ToString());
            listener.Bind(localEndPoint);
            listener.Listen(10);

            Console.WriteLine("Esperando cliente...");
            handler = listener.Accept();
            Console.WriteLine("Cliente conectado");
            HidePanel2();
            data = null;
            Console.WriteLine("Esperando mensaje...");
            int bytesRec = handler.Receive(bytesSv);
            data = Encoding.UTF32.GetString(bytesSv, 0, bytesRec);
            Console.WriteLine("Text received : {0}", data);
            t4 = new Thread(MsgShow);
            t4.Start();
            userName = data;
            data = serverName;
            byte[] msg = Encoding.UTF32.GetBytes(data);
            handler.Send(msg);
            Console.WriteLine("Server envió: " + data);

            //t4 = new Thread(SendMessage);
            //t4.Start();

        }

        public static void StartClient(String clientName, String ip, String puerto)
        {
            try
            {
                myName = clientName;
                ipHostInfoCl = Dns.GetHostEntry(Dns.GetHostName());
                //ipAddressCl = ipHostInfoCl.AddressList[5];
                ipAddressCl = IPAddress.Parse(ip);
                int port = Convert.ToInt32(puerto);
                remoteEP = new IPEndPoint(ipAddressCl, port);

                sender = new Socket(ipAddressCl.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                sender.Connect(remoteEP);
                Console.WriteLine("Socket connected to {0}", sender.RemoteEndPoint.ToString());
                HidePanel2();
                
                byte[] msg = Encoding.UTF32.GetBytes(clientName);
                // Send the data through the socket. 
                int bytesSent = sender.Send(msg);
                Console.WriteLine("Mensaje enviado: {0}", Encoding.UTF32.GetString(msg));
                int bytesRec = sender.Receive(bytesCl);
                Console.WriteLine("Recibido del server = {0}", Encoding.UTF32.GetString(bytesCl, 0, bytesRec));
                MessageBox.Show("Conexión establecida con " + Encoding.UTF32.GetString(bytesCl, 0, bytesRec));
                userName = Encoding.UTF32.GetString(bytesCl, 0, bytesRec);
            }
            catch
            {
                //StartClient(clientName, ip);
            }
            
            //t3 = new Thread(RecieveMessage);
            //t3.Start();
        }

        public static void ClientRecieveMessage()
        {
            while (true)
            {
                int bytesRec = sender.Receive(bytesCl);
                AddMessage2(Encoding.UTF32.GetString(bytesCl, 0, bytesRec), userName);
                Console.WriteLine("Recibido del server = {0}", Encoding.UTF32.GetString(bytesCl, 0, bytesRec));
            }
        }

        public static void ServerSendMessage()
        {
            byte[] msg = Encoding.UTF32.GetBytes(data);
            handler.Send(msg);
            Console.WriteLine("Server envió: " + data);
            AddMessage2(data, myName);
        }

        public static void SendMessage(String message)
        {
            try
            {

                // Connect the socket to the remote endpoint. Catch any errors.  
                try
                {
                    // Encode the data string into a byte array.  
                    byte[] msg = Encoding.UTF32.GetBytes(message);
                    // Send the data through the socket. 
                    int bytesSent = sender.Send(msg);
                    Console.WriteLine("Mensaje enviado: {0}", Encoding.UTF32.GetString(msg));
                    AddMessage2(message, myName);

                    // Release the socket.  
                    //sender.Shutdown(SocketShutdown.Both);
                    //sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public static void RecieveMessage()
        {
            try
            {

                while (true)
                {
                    
                    data = null;
                    Console.WriteLine("Esperando mensaje...");
                    int bytesRec = handler.Receive(bytesSv);
                    data = Encoding.UTF32.GetString(bytesSv, 0, bytesRec);
                    Console.WriteLine("Text received : {0}", data);
                    AddMessage2(data, userName);

                    
                    //handler.Shutdown(SocketShutdown.Both);
                    //handler.Close();
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
            handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

    }
}
    