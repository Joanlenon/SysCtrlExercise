/********************************************************************
 *  Nome da Classe: BDInstrutor
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodInstrutor e 
 *                  FindAllInstrutor
 *     Dt. Criação: 08/05/2023
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
    class BDInstrutor
    {
        //Metodo Destruct
        ~BDInstrutor()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Instrutor na TB_INSTRUTOR.
        *       Parametro: Objeto Instrutor
        *         Retorno: Código do Instrutor (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public int Incluir(Instrutor pobj_Instrutor)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_INSTRUTOR " +
                           " ( " +
                           " I_COD_PESSOA, " +
                           " S_PER_INSTRUTOR " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_PESSOA, " +
                           " @S_PER_INSTRUTOR " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_INSTRUTOR') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("I_COD_PESSOA", pobj_Instrutor.Cod_Pessoa);
            obj_Com.Parameters.AddWithValue("S_PER_INSTRUTOR", pobj_Instrutor.Per_Instrutor);

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
                return pobj_Instrutor.Cod_Instrutor;
            }

        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Instrutor na TB_INSTRUTOR.
        *       Parametro: Objeto Instrutor
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Alterar(Instrutor pobj_Instrutor)
        {
            if (pobj_Instrutor.Cod_Instrutor != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_INSTRUTOR SET " +
                               " I_COD_PESSOA   = @I_COD_PESSOA, " +
                               " S_PER_INSTRUTOR = @S_PER_INSTRUTOR " +
                               " WHERE I_COD_INSTRUTOR = @I_COD_INSTRUTOR ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("I_COD_PESSOA", pobj_Instrutor.Cod_Pessoa);
                obj_Com.Parameters.AddWithValue("S_PER_INSTRUTOR", pobj_Instrutor.Per_Instrutor);

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
        *                  Instrutor na TB_INSTRUTOR.
        *       Parametro: Objeto Instrutor
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Excluir(Instrutor pobj_Instrutor)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_INSTRUTOR " +
                           " WHERE I_COD_INSTRUTOR = @I_COD_INSTRUTOR ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_INSTRUTOR", pobj_Instrutor.Cod_Instrutor);

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
        *                  Instrutor na TB_INSTRUTOR.
        *       Parametro: Objeto Instrutor
        *         Retorno: Instrutor
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public Instrutor FindByCod(Instrutor pobj_Instrutor)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_INSTRUTOR " +
                           " WHERE I_COD_INSTRUTOR = @I_COD_INSTRUTOR ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_INSTRUTOR", pobj_Instrutor.Cod_Instrutor);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Instrutor.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"].ToString());
                    pobj_Instrutor.Per_Instrutor = obj_Dtr["S_PER_INSTRUTOR"].ToString();
                    

                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Instrutor;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Instrutor();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Instrutor();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Instrutors na TB_INSTRUTOR.
        *       Parametro: -
        *         Retorno: Lista<Instrutor>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public List<Instrutor> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_INSTRUTOR ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Instrutor> Lst_Instrutor = new List<Instrutor>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Instrutor obj_Instrutor = new Instrutor();

                        obj_Instrutor.Cod_Instrutor = Convert.ToInt16(obj_Dtr["I_COD_INSTRUTOR"].ToString());
                        obj_Instrutor.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"].ToString());
                        obj_Instrutor.Per_Instrutor =obj_Dtr["S_PER_INSTRUTOR"].ToString();

                        Lst_Instrutor.Add(obj_Instrutor);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Instrutor;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Instrutor>();
            }
        }
    }
}
