/********************************************************************
 *  Nome da Classe: Plano
 *       Descrição: Esta classe de objeto representa a Objeto Plano 
 *     Dt. Criação: 02/05/2023
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
    public class Plano
    {
        //Método Destruct
        ~Plano()
        {

        }

        #region Atributos Privados
        private int v_Cod_Plano = -1;
        private string v_Nm_Plano = "";
        private string v_Desc_Plano = "";
        private double v_Vlr_Plano = 0;
        #endregion

        #region Métodos Publicos
        public int    Cod_Plano 
        { 
            get => v_Cod_Plano; 
            set => v_Cod_Plano = value; 
        }
        public string Nm_Plano 
        { 
            get => v_Nm_Plano; 
            set => v_Nm_Plano = value; 
        }
        public string Desc_Plano 
        { 
            get => v_Desc_Plano; 
            set => v_Desc_Plano = value; 
        }
        public double Vlr_Plano 
        { 
            get => v_Vlr_Plano; 
            set => v_Vlr_Plano = value; 
        }
        #endregion
    }
}
