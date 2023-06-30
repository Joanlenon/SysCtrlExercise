/********************************************************************
 *  Nome da Classe: Instrutor
 *       Descrição: Esta classe de objeto representa a Objeto Instrutor 
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
    public class Instrutor: Pessoa
    {
        //Método Destruct
        ~Instrutor()
        {

        }

        #region Atributos Privados
        private int v_Cod_Instrutor = -1;
        private String v_Per_Instrutor = "";
        #endregion

        #region Atributos Privados
        public int Cod_Instrutor 
        { 
            get => v_Cod_Instrutor; 
            set => v_Cod_Instrutor = value; 
        }
        public String Per_Instrutor 
        { 
            get => v_Per_Instrutor; 
            set => v_Per_Instrutor = value; 
        }
        #endregion
    }
}
