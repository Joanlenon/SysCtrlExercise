using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysCtrlExercise
{
    public partial class Frm_Cliente : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Cliente obj_Cliente_Atual = new Cliente();

        public Frm_Cliente()
        {
            InitializeComponent();
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaLista();
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.LimpaForm(this);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Pessoa.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Pessoa.Focus();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDCliente obj_BDCliente = new BDCliente();
            BDPessoa obj_BDPessoa = new BDPessoa();
            Pessoa obj_Pessoa = new Pessoa();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg_Resp == DialogResult.Yes)
            {
                
                obj_Pessoa.Cod_Pessoa = obj_Cliente_Atual.Cod_Pessoa;
                obj_BDPessoa.Excluir(obj_Pessoa);


                if (obj_BDCliente.Excluir(obj_Cliente_Atual))
                {
                    MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Pessoa + " foi excluido com sucesso.",
                        "Exclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                obj_FuncGeral.LimpaForm(this);
                obj_FuncGeral.HabilitaForm(this, false);
                obj_FuncGeral.StatusBtn(this, 1);
                PopulaLista();
            }
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, false);

            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Cliente_Atual);
            }
            else
            {
                obj_FuncGeral.LimpaForm(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }


        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            // ToDo mFacine (23/05/2023): validar os campos antes de gravar
            BDCliente obj_BDCliente = new BDCliente();

            obj_Cliente_Atual = PopulaObjeto();

            if (obj_Cliente_Atual.Cod_Cliente != -1)
            {
                if (obj_BDCliente.Alterar(obj_Cliente_Atual))
                {
                    MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Pessoa + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Cliente_Atual.Cod_Cliente = obj_BDCliente.Incluir(obj_Cliente_Atual);
                PopulaForm(obj_Cliente_Atual);
                MessageBox.Show("O Cliente " + obj_Cliente_Atual.Nm_Pessoa + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Clientes_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDCliente obj_BDCliente = new BDCliente();
                string s_Lin = ((ListBox)sender).Items[((ListBox)sender).SelectedIndex].ToString();
                int i_Pos = 0;

                for (int i = 0; i < s_Lin.Length; i++)
                {
                    if (s_Lin.Substring(i, 1) == "-")
                    {
                        i_Pos = i;
                        break;
                    }
                }
                obj_Cliente_Atual.Cod_Cliente = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Cliente_Atual = obj_BDCliente.FindByCod(obj_Cliente_Atual);
                PopulaForm(obj_Cliente_Atual);
                obj_FuncGeral.HabilitaForm(this, false);
                obj_FuncGeral.StatusBtn(this, 2);
            }
        }

        /********************************************************************
        *  Nome do Método: PopulaLista
        *       Descrição: Responsável por popular o listbox com os registros 
        *                  cadastrados no BD
        *     Dt. Criação: 17/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        private void PopulaLista()
        {
            //instancia do objeto BD
            BDCliente obj_BDCliente = new BDCliente();

            //instancia a lista 
            List<Cliente> obj_Lista = new List<Cliente>();

            lbox_Clientes.Items.Clear();

            obj_Lista = obj_BDCliente.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Clientes.Items.Add(obj_Lista[i].Cod_Cliente.ToString() + "-" + obj_Lista[i].Nm_Pessoa);
                }
            }
        }

        /********************************************************************
        *  Nome do Método: PopulaObjeto
        *       Descrição: Responsável por popular o objeto Atual
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        private Cliente PopulaObjeto()
        {
            //instancia do objeto 
            Cliente obj_Cliente = new Cliente();

            if (tbox_Cod_Cliente.Text != "")
            {
                obj_Cliente.Cod_Cliente = Convert.ToInt16(tbox_Cod_Cliente.Text);
            }

            obj_Cliente.Nm_Pessoa = tbox_Nm_Pessoa.Text;
            
            if (rdbtn_Masculino.Checked)
            {
                obj_Cliente.Gen_Pessoa = 0;
            }
            else
            {
                obj_Cliente.Gen_Pessoa = 1;
            }

            obj_Cliente.CPF_Pessoa = tbox_CPF_Pessoa.Text;
            obj_Cliente.Cel_Pessoa = tbox_Cel_Pessoa.Text;
            obj_Cliente.Mail_Pessoa = tbox_Mail_Pessoa.Text;
            obj_Cliente.End_Pessoa = tbox_End_Pessoa.Text;
            obj_Cliente.Bai_Pessoa = tbox_Bai_Pessoa.Text;
            obj_Cliente.Cid_Pessoa = tbox_Cid_Pessoa.Text;
            obj_Cliente.UF_Pessoa = tbox_UF_Pessoa.Text;
            obj_Cliente.CEP_Pessoa = tbox_CEP_Pessoa.Text;
            

            obj_Cliente.Cod_Plano = Convert.ToInt16(tbox_Cod_Plano.Text);
            obj_Cliente.Cod_Convenio = Convert.ToInt16(tbox_Cod_Convenio.Text);

            obj_Cliente.Mat_Cliente = tbox_Mat_Cliente.Text;

            return obj_Cliente;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *       Descrição: Responsável por popular o Formulário
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        private void PopulaForm(Cliente pobj_Cliente)
        {
            EventArgs e = new EventArgs();

            tbox_Cod_Cliente.Text = pobj_Cliente.Cod_Cliente.ToString();
            tbox_Nm_Pessoa.Text = pobj_Cliente.Nm_Pessoa;
            
            tbox_CPF_Pessoa.Text  =  pobj_Cliente.CPF_Pessoa; 
            tbox_Cel_Pessoa.Text  =  pobj_Cliente.Cel_Pessoa; 
            tbox_Mail_Pessoa.Text =  pobj_Cliente.Mail_Pessoa; 
            tbox_End_Pessoa.Text  =  pobj_Cliente.End_Pessoa ; 
            tbox_Bai_Pessoa.Text  =  pobj_Cliente.Bai_Pessoa ; 
            tbox_Cid_Pessoa.Text  =  pobj_Cliente.Cid_Pessoa ; 
            tbox_UF_Pessoa.Text   =  pobj_Cliente.UF_Pessoa ; 
            tbox_CEP_Pessoa.Text  =  pobj_Cliente.CEP_Pessoa ; 
            tbox_CPF_Pessoa.Text  =  pobj_Cliente.CPF_Pessoa ; 
            
            tbox_Cod_Plano.Text   =  pobj_Cliente.Cod_Plano.ToString();
            tbox_Cod_Plano_Leave(tbox_Cod_Plano, e);

            tbox_Cod_Convenio.Text = pobj_Cliente.Cod_Convenio.ToString();
            tbox_Cod_Convenio_Leave(tbox_Cod_Convenio, e);


            tbox_Mat_Cliente.Text =  pobj_Cliente.Mat_Cliente;
            
            rdbtn_Masculino.Checked = pobj_Cliente.Gen_Pessoa == 0;

        }

        private void tbox_Cod_Plano_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text !="")
            {
                Plano obj_Plano = new Plano();
                BDPlano obj_BDPlano = new BDPlano();

                obj_Plano.Cod_Plano = Convert.ToInt16(((TextBox)sender).Text);

                obj_Plano = obj_BDPlano.FindByCod(obj_Plano);

                lb_Nm_Plano.Text = obj_Plano.Nm_Plano;
            }
        }

        private void tbox_Cod_Convenio_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                Convenio obj_Convenio = new Convenio();
                BDConvenio obj_BDConvenio = new BDConvenio();

                obj_Convenio.Cod_Convenio = Convert.ToInt16(((TextBox)sender).Text);

                obj_Convenio = obj_BDConvenio.FindByCod(obj_Convenio);

                lb_Nm_Convenio.Text = obj_Convenio.Nm_Convenio;
            }
        }

        private void btn_Plano_Click(object sender, EventArgs e)
        {
            Frm_Plano obj_Frm_Plano = new Frm_Plano();
            obj_Frm_Plano.ShowDialog();
            if (obj_Frm_Plano.obj_Plano_Atual.Cod_Plano != -1)
            {
                tbox_Cod_Plano.Text = obj_Frm_Plano.obj_Plano_Atual.Cod_Plano.ToString();
                tbox_Cod_Plano_Leave(tbox_Cod_Plano, e);
            }
        }

        private void tbox_Cod_Cliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbox_Mat_Cliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_Matricula_Click(object sender, EventArgs e)
        {

        }

        private void lb_Nm_Convenio_Click(object sender, EventArgs e)
        {

        }

        private void btn_Convenio_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Cod_Convenio_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_Convenio_Click(object sender, EventArgs e)
        {

        }

        private void lb_Nm_Plano_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Cod_Plano_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb_Plano_Click(object sender, EventArgs e)
        {

        }

        private void tbox_CEP_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void tbox_UF_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Bai_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Cid_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void tbox_End_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Mail_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Cel_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void rdbtn_Feminino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbtn_Masculino_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tbox_CPF_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tbox_Nm_Pessoa_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Detalhes_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbox_Clientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pnl_Titulos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lb_Titulo5_Click(object sender, EventArgs e)
        {

        }

        private void lb_Titulo4_Click(object sender, EventArgs e)
        {

        }

        private void lb_Titulo3_Click(object sender, EventArgs e)
        {

        }

        private void lb_Titulo2_Click(object sender, EventArgs e)
        {

        }

        private void lb_Titulo1_Click(object sender, EventArgs e)
        {

        }

        private void pnl_Botoes_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
