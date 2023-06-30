namespace SysCtrlExercise
{
    partial class Frm_Principal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Principal));
            this.mnstrip_Principal = new System.Windows.Forms.MenuStrip();
            this.clienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.instrutorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acompanhamentoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aparelhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convenioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sairToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pbox_Principal = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Data = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Hora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslb_Usuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel14 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel13 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel12 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel11 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tm_Principal = new System.Windows.Forms.Timer(this.components);
            this.planoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.programaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnstrip_Principal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Principal)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnstrip_Principal
            // 
            this.mnstrip_Principal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clienteToolStripMenuItem,
            this.instrutorToolStripMenuItem,
            this.aparelhoToolStripMenuItem,
            this.convenioToolStripMenuItem,
            this.sairToolStripMenuItem});
            this.mnstrip_Principal.Location = new System.Drawing.Point(0, 0);
            this.mnstrip_Principal.Name = "mnstrip_Principal";
            this.mnstrip_Principal.Size = new System.Drawing.Size(1110, 24);
            this.mnstrip_Principal.TabIndex = 0;
            this.mnstrip_Principal.Text = "menuStrip1";
            // 
            // clienteToolStripMenuItem
            // 
            this.clienteToolStripMenuItem.DoubleClickEnabled = true;
            this.clienteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.planoToolStripMenuItem,
            this.toolStripMenuItem1,
            this.programaToolStripMenuItem});
            this.clienteToolStripMenuItem.Name = "clienteToolStripMenuItem";
            this.clienteToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.clienteToolStripMenuItem.Text = "Cliente";
            this.clienteToolStripMenuItem.DoubleClick += new System.EventHandler(this.clienteToolStripMenuItem_DoubleClick_1);
            // 
            // instrutorToolStripMenuItem
            // 
            this.instrutorToolStripMenuItem.DoubleClickEnabled = true;
            this.instrutorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acompanhamentoToolStripMenuItem});
            this.instrutorToolStripMenuItem.Name = "instrutorToolStripMenuItem";
            this.instrutorToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.instrutorToolStripMenuItem.Text = "Instrutor";
            this.instrutorToolStripMenuItem.DoubleClick += new System.EventHandler(this.instrutorToolStripMenuItem_DoubleClick);
            // 
            // acompanhamentoToolStripMenuItem
            // 
            this.acompanhamentoToolStripMenuItem.Name = "acompanhamentoToolStripMenuItem";
            this.acompanhamentoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.acompanhamentoToolStripMenuItem.Text = "Acompanhamento";
            // 
            // aparelhoToolStripMenuItem
            // 
            this.aparelhoToolStripMenuItem.Name = "aparelhoToolStripMenuItem";
            this.aparelhoToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.aparelhoToolStripMenuItem.Text = "Aparelho";
            this.aparelhoToolStripMenuItem.Click += new System.EventHandler(this.aparelhoToolStripMenuItem_Click);
            // 
            // convenioToolStripMenuItem
            // 
            this.convenioToolStripMenuItem.Name = "convenioToolStripMenuItem";
            this.convenioToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.convenioToolStripMenuItem.Text = "Convenio";
            this.convenioToolStripMenuItem.Click += new System.EventHandler(this.convenioToolStripMenuItem_Click);
            // 
            // sairToolStripMenuItem
            // 
            this.sairToolStripMenuItem.Name = "sairToolStripMenuItem";
            this.sairToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sairToolStripMenuItem.Text = "Sair";
            this.sairToolStripMenuItem.Click += new System.EventHandler(this.sairToolStripMenuItem_Click);
            // 
            // pbox_Principal
            // 
            this.pbox_Principal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbox_Principal.Image = ((System.Drawing.Image)(resources.GetObject("pbox_Principal.Image")));
            this.pbox_Principal.Location = new System.Drawing.Point(0, 24);
            this.pbox_Principal.Name = "pbox_Principal";
            this.pbox_Principal.Size = new System.Drawing.Size(1110, 500);
            this.pbox_Principal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbox_Principal.TabIndex = 2;
            this.pbox_Principal.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslb_Data,
            this.toolStripStatusLabel2,
            this.tsslb_Hora,
            this.toolStripStatusLabel3,
            this.tsslb_Usuario,
            this.toolStripStatusLabel5,
            this.toolStripStatusLabel6,
            this.toolStripStatusLabel9,
            this.toolStripStatusLabel4,
            this.toolStripStatusLabel14,
            this.toolStripStatusLabel13,
            this.toolStripStatusLabel12,
            this.toolStripStatusLabel11,
            this.toolStripStatusLabel10,
            this.toolStripStatusLabel7,
            this.toolStripStatusLabel8});
            this.statusStrip1.Location = new System.Drawing.Point(0, 502);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1110, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(37, 17);
            this.toolStripStatusLabel1.Text = "Data: ";
            // 
            // tsslb_Data
            // 
            this.tsslb_Data.Name = "tsslb_Data";
            this.tsslb_Data.Size = new System.Drawing.Size(52, 17);
            this.tsslb_Data.Text = "__/__/___";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel2.Text = "Hora: ";
            // 
            // tsslb_Hora
            // 
            this.tsslb_Hora.AutoSize = false;
            this.tsslb_Hora.Name = "tsslb_Hora";
            this.tsslb_Hora.Size = new System.Drawing.Size(60, 17);
            this.tsslb_Hora.Text = "__:__:__";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(53, 17);
            this.toolStripStatusLabel3.Text = "Usuário: ";
            // 
            // tsslb_Usuario
            // 
            this.tsslb_Usuario.AutoSize = false;
            this.tsslb_Usuario.Name = "tsslb_Usuario";
            this.tsslb_Usuario.Size = new System.Drawing.Size(60, 17);
            this.tsslb_Usuario.Text = "ononon";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.AutoSize = false;
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(150, 17);
            // 
            // toolStripStatusLabel6
            // 
            this.toolStripStatusLabel6.Name = "toolStripStatusLabel6";
            this.toolStripStatusLabel6.Size = new System.Drawing.Size(273, 17);
            this.toolStripStatusLabel6.Text = "Sistema de Controle de Exercícios - SysCtrlExercise";
            // 
            // toolStripStatusLabel9
            // 
            this.toolStripStatusLabel9.AutoSize = false;
            this.toolStripStatusLabel9.Name = "toolStripStatusLabel9";
            this.toolStripStatusLabel9.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.AutoSize = false;
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel14
            // 
            this.toolStripStatusLabel14.AutoSize = false;
            this.toolStripStatusLabel14.Name = "toolStripStatusLabel14";
            this.toolStripStatusLabel14.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel13
            // 
            this.toolStripStatusLabel13.AutoSize = false;
            this.toolStripStatusLabel13.Name = "toolStripStatusLabel13";
            this.toolStripStatusLabel13.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel12
            // 
            this.toolStripStatusLabel12.AutoSize = false;
            this.toolStripStatusLabel12.Name = "toolStripStatusLabel12";
            this.toolStripStatusLabel12.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel11
            // 
            this.toolStripStatusLabel11.AutoSize = false;
            this.toolStripStatusLabel11.Name = "toolStripStatusLabel11";
            this.toolStripStatusLabel11.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel10
            // 
            this.toolStripStatusLabel10.AutoSize = false;
            this.toolStripStatusLabel10.Name = "toolStripStatusLabel10";
            this.toolStripStatusLabel10.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel7
            // 
            this.toolStripStatusLabel7.AutoSize = false;
            this.toolStripStatusLabel7.Name = "toolStripStatusLabel7";
            this.toolStripStatusLabel7.Size = new System.Drawing.Size(50, 17);
            // 
            // toolStripStatusLabel8
            // 
            this.toolStripStatusLabel8.Name = "toolStripStatusLabel8";
            this.toolStripStatusLabel8.Size = new System.Drawing.Size(64, 15);
            this.toolStripStatusLabel8.Text = "by Lenon\'s";
            // 
            // tm_Principal
            // 
            this.tm_Principal.Enabled = true;
            this.tm_Principal.Tick += new System.EventHandler(this.tm_Principal_Tick);
            // 
            // planoToolStripMenuItem
            // 
            this.planoToolStripMenuItem.Name = "planoToolStripMenuItem";
            this.planoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.planoToolStripMenuItem.Text = "Plano";
            this.planoToolStripMenuItem.Click += new System.EventHandler(this.planoToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // programaToolStripMenuItem
            // 
            this.programaToolStripMenuItem.Name = "programaToolStripMenuItem";
            this.programaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.programaToolStripMenuItem.Text = "Programa";
            this.programaToolStripMenuItem.Click += new System.EventHandler(this.programaToolStripMenuItem_Click);
            // 
            // Frm_Principal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 524);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.pbox_Principal);
            this.Controls.Add(this.mnstrip_Principal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.mnstrip_Principal;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Frm_Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnstrip_Principal.ResumeLayout(false);
            this.mnstrip_Principal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbox_Principal)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnstrip_Principal;
        private System.Windows.Forms.ToolStripMenuItem clienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem instrutorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acompanhamentoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aparelhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convenioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sairToolStripMenuItem;
        private System.Windows.Forms.PictureBox pbox_Principal;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Data;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Hora;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel tsslb_Usuario;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel6;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel7;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel8;
        private System.Windows.Forms.Timer tm_Principal;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel9;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel11;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel10;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel12;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel13;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel14;
        private System.Windows.Forms.ToolStripMenuItem planoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem programaToolStripMenuItem;
    }
}

