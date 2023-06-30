/********************************************************************
 *  Nome da Classe: Acompanhamento
 *       Descrição: Esta classe de objeto representa a Objeto Acompanhamento 
 *     Dt. Criação: 03/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por:Lenon's 
 ********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCtrlExercise
{
    internal class Acompanhamento
    {
        //Método Destruct
        ~Acompanhamento()
        {

        }

        #region Atributos Privados
        private int v_Cod_Acompanhamento = -1;
        private int v_Cod_Cliente = -1;
        private int v_Cod_Instrutor = -1;
        private double v_Peso_Acompanhamento = 0;
        private double v_Alt_Acompanhamento = 0;
        private DateTime v_Afer_Acompanhamento = DateTime.MinValue;

        private List<ItemAcompanhamento> Lst_ItAcomp = new List<ItemAcompanhamento>();

        #endregion

        #region Métodos Públicos
        public int Cod_Acompanhamento 
        { 
            get => v_Cod_Acompanhamento; 
            set => v_Cod_Acompanhamento = value; 
        }
        public int Cod_Cliente 
        { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value; 
        }
        public int Cod_Instrutor 
        { 
            get => v_Cod_Instrutor; 
            set => v_Cod_Instrutor = value; 
        }
        public double Peso_Acompanhamento 
        { 
            get => v_Peso_Acompanhamento; 
            set => v_Peso_Acompanhamento = value; 
        }
        public double Alt_Acompanhamento 
        { 
            get => v_Alt_Acompanhamento; 
            set => v_Alt_Acompanhamento = value; 
        }
        public DateTime Afer_Acompanhamento 
        { 
            get => v_Afer_Acompanhamento; 
            set => v_Afer_Acompanhamento = value; 
        }

        public List<ItemAcompanhamento> Lst_ItemAcompanhamento
        {
            get => Lst_ItAcomp;
            set => Lst_ItAcomp = value;
        }


        #endregion
    }
}
