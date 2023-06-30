
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;

namespace SysCtrlExercise
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void tm_Principal_Tick(object sender, EventArgs e)
        {
            tsslb_Data.Text = DateTime.Now.Date.ToString("dd/MM/yyyy");
            tsslb_Hora.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aparelhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Aparelho obj_Frm_Aparelho = new Frm_Aparelho();
            obj_Frm_Aparelho.ShowDialog();
        }

        private void convenioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Convenio obj_Frm_Convenio = new Frm_Convenio();
            obj_Frm_Convenio.ShowDialog();
        }

        private void planoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Plano obj_Frm_Plano = new Frm_Plano();
            obj_Frm_Plano.ShowDialog();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Cliente obj_Frm_Cliente = new Frm_Cliente();
            obj_Frm_Cliente.ShowDialog();
        }

        private void instrutorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Instrutor obj_FrmInstrutor = new Frm_Instrutor();
            obj_FrmInstrutor.ShowDialog();

        }
    }
}
