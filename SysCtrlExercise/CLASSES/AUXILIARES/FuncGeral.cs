/********************************************************************
 *  Nome da Classe: FuncGeral
 *       Descrição: Esta classe é responsável por todas as funções e 
 *                  procedimentos coletivos
 *     Dt. Criação: 17/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por:Lenon's 
 ********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysCtrlExercise
{
    internal class FuncGeral
    {
        /********************************************************************
        *  Nome do Método: HabilitaForm
        *       Descrição: Responsável por Habilitar os componentes editáveis 
        *                  no formulário
        *       Parametro: Formulário e Booleana
        *     Dt. Criação: 17/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public void HabilitaForm(Form pobj_Form, bool pb_Habilita)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhes")
                {
                    foreach (Control obj in pnl.Controls)
                    {
                        if (obj is TextBox && Convert.ToInt16(obj.Tag) != 1)
                        {
                            ((TextBox)obj).Enabled = pb_Habilita;
                        }

                        if (obj is CheckBox)
                        {
                            ((CheckBox)obj).Enabled = pb_Habilita;
                        }

                        if (obj is Button && Convert.ToInt16(obj.Tag) != 1)
                        {
                            ((Button)obj).Enabled = pb_Habilita;
                        }

                        if (obj is RadioButton)
                        {
                            ((RadioButton)obj).Enabled = pb_Habilita;
                        }
                    }
                }
            }
        }


        /********************************************************************
        *  Nome do Método: LimpaForm
        *       Descrição: Responsável por Limpar os componentes editáveis 
        *                  no formulário
        *       Parametro: Formulário
        *     Dt. Criação: 17/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public void LimpaForm(Form pobj_Form)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Detalhes")
                {
                    foreach (Control obj in pnl.Controls)
                    {
                        if (obj is TextBox)
                        {
                            ((TextBox)obj).Clear();
                        }

                        if (obj is CheckBox)
                        {
                            ((CheckBox)obj).Checked = false;
                        }

                        if (obj is Label && Convert.ToInt16(obj.Tag) == 1)
                        {
                            ((Label)obj).Tag = "";
                        }

                        
                    }
                }
            }
        }


        /********************************************************************
        *  Nome do Método: StatusBtn
        *       Descrição: Responsável por organizar os botões do formulário
        *       Parametro: Formulário e status
        *     Dt. Criação: 17/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public void StatusBtn(Form pobj_Form, int pi_Status)
        {
            foreach (Control pnl in pobj_Form.Controls)
            {
                if (pnl is Panel && pnl.Name == "pnl_Botoes")
                {
                    foreach (Control obj in pnl.Controls)
                    {
                        switch (pi_Status)
                        {
                            case 1:
                                {
                                    if (((Button)obj).Name == "btn_Novo")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }

                                    if (((Button)obj).Name == "btn_Alterar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Excluir")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Confirmar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Cancelar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }
                                    break;
                                }

                            case 2:
                                {
                                    if (((Button)obj).Name == "btn_Novo")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }

                                    if (((Button)obj).Name == "btn_Alterar")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }

                                    if (((Button)obj).Name == "btn_Excluir")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }

                                    if (((Button)obj).Name == "btn_Confirmar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Cancelar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }
                                    break;
                                }

                            case 3:
                                {
                                    if (((Button)obj).Name == "btn_Novo")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Alterar")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Excluir")
                                    {
                                        ((Button)obj).Enabled = false;
                                    }

                                    if (((Button)obj).Name == "btn_Confirmar")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }

                                    if (((Button)obj).Name == "btn_Cancelar")
                                    {
                                        ((Button)obj).Enabled = true;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }



    }
}
