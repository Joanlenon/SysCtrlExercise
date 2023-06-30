/********************************************************************
 *  Nome da Classe: Cliente
 *       Descrição: Esta classe de objeto representa a Objeto Cliete 
 *     Dt. Criação: 03/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por: mFacine (Monstro)
 ********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCtrlExercise
{
    public class Cliente: Pessoa
    {
        //Método Destruct
        ~Cliente()
        {

        }

        #region Atributos Privados
        private int v_Cod_Cliente = -1;
        private int v_Cod_Plano = -1;
        private int v_Cod_Convenio = -1;
        private string v_Mat_Cliente = "";
        #endregion

        #region Metodos Publicos
        public int Cod_Cliente 
        { 
            get => v_Cod_Cliente; 
            set => v_Cod_Cliente = value; 
        }
        
        public int  Cod_Convenio 
        { 
            get => v_Cod_Convenio; 
            set => v_Cod_Convenio = value; 
        }

        public int Cod_Plano
        {
            get => v_Cod_Plano;
            set => v_Cod_Plano = value;
        }

        public string Mat_Cliente 
        { 
            get => v_Mat_Cliente; 
            set => v_Mat_Cliente = value; 
        }
        #endregion
    }
}
