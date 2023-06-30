/********************************************************************
 *  Nome da Classe: BDPrograma
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodPrograma e 
 *                  FindAllPrograma
 *     Dt. Criação: 15/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por: mFacine (Monstro)
 ********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace SysCtrlExercise
{
    class BDPrograma
    {
        //Metodo Destruct
        ~BDPrograma()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Programa na TB_PROGRAMA.
        *       Parametro: Objeto Programa
        *         Retorno: Código do Programa (PK)
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public int Incluir(Programa pobj_Programa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_PROGRAMA " +
                           " ( " +
                           " I_COD_CLIENTE, " +
                           " I_COD_INSTRUTOR,  " +
                           " S_NM_PROGRAMA, " +
                           " DT_INI_PROGRAMA, " +
                           " I_REP_PROGRAMA " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_CLIENTE, " +
                           " @I_COD_INSTRUTOR,  " +
                           " @S_NM_PROGRAMA, " +
                           " @DT_INI_PROGRAMA, " +
                           " @I_REP_PROGRAMA " +
                           " ) " +
                           " SELECT IDENT_CURRENT('TB_PROGRAMA') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("I_COD_CLIENTE", pobj_Programa.Cod_Cliente);
            obj_Com.Parameters.AddWithValue("I_COD_INSTRUTOR", pobj_Programa.Cod_Instrutor);
            obj_Com.Parameters.AddWithValue("S_NM_PROGRAMA", pobj_Programa.Nm_Programa);
            obj_Com.Parameters.AddWithValue("DT_INI_PROGRAMA", pobj_Programa.Ini_Programa );
            obj_Com.Parameters.AddWithValue("I_REP_PROGRAMA", pobj_Programa.Rep_Programa);


            try
            {
                obj_Conn.Open();
                int i_Cod = Convert.ToInt16(obj_Com.ExecuteScalar());
                obj_Conn.Close();
                return i_Cod;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO INCLUIR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Programa.Cod_Programa;
            }

        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Programa na TB_PROGRAMA.
        *       Parametro: Objeto Programa
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Alterar(Programa pobj_Programa)
        {
            if (pobj_Programa.Cod_Programa != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_PROGRAMA SET " +
                               " I_COD_CLIENTE    = @I_COD_CLIENTE, " +
                               " I_COD_INSTRUTOR  = @I_COD_INSTRUTOR, " +
                               " D_PESO_PROGRAMA  = @D_PESO_PROGRAMA, " +
                               " D_ALT_PROGRAMA   = @D_ALT_PROGRAMA, " +
                               " DT_AFER_PROGRAMA = @DT_AFER_PROGRAMA " +
                               " WHERE I_COD_PROGRAMA = @I_COD_PROGRAMA ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_PROGRAMA", pobj_Programa.Cod_Programa);
                obj_Com.Parameters.AddWithValue("I_COD_CLIENTE", pobj_Programa.Cod_Cliente);
                obj_Com.Parameters.AddWithValue("I_COD_INSTRUTOR", pobj_Programa.Cod_Instrutor);
                obj_Com.Parameters.AddWithValue("S_NM_PROGRAMA", pobj_Programa.Nm_Programa);
                obj_Com.Parameters.AddWithValue("DT_INI_PROGRAMA", pobj_Programa.Ini_Programa);
                obj_Com.Parameters.AddWithValue("I_REP_PROGRAMA", pobj_Programa.Rep_Programa);


                try
                {
                    obj_Conn.Open();
                    obj_Com.ExecuteNonQuery();
                    obj_Conn.Close();
                    return true;
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message, "ERRO AO ALTERAR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        /********************************************************************
        *  Nome do Método: Excluir
        *       Descrição: Responsável por Excluir o Registro (Tupla) do 
        *                  Programa na TB_PROGRAMA.
        *       Parametro: Objeto Programa
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Excluir(Programa pobj_Programa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_PROGRAMA " +
                           " WHERE I_COD_PROGRAMA = @I_COD_PROGRAMA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PROGRAMA", pobj_Programa.Cod_Programa);

            try
            {
                obj_Conn.Open();
                obj_Com.ExecuteNonQuery();
                obj_Conn.Close();
                return true;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO EXCLUIR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }


        /********************************************************************
        *  Nome do Método: FindByCod
        *       Descrição: Responsável por Encontrar o Registro (Tupla) do 
        *                  Programa na TB_PROGRAMA.
        *       Parametro: Objeto Programa
        *         Retorno: Programa
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public Programa FindByCod(Programa pobj_Programa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PROGRAMA " +
                           " WHERE I_COD_PROGRAMA = @I_COD_PROGRAMA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PROGRAMA", pobj_Programa.Cod_Programa);
            

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Programa.Cod_Cliente = Convert.ToInt16(obj_Dtr["@I_COD_CLIENTE"].ToString());
                    pobj_Programa.Cod_Instrutor = Convert.ToInt16(obj_Dtr["@I_COD_INSTRUTOR"].ToString());
                    pobj_Programa.Nm_Programa = obj_Dtr["@S_NM_PROGRAMA"].ToString();
                    pobj_Programa.Ini_Programa = Convert.ToDateTime(obj_Dtr["@DT_INI_PROGRAMA"].ToString());
                    pobj_Programa.Rep_Programa = Convert.ToInt16(obj_Dtr["@I_REP_PROGRAMA"].ToString());
                    
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Programa;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Programa();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Programa();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Programas na TB_PROGRAMA.
        *       Parametro: -
        *         Retorno: Lista<Programa>
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public List<Programa> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PROGRAMA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Programa> Lst_Programa = new List<Programa>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Programa obj_Programa = new Programa();

                        obj_Programa.Cod_Programa = Convert.ToInt16(obj_Dtr["I_COD_PROGRAMA"].ToString());
                        obj_Programa.Cod_Cliente = Convert.ToInt16(obj_Dtr["@I_COD_CLIENTE"].ToString());
                        obj_Programa.Cod_Instrutor = Convert.ToInt16(obj_Dtr["@I_COD_INSTRUTOR"].ToString());
                        obj_Programa.Nm_Programa = obj_Dtr["@S_NM_PROGRAMA"].ToString();
                        obj_Programa.Ini_Programa = Convert.ToDateTime(obj_Dtr["@DT_INI_PROGRAMA"].ToString());
                        obj_Programa.Rep_Programa = Convert.ToInt16(obj_Dtr["@I_REP_PROGRAMA"].ToString());

                        Lst_Programa.Add(obj_Programa);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Programa;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Programa>();
            }
        }
    }
}
