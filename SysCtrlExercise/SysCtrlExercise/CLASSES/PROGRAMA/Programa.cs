/********************************************************************
 *  Nome da Classe: Programa
 *       Descrição: Esta classe de objeto representa a Objeto Programa
 *                  com duas associações em outros objetos.
 *     Associações: Cliente/Instrutor                
 *     Dt. Criação: 02/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por: mFacine (Monstro)
 ********************************************************************/using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysCtrlExercise
{
    class Programa
    {
        //Método Destruct
        ~Programa()
        {

        }

        #region Atributos Privados
        private int v_Cod_Programa = -1;
        private int v_Cod_Cliente = -1;
        private int v_Cod_Instrutor = -1;
        private string v_Nm_Programa = "";
        private DateTime v_Ini_Programa = DateTime.MinValue;
        private int v_Rep_Programa = 0;

        private List<ItemPrograma> Lst_ItProg = new List<ItemPrograma>();
        #endregion

        #region Métodos Publicos
        public int Cod_Programa
        {
            get => v_Cod_Programa;
            set => v_Cod_Programa = value;
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
        public string Nm_Programa
        {
            get => v_Nm_Programa;
            set => v_Nm_Programa = value;
        }
        public DateTime Ini_Programa
        {
            get => v_Ini_Programa;
            set => v_Ini_Programa = value;
        }
        public int Rep_Programa
        {
            get => v_Rep_Programa;
            set => v_Rep_Programa = value;
        }

        public List<ItemPrograma> Lst_ItemPrograma
        {
            get => Lst_ItProg;
            set => Lst_ItProg = value;
        }
     

        #endregion
    }
}
