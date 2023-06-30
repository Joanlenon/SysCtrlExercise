/********************************************************************
 *  Nome da Classe: Pessoa
 *       Descrição: Esta classe de objeto representa a Objeto Pessoa 
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

    //protected
    public class Pessoa
    {
        //Método Destruct
        ~Pessoa()
        {

        }

        #region Atributos Privados
        private int v_Cod_Pessoa = -1;
        private string v_Nm_Pessoa = "";
        private int v_Gen_Pessoa = 0;
        private string v_CPF_Pessoa = "";
        private string v_Cel_Pessoa = "";
        private string v_Mail_Pessoa = "";
        private string v_End_Pessoa = "";
        private string v_Bai_Pessoa = "";
        private string v_Cid_Pessoa = "";
        private string v_UF_Pessoa = "";
        private string v_CEP_Pessoa = "";
        private int v_Tp_Pessoa = 99;
        #endregion

        #region Métodos Publicos
        public int Cod_Pessoa
        {
            get => v_Cod_Pessoa;
            set => v_Cod_Pessoa = value;
        }

        public string Nm_Pessoa
        {
            get => v_Nm_Pessoa;
            set => v_Nm_Pessoa = value;
        }

        public int Gen_Pessoa
        {
            get => v_Gen_Pessoa;
            set => v_Gen_Pessoa = value;
        }

        public string CPF_Pessoa
        {
            get => v_CPF_Pessoa;
            set => v_CPF_Pessoa = value;
        }

        public string Cel_Pessoa
        {
            get => v_Cel_Pessoa;
            set => v_Cel_Pessoa = value;
        }

        public string Mail_Pessoa
        {
            get => v_Mail_Pessoa;
            set => v_Mail_Pessoa = value;
        }

        public string End_Pessoa
        {
            get => v_End_Pessoa;
            set => v_End_Pessoa = value;
        }

        public string Bai_Pessoa
        {
            get => v_Bai_Pessoa;
            set => v_Bai_Pessoa = value;
        }

        public string Cid_Pessoa
        {
            get => v_Cid_Pessoa;
            set => v_Cid_Pessoa = value;
        }

        public string UF_Pessoa
        {
            get => v_UF_Pessoa;
            set => v_UF_Pessoa = value;
        }

        public string CEP_Pessoa
        {
            get => v_CEP_Pessoa;
            set => v_CEP_Pessoa = value;
        }
        
        public int Tp_Pessoa 
        { 
            get => v_Tp_Pessoa; 
            set => v_Tp_Pessoa = value; 
        }
        #endregion
    }
}
