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
    public partial class Frm_Aparelho : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Aparelho obj_Aparelho_Atual = new Aparelho();

        public Frm_Aparelho()
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
            tbox_Nm_Aparelho.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Aparelho.Focus();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDAparelho obj_BDAparelho = new BDAparelho();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); 

            if (dlg_Resp == DialogResult.Yes)
            {
                if (obj_BDAparelho.Excluir(obj_Aparelho_Atual))
                {
                    MessageBox.Show("O Aparelho " + obj_Aparelho_Atual.Nm_Aparelho +" foi excluido com sucesso.",
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

            if (obj_Aparelho_Atual.Cod_Aparelho != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Aparelho_Atual);
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
            BDAparelho obj_BDAparelho = new BDAparelho();

            obj_Aparelho_Atual = PopulaObjeto();

            if (obj_Aparelho_Atual.Cod_Aparelho != -1)
            {
                if (obj_BDAparelho.Alterar(obj_Aparelho_Atual))
                {
                    MessageBox.Show("O Aparelho " + obj_Aparelho_Atual.Nm_Aparelho + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Aparelho_Atual.Cod_Aparelho = obj_BDAparelho.Incluir(obj_Aparelho_Atual);
                PopulaForm(obj_Aparelho_Atual);
                MessageBox.Show("O Aparelho " + obj_Aparelho_Atual.Nm_Aparelho + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Aparelhos_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDAparelho obj_BDAparelho = new BDAparelho();
                string s_Lin = ((ListBox)sender).Items[((ListBox)sender).SelectedIndex].ToString();
                int i_Pos = 0;
                
                for (int i = 0; i < s_Lin.Length; i++)
                {
                    if (s_Lin.Substring(i,1) == "-")
                    {
                        i_Pos = i;
                        break;
                    }
                }
                obj_Aparelho_Atual.Cod_Aparelho = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Aparelho_Atual = obj_BDAparelho.FindByCod(obj_Aparelho_Atual);
                PopulaForm(obj_Aparelho_Atual);
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
            BDAparelho obj_BDAparelho = new BDAparelho();

            //instancia a lista 
            List<Aparelho> obj_Lista = new List<Aparelho>();

            lbox_Aparelhos.Items.Clear();

            obj_Lista = obj_BDAparelho.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Aparelhos.Items.Add(obj_Lista[i].Cod_Aparelho.ToString() + "-" + obj_Lista[i].Nm_Aparelho);
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
        private Aparelho PopulaObjeto()
        {
            //instancia do objeto 
            Aparelho obj_Aparelho = new Aparelho();

            if (tbox_Cod_Aparelho.Text != "")
            {
                obj_Aparelho.Cod_Aparelho = Convert.ToInt16(tbox_Cod_Aparelho.Text);
            }
            
            obj_Aparelho.Nm_Aparelho = tbox_Nm_Aparelho.Text;

            if (ckbox_Superior.Checked)
            {
                obj_Aparelho.Grup_Aparelho += 1;
            }
            else
            {
                obj_Aparelho.Grup_Aparelho += 0;
            }

            if (ckbox_Inferior.Checked)
            {
                obj_Aparelho.Grup_Aparelho += 1;
            }
            else
            {
                obj_Aparelho.Grup_Aparelho += 0;
            }

            if (ckbox_Tronco.Checked)
            {
                obj_Aparelho.Grup_Aparelho += 1;
            }
            else
            {
                obj_Aparelho.Grup_Aparelho += 0;
            }
            return obj_Aparelho;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *       Descrição: Responsável por popular o Formulário
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        private void PopulaForm(Aparelho pobj_Aparelho)
        {
            tbox_Cod_Aparelho.Text = pobj_Aparelho.Cod_Aparelho.ToString();
            tbox_Nm_Aparelho.Text = pobj_Aparelho.Nm_Aparelho;
            ckbox_Superior.Checked = pobj_Aparelho.Grup_Aparelho.Substring(0, 1) == "1";
            ckbox_Inferior.Checked = pobj_Aparelho.Grup_Aparelho.Substring(1, 1) == "1";
            ckbox_Tronco.Checked = pobj_Aparelho.Grup_Aparelho.Substring(2, 1) == "1";
        }


    }
}
