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
    public partial class Frm_Programa : Form
    {
        FuncGeral obj_FuncGeral = new FuncGeral();
        Programa obj_Programa_Atual = new Programa();
        

        public Frm_Programa()
        {
            InitializeComponent();
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 1);
            PopulaLista();
            lview_TiTulos();
        }
        private void lview_TiTulos()
        {
            lview_ItemPrograma.View = View.Details;
            lview_ItemPrograma.Columns.Add("Códigos", 80);
            lview_ItemPrograma.Columns.Add("Aparelho", 160);
            lview_ItemPrograma.Columns.Add("Nome Exercicio", 160);
            lview_ItemPrograma.Columns.Add("Repetições", 80);
        }

        private void btn_Novo_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.LimpaForm(this);
            obj_FuncGeral.StatusBtn(this, 3);
           tbox_Cod_Programa.Focus();
        }

        private void btn_Alterar_Click(object sender, EventArgs e)
        {
            obj_FuncGeral.HabilitaForm(this, true);
            obj_FuncGeral.StatusBtn(this, 3);
           tbox_Cod_Programa.Focus();
        }

        private void btn_Excluir_Click(object sender, EventArgs e)
        {
            BDPrograma obj_BDPrograma = new BDPrograma();
            BDCliente obj_BDCliente = new BDCliente();
            Cliente obj_Cliente = new Cliente();

            DialogResult dlg_Resp = MessageBox.Show("Confirma a Exclusão?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (dlg_Resp == DialogResult.Yes)
            {

                obj_Cliente.Cod_Cliente = obj_Programa_Atual.Cod_Cliente;
                obj_BDCliente.Excluir(obj_Cliente);


                if (obj_BDPrograma.Excluir(obj_Programa_Atual))
                {
                    MessageBox.Show("O Programa " + obj_Programa_Atual.Nm_Programa + " foi excluido com sucesso.",
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

            if (obj_Programa_Atual.Cod_Programa != -1)
            {
                obj_FuncGeral.StatusBtn(this, 2);
                PopulaForm(obj_Programa_Atual);
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
            BDPrograma obj_BDPrograma = new BDPrograma();

            obj_Programa_Atual = PopulaObjeto();

            if (obj_Programa_Atual.Cod_Programa != -1)
            {
                if (obj_BDPrograma.Alterar(obj_Programa_Atual))
                {
                    MessageBox.Show("O Programa " + obj_Programa_Atual.Nm_Programa + " foi Alterado com sucesso.",
                       "Alteração", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                obj_Programa_Atual.Cod_Programa = obj_BDPrograma.Incluir(obj_Programa_Atual);
                PopulaForm(obj_Programa_Atual);
                MessageBox.Show("O Programa " + obj_Programa_Atual.Nm_Programa + " foi Incluido com sucesso.",
                       "Inclusão", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            obj_FuncGeral.HabilitaForm(this, false);
            obj_FuncGeral.StatusBtn(this, 2);
            PopulaLista();
        }

        private void lbox_Programas_Click(object sender, EventArgs e)
        {
            if (((ListBox)sender).SelectedIndex != -1)
            {
                BDPrograma obj_BDPrograma = new BDPrograma();
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
                obj_Programa_Atual.Cod_Programa = Convert.ToInt16(s_Lin.Substring(0, i_Pos));
                obj_Programa_Atual = obj_BDPrograma.FindByCod(obj_Programa_Atual);
                PopulaForm(obj_Programa_Atual);
                obj_FuncGeral.HabilitaForm(this, false);
                obj_FuncGeral.StatusBtn(this, 2);
            }
        }

        /********************************************************************
        *  Nome do Método: PopulaLista
        *  Descrição: Responsável por popular o listbox com os registros 
        *                  cadastrados no BD
        *   Dt. Criação:05/06/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *   
        *      Criada por:Lenon's 
        ********************************************************************/
        private void PopulaLista()
        {
            //instancia do objeto BD
            BDPrograma obj_BDPrograma = new BDPrograma();

            //instancia a lista 
            List<Programa> obj_Lista = new List<Programa>();

            lbox_Programas.Items.Clear();

            obj_Lista = obj_BDPrograma.FindAll();

            if (obj_Lista != null)
            {
                for (int i = 0; i < obj_Lista.Count; i++)
                {
                    lbox_Programas.Items.Add(obj_Lista[i].Cod_Programa.ToString() + "-" + obj_Lista[i].Nm_Programa);
                }
            }
        }

        /********************************************************************
        *  Nome do Método: PopulaObjeto
        *  Descrição: Responsável por popular o objeto Atual
        *  
        *   Dt. Criação: 05/06/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        private Programa PopulaObjeto()
        {
            //instancia do objeto 
            Programa obj_Programa = new Programa();

            if (tbox_Cod_Programa.Text != "")
            {
                obj_Programa.Cod_Programa = Convert.ToInt16(tbox_Cod_Programa.Text);
            }


            obj_Programa.Cod_Cliente = Convert.ToInt16( obj_Programa_Atual.Cod_Cliente);
            obj_Programa.Cod_Instrutor = Convert.ToInt16( obj_Programa_Atual.Cod_Instrutor);

            obj_Programa.Nm_Programa =tbox_Cod_Programa.Text;

          
            obj_Programa.Ini_Programa = Convert.ToDateTime( tbox_Ini_Programa.Text);
            obj_Programa.Rep_Programa = Convert.ToInt16( tbox_Rep_Programa.Text);
         

            return obj_Programa;
        }


        /********************************************************************
        *  Nome do Método: PopulaForm
        *  Descrição: Responsável por popular o Formulário
        *  
        *   Dt. Criação: 05/06/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        private void PopulaForm(Programa pobj_Programa)
        {
            EventArgs e = new EventArgs();

            tbox_Cod_Programa.Text = pobj_Programa.Cod_Programa.ToString();
           
          tbox_Cod_Cliente.Text = pobj_Programa.Cod_Cliente.ToString();
          tbox_Cod_Cliente_Leave(tbox_Cod_Cliente, e); 

          tbox_Cod_Instrutor.Text = pobj_Programa.Cod_Instrutor.ToString(); 
          tbox_Cod_Instrutor_Leave(tbox_Cod_Instrutor, e);

          tbox_Nm_Programa.Text = pobj_Programa.Nm_Programa;

          tbox_Ini_Programa.Text = pobj_Programa.Ini_Programa.ToString("dd/MM/yyyy");

          tbox_Rep_Programa.Text = pobj_Programa.Rep_Programa.ToString();
            


        }

        private void tbox_Cod_Cliente_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                Cliente obj_Cliente = new Cliente();
                BDCliente obj_BDCliente = new BDCliente();

                obj_Cliente.Cod_Cliente = Convert.ToInt16(((TextBox)sender).Text);


                if (int.TryParse(((TextBox)sender).Text, out int Cod))
                {
                    obj_Cliente.Cod_Cliente = Cod;
                }

                obj_Cliente = obj_BDCliente.FindByCod(obj_Cliente);

                lb_Nm_Cliente.Text = obj_Cliente.Nm_Pessoa;
            }
        }

        private void tbox_Cod_Instrutor_Leave(object sender, EventArgs e)
        {
            if (((TextBox)sender).Text != "")
            {
                Instrutor obj_Instrutor = new Instrutor();
                BDInstrutor obj_BDInstrutor = new BDInstrutor();

                if (int.TryParse(((TextBox)sender).Text, out int Cod))
                {
                    obj_Instrutor.Cod_Instrutor = Cod;
                }

                obj_Instrutor = obj_BDInstrutor.FindByCod(obj_Instrutor);

                lb_Nm_Instrutor.Text = obj_Instrutor.Nm_Pessoa;
            }
        }

       
            


        private void btn_Instrutor_Click(object sender, EventArgs e)
        {
            Frm_Instrutor obj_Frm_Instrutor = new Frm_Instrutor();
            obj_Frm_Instrutor.ShowDialog();
            if (obj_Frm_Instrutor.obj_Instrutor_Atual.Cod_Instrutor != -1)
            {
                tbox_Cod_Instrutor.Text = obj_Frm_Instrutor.obj_Instrutor_Atual.Cod_Instrutor.ToString();
                tbox_Cod_Instrutor_Leave(tbox_Cod_Instrutor, e);
            }


        }

        private void btn_Cliente_MouseClick(object sender, MouseEventArgs e)
        {
            Frm_Cliente obj_Frm_Cliente = new Frm_Cliente();
            obj_Frm_Cliente.FormClosed += Obj_Frm_Cliente_FormClosed; // Adicione o manipulador de eventos
            obj_Frm_Cliente.ShowDialog();

            if (obj_Frm_Cliente.obj_Cliente_Atual.Cod_Cliente != -1)
            {
                tbox_Cod_Cliente.Text = obj_Frm_Cliente.obj_Cliente_Atual.Cod_Cliente.ToString();
                tbox_Cod_Cliente_Leave(tbox_Cod_Cliente, e);
            }
        }
            private void Obj_Frm_Cliente_FormClosed(object sender, FormClosedEventArgs e)
            {
                Frm_Cliente obj_Frm_Cliente = (Frm_Cliente)sender;
                obj_Frm_Cliente.FormClosed -= Obj_Frm_Cliente_FormClosed; // Remova o manipulador de eventos
                obj_Frm_Cliente.Dispose(); // Libere os recursos do formulário cliente
            }

       

        private void lview_Titulos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

       


        private void tb_Nm_Aparelho_Leave(object sender, EventArgs e)
        {

        }

        private void btn_Aparelho_Click(object sender, EventArgs e)
        {
            Frm_Aparelho obj_Frm_Aparelho = new Frm_Aparelho();
            obj_Frm_Aparelho.ShowDialog();
            if (obj_Frm_Aparelho.obj_Aparelho_Atual.Cod_Aparelho != -1)
            {
                tbox_Cod_Aparelho.Text = obj_Frm_Aparelho.obj_Aparelho_Atual.Cod_Aparelho.ToString();
                lb_Nm_Aparelho_Leave(tbox_Cod_Aparelho, e);
            }
        }

        private void lb_Nm_Aparelho_Leave(object sender, EventArgs e)
        {

            if (((TextBox)sender).Text != "")
            {
                Aparelho obj_Aparelho = new Aparelho();
                BDAparelho obj_BDAparelho = new BDAparelho();

                if (int.TryParse(((TextBox)sender).Text, out int Cod))
                {
                    obj_Aparelho.Cod_Aparelho = Cod;
                }

                obj_Aparelho = obj_BDAparelho.FindByCod(obj_Aparelho);

                lb_Nm_Aparelho.Text = obj_Aparelho.Nm_Aparelho;
            }
        }

        private void btn_Down_Click(object sender, EventArgs e)
        {
            BDAparelho obj_BDAparelho = new BDAparelho();
            Aparelho obj_Aparelho = new Aparelho();

            obj_Aparelho.Cod_Aparelho = Convert.ToInt16(tbox_Nm_ItemPrograma.Text);
            obj_Aparelho = obj_BDAparelho.FindByCod(obj_Aparelho);

            PopulaLinha(lview_ItemPrograma, tbox_Nm_ItemPrograma.Text, obj_Aparelho.Cod_Aparelho.ToString(), obj_Aparelho.Nm_Aparelho, tbox_Rep_ItemPrograma.Text);

            tbox_Nm_ItemPrograma.Clear();
            tbox_Cod_Aparelho.Clear();
            lb_Nm_Aparelho.Text = "";
            tbox_Rep_ItemPrograma.Clear();



        }
        private void PopulaLinha(ListView plview, string pNmItemPrograma, string pcodAparelho, string pNmAparelho, String pRepeticoes)
        {
            ListViewItem item = new ListViewItem(new[] {pNmAparelho, pcodAparelho,pNmItemPrograma,pRepeticoes});
            plview.Items.Add(item);
        }

        private void btn_Up_Click(object sender, EventArgs e)
        {
            if (lview_ItemPrograma.SelectedItems != null)
            {
                var vConfirma = MessageBox.Show("deseja retirar este item da lista ?","Atenção",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                
                if (vConfirma == DialogResult.Yes)
                {
                    for(int i = 0; i < lview_ItemPrograma.Items.Count; i++) 
                    {
                        if (lview_ItemPrograma.Items[i].Selected)
                        {
                            tbox_Nm_ItemPrograma.Text = lview_ItemPrograma.Items[i].SubItems[0].Text;
                            tbox_Cod_Aparelho.Text = lview_ItemPrograma.Items[i].SubItems[1].Text;
                            lb_Nm_Aparelho.Text = lview_ItemPrograma.Items[i].SubItems[2].Text;
                            tbox_Rep_ItemPrograma.Text = lview_ItemPrograma.Items[i].SubItems[3].Text;
                            lview_ItemPrograma.Items[i].Remove();
                            i--;
                        }
                    }

                }

            }
            
        }
    }
}
