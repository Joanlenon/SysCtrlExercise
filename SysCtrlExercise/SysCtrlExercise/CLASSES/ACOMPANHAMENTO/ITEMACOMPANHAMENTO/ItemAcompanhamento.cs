/********************************************************************
 *  Nome da Classe: ItemAcompanhamento
 *       Descrição: Esta classe de objeto representa a Objeto ItemAcompanhamento 
 *     Dt. Criação: 03/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por: mFacine (Monstro)
 ********************************************************************/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCtrlExercise
{
    class ItemAcompanhamento
    {
        //Método Destruct
        ~ItemAcompanhamento()
        {

        }
        #region Atributos Privados
        private int v_Cod_ItemAcompanhamento = -1; 
        private int v_Cod_Acompanhamento = -1;
        private double v_Peito_ItemAcompanhamento = 0;
        private double v_Coxd_ItemAcompanhamento = 0;
        private double v_Coxe_ItemAcompanhamento = 0;
        private double v_Bicpd_ItemAcompanhamento = 0;
        private double v_Bicpe_ItemAcompanhamento = 0;
        private double v_Pantud_ItemAcompanhamento = 0;
        private double v_Pantue_ItemAcompanhamento = 0;
        #endregion

        #region Métodos Públicos
        public int Cod_ItemAcompanhamento 
        { 
            get => v_Cod_ItemAcompanhamento; 
            set => v_Cod_ItemAcompanhamento = value; 
        }
        public int Cod_Acompanhamento 
        { 
            get => v_Cod_Acompanhamento; 
            set => v_Cod_Acompanhamento = value; 
        }
        public double Peito_ItemAcompanhamento 
        { 
            get => v_Peito_ItemAcompanhamento; 
            set => v_Peito_ItemAcompanhamento = value; 
        }
        public double Coxd_ItemAcompanhamento 
        { 
            get => v_Coxd_ItemAcompanhamento; 
            set => v_Coxd_ItemAcompanhamento = value; 
        }
        public double Coxe_ItemAcompanhamento 
        { 
            get => v_Coxe_ItemAcompanhamento; 
            set => v_Coxe_ItemAcompanhamento = value; 
        }
        public double Bicpd_ItemAcompanhamento 
        { 
            get => v_Bicpd_ItemAcompanhamento; 
            set => v_Bicpd_ItemAcompanhamento = value; 
        }
        public double Bicpe_ItemAcompanhamento 
        { 
            get => v_Bicpe_ItemAcompanhamento; 
            set => v_Bicpe_ItemAcompanhamento = value; 
        }
        public double Pantud_ItemAcompanhamento 
        { 
            get => v_Pantud_ItemAcompanhamento; 
            set => v_Pantud_ItemAcompanhamento = value; 
        }
        public double Pantue_ItemAcompanhamento 
        { 
            get => v_Pantue_ItemAcompanhamento; 
            set => v_Pantue_ItemAcompanhamento = value; 
        }
        #endregion
    }
}
