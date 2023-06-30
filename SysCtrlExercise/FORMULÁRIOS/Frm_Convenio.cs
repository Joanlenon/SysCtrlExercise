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
    public partial class Frm_Convenio : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        public Convenio obj_Convenio_Atual = new Convenio();

        public Frm_Convenio()
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
            tbox_Nm_Convenio.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
            tbox_Nm_Convenio.Focus();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDConvenio obj_BDConvenio = new BDConvenio();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg_Resp == DialogResult.Yes)
            {
                if (obj_BDConvenio.Excluir(obj_Convenio_Atual))
                {
                    MessageBox.Show("O Convenio " + obj_Convenio_Atual.Nm_Convenio + " foi excluido com sucesso.",
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

            if (obj_Convenio_Atual.Cod_Convenio != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Convenio_Atual);
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
            BDConvenio obj_BDConvenio = new BDConvenio();

            obj_Convenio_Atual = PopulaObjeto();

            if (obj_Convenio_Atual.Cod_Convenio != -1)
            {
                if (obj_BDConvenio.Alterar(obj_Convenio_Atual))
                {
                    MessageBox.Show("O Convenio " + obj_Convenio_Atual.Nm_Convenio + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Convenio_Atual.Cod_Convenio = obj_BDConvenio.Incluir(obj_Convenio_Atual);
                PopulaForm(obj_Convenio_Atual);
                MessageBox.Show("O Convenio " + obj_Convenio_Atual.Nm_Convenio + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Convenios_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDConvenio obj_BDConvenio = new BDConvenio();
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
                obj_Convenio_Atual.Cod_Convenio = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Convenio_Atual = obj_BDConvenio.FindByCod(obj_Convenio_Atual);
                PopulaForm(obj_Convenio_Atual);
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
            BDConvenio obj_BDConvenio = new BDConvenio();

            //instancia a lista 
            List<Convenio> obj_Lista = new List<Convenio>();

            lbox_Convenios.Items.Clear();

            obj_Lista = obj_BDConvenio.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Convenios.Items.Add(obj_Lista[i].Cod_Convenio.ToString() + "-" + obj_Lista[i].Nm_Convenio);
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
        private Convenio PopulaObjeto()
        {
            //instancia do objeto 
            Convenio obj_Convenio = new Convenio();

            if (tbox_Cod_Convenio.Text != "")
            {
                obj_Convenio.Cod_Convenio = Convert.ToInt16(tbox_Cod_Convenio.Text);
            }

            obj_Convenio.Nm_Convenio = tbox_Nm_Convenio.Text;
            obj_Convenio.Nro_Convenio = tbox_Nro_Convenio.Text;

            if (rdbtn_Particular.Checked)
            {
                obj_Convenio.Tp_Convenio = 0;
            }
            else
            {
                obj_Convenio.Tp_Convenio = 1;
            }

            obj_Convenio.Cat_Convenio = cbbox_Cat_Convenio.Text;

            return obj_Convenio;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *       Descrição: Responsável por popular o Formulário
        *     Dt. Criação: 22/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        private void PopulaForm(Convenio pobj_Convenio)
        {
            tbox_Cod_Convenio.Text = pobj_Convenio.Cod_Convenio.ToString();
            tbox_Nm_Convenio.Text = pobj_Convenio.Nm_Convenio;
            tbox_Nro_Convenio.Text = pobj_Convenio.Nro_Convenio;

            if (pobj_Convenio.Tp_Convenio == 0)
            {
                rdbtn_Particular.Checked = true;
            }
            else
            {
                rdbtn_Empresa.Checked = true;
            }

            cbbox_Cat_Convenio.Text = pobj_Convenio.Cat_Convenio;
        }


    }
}
