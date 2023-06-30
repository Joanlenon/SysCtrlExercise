namespace SysCtrlExercise
{
    partial class Frm_Plano
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnl_Detalhes = new System.Windows.Forms.Panel();
            this.tbox_Vlr_Plano = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbox_Desc_Plano = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbox_Nm_Plano = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbox_Cod_Plano = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbox_Planos = new System.Windows.Forms.ListBox();
            this.pnl_Titulos = new System.Windows.Forms.Panel();
            this.lb_Titulo5 = new System.Windows.Forms.Label();
            this.lb_Titulo4 = new System.Windows.Forms.Label();
            this.lb_Titulo3 = new System.Windows.Forms.Label();
            this.lb_Titulo2 = new System.Windows.Forms.Label();
            this.lb_Titulo1 = new System.Windows.Forms.Label();
            this.pnl_Botoes = new System.Windows.Forms.Panel();
            this.btn_Cancelar = new System.Windows.Forms.Button();
            this.btn_Confirmar = new System.Windows.Forms.Button();
            this.btn_Excluir = new System.Windows.Forms.Button();
            this.btn_Alterar = new System.Windows.Forms.Button();
            this.btn_Novo = new System.Windows.Forms.Button();
            this.pnl_Detalhes.SuspendLayout();
            this.pnl_Titulos.SuspendLayout();
            this.pnl_Botoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnl_Detalhes
            // 
            this.pnl_Detalhes.BackColor = System.Drawing.Color.Linen;
            this.pnl_Detalhes.Controls.Add(this.tbox_Vlr_Plano);
            this.pnl_Detalhes.Controls.Add(this.label5);
            this.pnl_Detalhes.Controls.Add(this.tbox_Desc_Plano);
            this.pnl_Detalhes.Controls.Add(this.label3);
            this.pnl_Detalhes.Controls.Add(this.tbox_Nm_Plano);
            this.pnl_Detalhes.Controls.Add(this.label2);
            this.pnl_Detalhes.Controls.Add(this.tbox_Cod_Plano);
            this.pnl_Detalhes.Controls.Add(this.label1);
            this.pnl_Detalhes.Controls.Add(this.lbox_Planos);
            this.pnl_Detalhes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Detalhes.Location = new System.Drawing.Point(0, 87);
            this.pnl_Detalhes.Name = "pnl_Detalhes";
            this.pnl_Detalhes.Size = new System.Drawing.Size(533, 276);
            this.pnl_Detalhes.TabIndex = 9;
            // 
            // tbox_Vlr_Plano
            // 
            this.tbox_Vlr_Plano.Location = new System.Drawing.Point(212, 233);
            this.tbox_Vlr_Plano.Name = "tbox_Vlr_Plano";
            this.tbox_Vlr_Plano.Size = new System.Drawing.Size(100, 20);
            this.tbox_Vlr_Plano.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(211, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Valor PLano";
            // 
            // tbox_Desc_Plano
            // 
            this.tbox_Desc_Plano.Location = new System.Drawing.Point(210, 127);
            this.tbox_Desc_Plano.Multiline = true;
            this.tbox_Desc_Plano.Name = "tbox_Desc_Plano";
            this.tbox_Desc_Plano.Size = new System.Drawing.Size(299, 86);
            this.tbox_Desc_Plano.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(209, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Descrição  Plano";
            // 
            // tbox_Nm_Plano
            // 
            this.tbox_Nm_Plano.Location = new System.Drawing.Point(210, 75);
            this.tbox_Nm_Plano.Name = "tbox_Nm_Plano";
            this.tbox_Nm_Plano.Size = new System.Drawing.Size(299, 20);
            this.tbox_Nm_Plano.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(209, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Nome Plano";
            // 
            // tbox_Cod_Plano
            // 
            this.tbox_Cod_Plano.Enabled = false;
            this.tbox_Cod_Plano.Location = new System.Drawing.Point(210, 33);
            this.tbox_Cod_Plano.Name = "tbox_Cod_Plano";
            this.tbox_Cod_Plano.Size = new System.Drawing.Size(100, 20);
            this.tbox_Cod_Plano.TabIndex = 2;
            this.tbox_Cod_Plano.Tag = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(209, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Código";
            // 
            // lbox_Planos
            // 
            this.lbox_Planos.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbox_Planos.FormattingEnabled = true;
            this.lbox_Planos.Location = new System.Drawing.Point(0, 0);
            this.lbox_Planos.Name = "lbox_Planos";
            this.lbox_Planos.Size = new System.Drawing.Size(188, 276);
            this.lbox_Planos.TabIndex = 0;
            this.lbox_Planos.Click += new System.EventHandler(this.lbox_Planos_Click);
            // 
            // pnl_Titulos
            // 
            this.pnl_Titulos.BackColor = System.Drawing.Color.Bisque;
            this.pnl_Titulos.Controls.Add(this.lb_Titulo5);
            this.pnl_Titulos.Controls.Add(this.lb_Titulo4);
            this.pnl_Titulos.Controls.Add(this.lb_Titulo3);
            this.pnl_Titulos.Controls.Add(this.lb_Titulo2);
            this.pnl_Titulos.Controls.Add(this.lb_Titulo1);
            this.pnl_Titulos.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl_Titulos.Location = new System.Drawing.Point(0, 0);
            this.pnl_Titulos.Name = "pnl_Titulos";
            this.pnl_Titulos.Size = new System.Drawing.Size(533, 87);
            this.pnl_Titulos.TabIndex = 8;
            // 
            // lb_Titulo5
            // 
            this.lb_Titulo5.AutoSize = true;
            this.lb_Titulo5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo5.ForeColor = System.Drawing.Color.SandyBrown;
            this.lb_Titulo5.Location = new System.Drawing.Point(397, 33);
            this.lb_Titulo5.Name = "lb_Titulo5";
            this.lb_Titulo5.Size = new System.Drawing.Size(68, 26);
            this.lb_Titulo5.TabIndex = 4;
            this.lb_Titulo5.Text = "Plano";
            // 
            // lb_Titulo4
            // 
            this.lb_Titulo4.AutoSize = true;
            this.lb_Titulo4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo4.ForeColor = System.Drawing.Color.Tan;
            this.lb_Titulo4.Location = new System.Drawing.Point(309, 53);
            this.lb_Titulo4.Name = "lb_Titulo4";
            this.lb_Titulo4.Size = new System.Drawing.Size(49, 20);
            this.lb_Titulo4.TabIndex = 3;
            this.lb_Titulo4.Text = "Plano";
            // 
            // lb_Titulo3
            // 
            this.lb_Titulo3.AutoSize = true;
            this.lb_Titulo3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo3.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.lb_Titulo3.Location = new System.Drawing.Point(353, 20);
            this.lb_Titulo3.Name = "lb_Titulo3";
            this.lb_Titulo3.Size = new System.Drawing.Size(34, 13);
            this.lb_Titulo3.TabIndex = 2;
            this.lb_Titulo3.Text = "Plano";
            // 
            // lb_Titulo2
            // 
            this.lb_Titulo2.AutoSize = true;
            this.lb_Titulo2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo2.ForeColor = System.Drawing.Color.Peru;
            this.lb_Titulo2.Location = new System.Drawing.Point(260, 22);
            this.lb_Titulo2.Name = "lb_Titulo2";
            this.lb_Titulo2.Size = new System.Drawing.Size(58, 24);
            this.lb_Titulo2.TabIndex = 1;
            this.lb_Titulo2.Text = "Plano";
            // 
            // lb_Titulo1
            // 
            this.lb_Titulo1.AutoSize = true;
            this.lb_Titulo1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_Titulo1.ForeColor = System.Drawing.Color.Orange;
            this.lb_Titulo1.Location = new System.Drawing.Point(207, 46);
            this.lb_Titulo1.Name = "lb_Titulo1";
            this.lb_Titulo1.Size = new System.Drawing.Size(44, 17);
            this.lb_Titulo1.TabIndex = 0;
            this.lb_Titulo1.Text = "Plano";
            // 
            // pnl_Botoes
            // 
            this.pnl_Botoes.BackColor = System.Drawing.Color.PeachPuff;
            this.pnl_Botoes.Controls.Add(this.btn_Cancelar);
            this.pnl_Botoes.Controls.Add(this.btn_Confirmar);
            this.pnl_Botoes.Controls.Add(this.btn_Excluir);
            this.pnl_Botoes.Controls.Add(this.btn_Alterar);
            this.pnl_Botoes.Controls.Add(this.btn_Novo);
            this.pnl_Botoes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnl_Botoes.Location = new System.Drawing.Point(0, 363);
            this.pnl_Botoes.Name = "pnl_Botoes";
            this.pnl_Botoes.Size = new System.Drawing.Size(533, 62);
            this.pnl_Botoes.TabIndex = 7;
            // 
            // btn_Cancelar
            // 
            this.btn_Cancelar.FlatAppearance.BorderSize = 0;
            this.btn_Cancelar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Cancelar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Cancelar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Cancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancelar.Location = new System.Drawing.Point(421, 22);
            this.btn_Cancelar.Name = "btn_Cancelar";
            this.btn_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancelar.TabIndex = 4;
            this.btn_Cancelar.Text = "Cancelar";
            this.btn_Cancelar.UseVisualStyleBackColor = true;
            this.btn_Cancelar.Click += new System.EventHandler(this.btn_Cancelar_Click);
            // 
            // btn_Confirmar
            // 
            this.btn_Confirmar.FlatAppearance.BorderSize = 0;
            this.btn_Confirmar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Confirmar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Confirmar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Confirmar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Confirmar.Location = new System.Drawing.Point(340, 22);
            this.btn_Confirmar.Name = "btn_Confirmar";
            this.btn_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.btn_Confirmar.TabIndex = 3;
            this.btn_Confirmar.Text = "Confirmar";
            this.btn_Confirmar.UseVisualStyleBackColor = true;
            this.btn_Confirmar.Click += new System.EventHandler(this.btn_Confirmar_Click);
            // 
            // btn_Excluir
            // 
            this.btn_Excluir.FlatAppearance.BorderSize = 0;
            this.btn_Excluir.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Excluir.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Excluir.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Excluir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Excluir.Location = new System.Drawing.Point(194, 22);
            this.btn_Excluir.Name = "btn_Excluir";
            this.btn_Excluir.Size = new System.Drawing.Size(75, 23);
            this.btn_Excluir.TabIndex = 2;
            this.btn_Excluir.Text = "Excluir";
            this.btn_Excluir.UseVisualStyleBackColor = true;
            this.btn_Excluir.Click += new System.EventHandler(this.btn_Excluir_Click);
            // 
            // btn_Alterar
            // 
            this.btn_Alterar.FlatAppearance.BorderSize = 0;
            this.btn_Alterar.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Alterar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Alterar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Alterar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Alterar.Location = new System.Drawing.Point(113, 22);
            this.btn_Alterar.Name = "btn_Alterar";
            this.btn_Alterar.Size = new System.Drawing.Size(75, 23);
            this.btn_Alterar.TabIndex = 1;
            this.btn_Alterar.Text = "Alterar";
            this.btn_Alterar.UseVisualStyleBackColor = true;
            this.btn_Alterar.Click += new System.EventHandler(this.btn_Alterar_Click);
            // 
            // btn_Novo
            // 
            this.btn_Novo.FlatAppearance.BorderSize = 0;
            this.btn_Novo.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btn_Novo.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Novo.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btn_Novo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Novo.Location = new System.Drawing.Point(32, 22);
            this.btn_Novo.Name = "btn_Novo";
            this.btn_Novo.Size = new System.Drawing.Size(75, 23);
            this.btn_Novo.TabIndex = 0;
            this.btn_Novo.Text = "Novo";
            this.btn_Novo.UseVisualStyleBackColor = true;
            this.btn_Novo.Click += new System.EventHandler(this.btn_Novo_Click);
            // 
            // Frm_Plano
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(533, 425);
            this.Controls.Add(this.pnl_Detalhes);
            this.Controls.Add(this.pnl_Titulos);
            this.Controls.Add(this.pnl_Botoes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Frm_Plano";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.pnl_Detalhes.ResumeLayout(false);
            this.pnl_Detalhes.PerformLayout();
            this.pnl_Titulos.ResumeLayout(false);
            this.pnl_Titulos.PerformLayout();
            this.pnl_Botoes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnl_Detalhes;
        private System.Windows.Forms.TextBox tbox_Desc_Plano;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbox_Nm_Plano;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbox_Cod_Plano;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbox_Planos;
        private System.Windows.Forms.Panel pnl_Titulos;
        private System.Windows.Forms.Label lb_Titulo5;
        private System.Windows.Forms.Label lb_Titulo4;
        private System.Windows.Forms.Label lb_Titulo3;
        private System.Windows.Forms.Label lb_Titulo2;
        private System.Windows.Forms.Label lb_Titulo1;
        private System.Windows.Forms.Panel pnl_Botoes;
        private System.Windows.Forms.Button btn_Cancelar;
        private System.Windows.Forms.Button btn_Confirmar;
        private System.Windows.Forms.Button btn_Excluir;
        private System.Windows.Forms.Button btn_Alterar;
        private System.Windows.Forms.Button btn_Novo;
        private System.Windows.Forms.TextBox tbox_Vlr_Plano;
        private System.Windows.Forms.Label label5;
    }
}