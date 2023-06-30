/********************************************************************
 *  Nome da Classe: Convenio
 *       Descrição: Esta classe de objeto representa a Objeto Convenio 
 *     Dt. Criação: 02/05/2023
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
    public class Convenio
    {
        //Método Destruct
        ~Convenio()
        {

        }

        #region Atributos Privados
        private int v_Cod_Convenio = -1;
        private string v_Nm_Convenio = "";
        private string v_Nro_Convenio = "";
        private int v_Tp_Convenio = 0;
        private string v_Cat_Convenio = "";
        #endregion

        #region Métodos Publicos
        public int Cod_Convenio
        {
            get => v_Cod_Convenio;
            set => v_Cod_Convenio = value;
        }

        public string Nm_Convenio
        {
            get => v_Nm_Convenio;
            set => v_Nm_Convenio = value;
        }

        public string Nro_Convenio
        {
            get => v_Nro_Convenio;
            set => v_Nro_Convenio = value;
        }

        public int Tp_Convenio
        {
            get => v_Tp_Convenio;
            set => v_Tp_Convenio = value;
        }

        public string Cat_Convenio
        {
            get => v_Cat_Convenio;
            set => v_Cat_Convenio = value;
        }
        #endregion
    }
}
