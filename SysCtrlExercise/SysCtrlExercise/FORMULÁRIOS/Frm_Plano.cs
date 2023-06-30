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
    public partial class Frm_Plano : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Plano obj_Plano_Atual = new Plano();

        public Frm_Plano()
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
            tbox_Nm_Plano.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Plano.Focus();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDPlano obj_BDPlano = new BDPlano();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg_Resp == DialogResult.Yes)
            {
                if (obj_BDPlano.Excluir(obj_Plano_Atual))
                {
                    MessageBox.Show("O Plano " + obj_Plano_Atual.Nm_Plano + " foi excluido com sucesso.",
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

            if (obj_Plano_Atual.Cod_Plano != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Plano_Atual);
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
            BDPlano obj_BDPlano = new BDPlano();

            obj_Plano_Atual = PopulaObjeto();

            if (obj_Plano_Atual.Cod_Plano != -1)
            {
                if (obj_BDPlano.Alterar(obj_Plano_Atual))
                {
                    MessageBox.Show("O Plano " + obj_Plano_Atual.Nm_Plano + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Plano_Atual.Cod_Plano = obj_BDPlano.Incluir(obj_Plano_Atual);
                PopulaForm(obj_Plano_Atual);
                MessageBox.Show("O Plano " + obj_Plano_Atual.Nm_Plano + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Planos_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDPlano obj_BDPlano = new BDPlano();
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
                obj_Plano_Atual.Cod_Plano = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Plano_Atual = obj_BDPlano.FindByCod(obj_Plano_Atual);
                PopulaForm(obj_Plano_Atual);
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
            BDPlano obj_BDPlano = new BDPlano();

            //instancia a lista 
            List<Plano> obj_Lista = new List<Plano>();

            lbox_Planos.Items.Clear();

            obj_Lista = obj_BDPlano.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Planos.Items.Add(obj_Lista[i].Cod_Plano.ToString() + "-" + obj_Lista[i].Nm_Plano);
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
        private Plano PopulaObjeto()
        {
            //instancia do objeto 
            Plano obj_Plano = new Plano();

            if (tbox_Cod_Plano.Text != "")
            {
                obj_Plano.Cod_Plano = Convert.ToInt16(tbox_Cod_Plano.Text);
            }

            obj_Plano.Nm_Plano = tbox_Nm_Plano.Text;
            obj_Plano.Desc_Plano = tbox_Desc_Plano.Text;
            obj_Plano.Vlr_Plano = Convert.ToDouble(tbox_Vlr_Plano.Text);

            return obj_Plano;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *       Descrição: Responsável por popular o Formulário
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        private void PopulaForm(Plano pobj_Plano)
        {
            tbox_Cod_Plano.Text = pobj_Plano.Cod_Plano.ToString();
            tbox_Nm_Plano.Text = pobj_Plano.Nm_Plano;
            tbox_Desc_Plano.Text = pobj_Plano.Desc_Plano;
            tbox_Vlr_Plano.Text = pobj_Plano.Vlr_Plano.ToString();
        }

        private void pnl_Titulos_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tbox_Cod_Plano_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
