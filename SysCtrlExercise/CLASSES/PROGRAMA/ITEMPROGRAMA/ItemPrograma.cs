/********************************************************************
 *  Nome da Classe: ItemPrograma
 *       Descrição: Esta classe de objeto representa a Objeto ItemPrograma 
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
    class ItemPrograma
    {
        //Método Destruct
        ~ItemPrograma()
        {

        }

        private int v_Cod_ItemPrograma = -1;
        private int v_Cod_Programa = -1;
        private int v_Cod_Aparelho = -1;
        private string v_Nm_ItemPrograma = "";
        private string v_Rep_ItemPrograma = "";

        public int Cod_ItemPrograma 
        { 
            get => v_Cod_ItemPrograma; 
            set => v_Cod_ItemPrograma = value; 
        }
        public int Cod_Programa 
        { 
            get => v_Cod_Programa; 
            set => v_Cod_Programa = value; 
        }
        public int Cod_Aparelho 
        { 
            get => v_Cod_Aparelho; 
            set => v_Cod_Aparelho = value; 
        }
        public string Nm_ItemPrograma 
        { 
            get => v_Nm_ItemPrograma; 
            set => v_Nm_ItemPrograma = value; 
        }
        public string Rep_ItemPrograma 
        { 
            get => v_Rep_ItemPrograma; 
            set => v_Rep_ItemPrograma = value; 
        }
    }
}
