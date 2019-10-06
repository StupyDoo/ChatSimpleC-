namespace Chat2
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbl_CircleServerState = new System.Windows.Forms.Label();
            this.lbl_ServerState = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PuertoLocal = new System.Windows.Forms.TextBox();
            this.txt_DireccionIpLocal = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.check_IniciarServer = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_DireccionIpRemota = new System.Windows.Forms.TextBox();
            this.txt_PuertoRemoto = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel_Connection = new System.Windows.Forms.Panel();
            this.wait = new System.Windows.Forms.Timer(this.components);
            this.txt_HistorialMensajes = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txt_EscribirMensaje = new System.Windows.Forms.TextBox();
            this.panel_Chat = new System.Windows.Forms.Panel();
            this.panel_Inicio = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel_Connection.SuspendLayout();
            this.panel_Chat.SuspendLayout();
            this.panel_Inicio.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbl_CircleServerState);
            this.groupBox1.Controls.Add(this.lbl_ServerState);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.check_IniciarServer);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // lbl_CircleServerState
            // 
            resources.ApplyResources(this.lbl_CircleServerState, "lbl_CircleServerState");
            this.lbl_CircleServerState.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lbl_CircleServerState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_CircleServerState.Name = "lbl_CircleServerState";
            // 
            // lbl_ServerState
            // 
            resources.ApplyResources(this.lbl_ServerState, "lbl_ServerState");
            this.lbl_ServerState.Cursor = System.Windows.Forms.Cursors.AppStarting;
            this.lbl_ServerState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbl_ServerState.Name = "lbl_ServerState";
            this.lbl_ServerState.Click += new System.EventHandler(this.Label1_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.txt_PuertoLocal);
            this.groupBox4.Controls.Add(this.txt_DireccionIpLocal);
            this.groupBox4.Controls.Add(this.label4);
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // txt_PuertoLocal
            // 
            this.txt_PuertoLocal.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.txt_PuertoLocal, "txt_PuertoLocal");
            this.txt_PuertoLocal.Name = "txt_PuertoLocal";
            this.txt_PuertoLocal.Enter += new System.EventHandler(this.TextBox7_Enter);
            this.txt_PuertoLocal.Leave += new System.EventHandler(this.Txt_Puerto_Leave);
            // 
            // txt_DireccionIpLocal
            // 
            this.txt_DireccionIpLocal.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.txt_DireccionIpLocal, "txt_DireccionIpLocal");
            this.txt_DireccionIpLocal.Name = "txt_DireccionIpLocal";
            this.txt_DireccionIpLocal.Enter += new System.EventHandler(this.Txt_DireccionIpLocal_Enter);
            this.txt_DireccionIpLocal.Leave += new System.EventHandler(this.Txt_DireccionIpLocal_Leave);
            this.txt_DireccionIpLocal.MouseEnter += new System.EventHandler(this.TextBox6_MouseEnter);
            this.txt_DireccionIpLocal.MouseLeave += new System.EventHandler(this.TextBox6_MouseLeave);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // check_IniciarServer
            // 
            resources.ApplyResources(this.check_IniciarServer, "check_IniciarServer");
            this.check_IniciarServer.Name = "check_IniciarServer";
            this.check_IniciarServer.UseVisualStyleBackColor = true;
            this.check_IniciarServer.CheckedChanged += new System.EventHandler(this.IniciarServer);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_DireccionIpRemota);
            this.groupBox2.Controls.Add(this.txt_PuertoRemoto);
            this.groupBox2.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.IniciarCliente);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txt_DireccionIpRemota
            // 
            resources.ApplyResources(this.txt_DireccionIpRemota, "txt_DireccionIpRemota");
            this.txt_DireccionIpRemota.Name = "txt_DireccionIpRemota";
            this.txt_DireccionIpRemota.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IniciarCliente);
            // 
            // txt_PuertoRemoto
            // 
            this.txt_PuertoRemoto.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.txt_PuertoRemoto, "txt_PuertoRemoto");
            this.txt_PuertoRemoto.Name = "txt_PuertoRemoto";
            this.txt_PuertoRemoto.Enter += new System.EventHandler(this.Txt_PuertoRemoto_Enter);
            this.txt_PuertoRemoto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IniciarCliente);
            this.txt_PuertoRemoto.Leave += new System.EventHandler(this.Txt_PuertoRemoto_Leave);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // panel_Connection
            // 
            this.panel_Connection.Controls.Add(this.groupBox2);
            this.panel_Connection.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.panel_Connection, "panel_Connection");
            this.panel_Connection.Name = "panel_Connection";
            // 
            // wait
            // 
            this.wait.Interval = 3000;
            // 
            // txt_HistorialMensajes
            // 
            this.txt_HistorialMensajes.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("txt_HistorialMensajes.AutoCompleteCustomSource")});
            this.txt_HistorialMensajes.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_HistorialMensajes.BackColor = System.Drawing.SystemColors.ControlLightLight;
            resources.ApplyResources(this.txt_HistorialMensajes, "txt_HistorialMensajes");
            this.txt_HistorialMensajes.Name = "txt_HistorialMensajes";
            this.txt_HistorialMensajes.ReadOnly = true;
            // 
            // textBox4
            // 
            this.textBox4.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("textBox4.AutoCompleteCustomSource")});
            this.textBox4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            // 
            // txt_EscribirMensaje
            // 
            this.txt_EscribirMensaje.AcceptsReturn = true;
            this.txt_EscribirMensaje.AutoCompleteCustomSource.AddRange(new string[] {
            resources.GetString("txt_EscribirMensaje.AutoCompleteCustomSource")});
            this.txt_EscribirMensaje.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txt_EscribirMensaje.ForeColor = System.Drawing.Color.DarkGray;
            resources.ApplyResources(this.txt_EscribirMensaje, "txt_EscribirMensaje");
            this.txt_EscribirMensaje.Name = "txt_EscribirMensaje";
            this.txt_EscribirMensaje.Enter += new System.EventHandler(this.TextBox1_Enter);
            this.txt_EscribirMensaje.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.EnterMensaje);
            this.txt_EscribirMensaje.Leave += new System.EventHandler(this.TextBox1_Leave);
            // 
            // panel_Chat
            // 
            this.panel_Chat.Controls.Add(this.txt_EscribirMensaje);
            this.panel_Chat.Controls.Add(this.textBox4);
            this.panel_Chat.Controls.Add(this.txt_HistorialMensajes);
            resources.ApplyResources(this.panel_Chat, "panel_Chat");
            this.panel_Chat.Name = "panel_Chat";
            // 
            // panel_Inicio
            // 
            this.panel_Inicio.Controls.Add(this.groupBox3);
            resources.ApplyResources(this.panel_Inicio, "panel_Inicio");
            this.panel_Inicio.Name = "panel_Inicio";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_Nombre);
            this.groupBox3.Controls.Add(this.label3);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // txt_Nombre
            // 
            resources.ApplyResources(this.txt_Nombre, "txt_Nombre");
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IngresarNombre);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            resources.ApplyResources(this.notifyIcon1, "notifyIcon1");
            // 
            // toolTip1
            // 
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ToolTipTitle = "Configuración";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_Connection);
            this.Controls.Add(this.panel_Chat);
            this.Controls.Add(this.panel_Inicio);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel_Connection.ResumeLayout(false);
            this.panel_Chat.ResumeLayout(false);
            this.panel_Chat.PerformLayout();
            this.panel_Inicio.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbl_ServerState;
        private System.Windows.Forms.CheckBox check_IniciarServer;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_DireccionIpRemota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel_Connection;
        private System.Windows.Forms.Timer wait;
        private System.Windows.Forms.TextBox txt_HistorialMensajes;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox txt_EscribirMensaje;
        private System.Windows.Forms.Panel panel_Chat;
        private System.Windows.Forms.Panel panel_Inicio;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PuertoLocal;
        private System.Windows.Forms.TextBox txt_DireccionIpLocal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lbl_CircleServerState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PuertoRemoto;
        private System.Windows.Forms.Button button1;
    }
}

