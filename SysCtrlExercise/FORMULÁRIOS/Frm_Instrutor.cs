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
    public partial class Frm_Instrutor : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Instrutor obj_Instrutor_Atual = new Instrutor();

        public Frm_Instrutor()
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
            BDInstrutor obj_BDInstrutor = new BDInstrutor();
            BDPessoa obj_BDPessoa = new BDPessoa();
            Pessoa obj_Pessoa = new Pessoa();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg_Resp == DialogResult.Yes)
            {

                


                if (obj_BDInstrutor.Excluir(obj_Instrutor_Atual))
                {
                    obj_Pessoa.Cod_Pessoa = obj_Instrutor_Atual.Cod_Pessoa;
                    obj_BDPessoa.Excluir(obj_Pessoa);
                    MessageBox.Show("O Instrutor " + obj_Instrutor_Atual.Nm_Pessoa + " foi excluido com sucesso.",
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

            if (obj_Instrutor_Atual.Cod_Instrutor != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Instrutor_Atual);
            }
            else
            {
                obj_FuncGeral.LimpaForm(this);
                obj_FuncGeral.StatusBtn(this, 1);
            }
        }


        private void btn_Confirmar_Click(object sender, EventArgs e)
        {
            // ToDoLenon's (23/05/2023): validar os campos antes de gravar
            BDInstrutor obj_BDInstrutor = new BDInstrutor();

            obj_Instrutor_Atual = PopulaObjeto();

            if (obj_Instrutor_Atual.Cod_Instrutor != -1)
            {
                if (obj_BDInstrutor.Alterar(obj_Instrutor_Atual))
                {
                    MessageBox.Show("O Instrutor " + obj_Instrutor_Atual.Nm_Pessoa + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Instrutor_Atual.Cod_Instrutor = obj_BDInstrutor.Incluir(obj_Instrutor_Atual);
                PopulaForm(obj_Instrutor_Atual);
                MessageBox.Show("O Instrutor " + obj_Instrutor_Atual.Nm_Pessoa + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Instrutores_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDInstrutor obj_BDInstrutor = new BDInstrutor();
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
                obj_Instrutor_Atual.Cod_Instrutor = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Instrutor_Atual = obj_BDInstrutor.FindByCod(obj_Instrutor_Atual);
                PopulaForm(obj_Instrutor_Atual);
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
        *      Criada por:Lenon's 
        ********************************************************************/
        private void PopulaLista()
        {
            //instancia do objeto BD
            BDInstrutor obj_BDInstrutor = new BDInstrutor();

            //instancia a lista 
            List<Instrutor> obj_Lista = new List<Instrutor>();

            lbox_Instrutores.Items.Clear();

            obj_Lista = obj_BDInstrutor.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Instrutores.Items.Add(obj_Lista[i].Cod_Instrutor.ToString() + "-" + obj_Lista[i].Nm_Pessoa);
                }
            }
        }

        /********************************************************************
        *  Nome do Método: PopulaObjeto
        *       Descrição: Responsável por popular o objeto Atual
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        private Instrutor PopulaObjeto()
        {
            //instancia do objeto 
            Instrutor obj_Instrutor = new Instrutor();

            if (tbox_Cod_Instrutor.Text != "")
            {
                obj_Instrutor.Cod_Instrutor = Convert.ToInt16(tbox_Cod_Instrutor.Text);
            }


            obj_Instrutor.Cod_Pessoa = obj_Instrutor_Atual.Cod_Pessoa;

            obj_Instrutor.Nm_Pessoa = tbox_Nm_Pessoa.Text;

            if (rdbtn_Masculino.Checked)
            {
                obj_Instrutor.Gen_Pessoa = 0;
            }
            else
            {
                obj_Instrutor.Gen_Pessoa = 1;
            }

            obj_Instrutor.CPF_Pessoa = tbox_CPF_Pessoa.Text;
            obj_Instrutor.Cel_Pessoa = tbox_Cel_Pessoa.Text;
            obj_Instrutor.Mail_Pessoa = tbox_Mail_Pessoa.Text;
            obj_Instrutor.End_Pessoa = tbox_End_Pessoa.Text;
            obj_Instrutor.Bai_Pessoa = tbox_Bai_Pessoa.Text;
            obj_Instrutor.Cid_Pessoa = tbox_Cid_Pessoa.Text;
            obj_Instrutor.UF_Pessoa = tbox_UF_Pessoa.Text;
            obj_Instrutor.CEP_Pessoa = tbox_CEP_Pessoa.Text;
            obj_Instrutor.CPF_Pessoa = tbox_CPF_Pessoa.Text;

            if (ckbox_Manha.Checked)
            {
                obj_Instrutor.Per_Instrutor += "1";
            }
            else
            {
                obj_Instrutor.Per_Instrutor += "0";
            }

            if (ckbox_Tarde.Checked)
            {
                obj_Instrutor.Per_Instrutor += "1";
            }
            else
            {
                obj_Instrutor.Per_Instrutor += "0";
            }

            if (ckbox_Noite.Checked)
            {
                obj_Instrutor.Per_Instrutor += "1";
            }
            else
            {
                obj_Instrutor.Per_Instrutor += "0";
            }



            return obj_Instrutor;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *       Descrição: Responsável por popular o Formulário
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        private void PopulaForm(Instrutor pobj_Instrutor)
        {
            EventArgs e = new EventArgs();

            tbox_Cod_Instrutor.Text = pobj_Instrutor.Cod_Instrutor.ToString();
            tbox_Nm_Pessoa.Text = pobj_Instrutor.Nm_Pessoa;

            tbox_CPF_Pessoa.Text = pobj_Instrutor.CPF_Pessoa;
            tbox_Cel_Pessoa.Text = pobj_Instrutor.Cel_Pessoa;
            tbox_Mail_Pessoa.Text = pobj_Instrutor.Mail_Pessoa;
            tbox_End_Pessoa.Text = pobj_Instrutor.End_Pessoa;
            tbox_Bai_Pessoa.Text = pobj_Instrutor.Bai_Pessoa;
            tbox_Cid_Pessoa.Text = pobj_Instrutor.Cid_Pessoa;
            tbox_UF_Pessoa.Text = pobj_Instrutor.UF_Pessoa;
            tbox_CEP_Pessoa.Text = pobj_Instrutor.CEP_Pessoa;
            tbox_CPF_Pessoa.Text = pobj_Instrutor.CPF_Pessoa;

            ckbox_Manha.Checked = pobj_Instrutor.Per_Instrutor.Substring(0, 1) == "1";
            ckbox_Tarde.Checked = pobj_Instrutor.Per_Instrutor.Substring(1, 1) == "1";
            ckbox_Noite.Checked = pobj_Instrutor.Per_Instrutor.Substring(2, 1) == "1";
        }





    }
}
