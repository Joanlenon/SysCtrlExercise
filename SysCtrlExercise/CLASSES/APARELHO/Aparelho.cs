/********************************************************************
 *  Nome da Classe: Aparelho
 *       Descrição: Esta classe de objeto representa a Objeto Aparelho 
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
    public class Aparelho
    {
        //Método Destruct
        ~Aparelho()
        {

        }

        #region Atributos Privados
        private int v_Cod_Aparelho = -1;
        private string v_Nm_Aparelho = "";
        private string v_Grup_Aparelho = "";
        #endregion

        #region Métodos Públicos
        public int Cod_Aparelho 
        { 
            get => v_Cod_Aparelho; 
            set => v_Cod_Aparelho = value; 
        }
        public string Nm_Aparelho 
        { 
            get => v_Nm_Aparelho; 
            set => v_Nm_Aparelho = value; 
        }
        public string Grup_Aparelho 
        { 
            get => v_Grup_Aparelho; 
            set => v_Grup_Aparelho = value; 
        }
        #endregion
    }
}
