/********************************************************************
 *  Nome da Classe: BDPessoa
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodPessoa e 
 *                  FindAllPessoa
 *     Dt. Criação: 08/05/2023
 *   Dt. Alteração: --/--/---- ( -- )
 *      Criada por:Lenon's 
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
    class BDPessoa
    {
        //Metodo Destruct
        ~BDPessoa()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Pessoa na TB_PESSOA.
        *       Parametro: Objeto Pessoa
        *         Retorno: Código do Pessoa (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public int Incluir(Pessoa pobj_Pessoa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_PESSOA " +
                           " ( " +
                           " S_NM_PESSOA, " +
                           " I_GEN_PESSOA, " +
                           " S_CPF_PESSOA, " +
                           " S_CEL_PESSOA, " +
                           " S_MAIL_PESSOA, " +
                           " S_END_PESSOA, " +
                           " S_BAI_PESSOA, " +
                           " S_CID_PESSOA, " +
                           " S_UF_PESSOA, " +
                           " S_CEP_PESSOA, " +
                           " I_TP_PESSOA " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_PESSOA, " +
                           " @I_GEN_PESSOA, " +
                           " @S_CPF_PESSOA, " +
                           " @S_CEL_PESSOA, " +
                           " @S_MAIL_PESSOA, " +
                           " @S_END_PESSOA, " +
                           " @S_BAI_PESSOA, " +
                           " @S_CID_PESSOA, " +
                           " @S_UF_PESSOA, " +
                           " @S_CEP_PESSOA, " +
                           " @I_TP_PESSOA " +
                           " ) " +
                           " SELECT IDENT_CURRENT('TB_PESSOA') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@S_NM_PESSOA", pobj_Pessoa.Nm_Pessoa);
            obj_Com.Parameters.AddWithValue("@I_GEN_PESSOA", pobj_Pessoa.Gen_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_CPF_PESSOA", pobj_Pessoa.CPF_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_CEL_PESSOA", pobj_Pessoa.Cel_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_MAIL_PESSOA", pobj_Pessoa.Mail_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_END_PESSOA", pobj_Pessoa.End_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_BAI_PESSOA", pobj_Pessoa.Bai_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_CID_PESSOA", pobj_Pessoa.Cid_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_UF_PESSOA", pobj_Pessoa.UF_Pessoa);
            obj_Com.Parameters.AddWithValue("@S_CEP_PESSOA", pobj_Pessoa.Cel_Pessoa);
            obj_Com.Parameters.AddWithValue("@I_TP_PESSOA", pobj_Pessoa.Tp_Pessoa);

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
                return pobj_Pessoa.Cod_Pessoa;
            }

        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Pessoa na TB_PESSOA.
        *       Parametro: Objeto Pessoa
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Alterar(Pessoa pobj_Pessoa)
        {
            if (pobj_Pessoa.Cod_Pessoa != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_PESSOA SET " +
                               " S_NM_PESSOA   = @S_NM_PESSOA, "+
                               " I_GEN_PESSOA  = @I_GEN_PESSOA, "+
                               " S_CPF_PESSOA  = @S_CPF_PESSOA, "+
                               " S_CEL_PESSOA  = @S_CEL_PESSOA, "+
                               " S_MAIL_PESSOA = @S_MAIL_PESSOA, "+
                               " S_END_PESSOA  = @S_END_PESSOA, "+
                               " S_BAI_PESSOA  = @S_BAI_PESSOA, "+
                               " S_CID_PESSOA  = @S_CID_PESSOA, "+
                               " S_UF_PESSOA   = @S_UF_PESSOA, "+
                               " S_CEP_PESSOA  = @S_CEP_PESSOA, "+
                               " I_TP_PESSOA  = @I_TP_PESSOA " +
                               " WHERE I_COD_PESSOA = @I_COD_PESSOA ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_NM_PESSOA", pobj_Pessoa.Nm_Pessoa);
                obj_Com.Parameters.AddWithValue("@I_GEN_PESSOA", pobj_Pessoa.Gen_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_CPF_PESSOA", pobj_Pessoa.CPF_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_CEL_PESSOA", pobj_Pessoa.Cel_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_MAIL_PESSOA", pobj_Pessoa.Mail_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_END_PESSOA", pobj_Pessoa.End_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_BAI_PESSOA", pobj_Pessoa.Bai_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_CID_PESSOA", pobj_Pessoa.Cid_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_UF_PESSOA", pobj_Pessoa.UF_Pessoa);
                obj_Com.Parameters.AddWithValue("@S_CEP_PESSOA", pobj_Pessoa.Cel_Pessoa);
                obj_Com.Parameters.AddWithValue("@I_TP_PESSOA", pobj_Pessoa.Tp_Pessoa);

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
        *                  Pessoa na TB_PESSOA.
        *       Parametro: Objeto Pessoa
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Excluir(Pessoa pobj_Pessoa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_PESSOA " +
                           " WHERE I_COD_PESSOA = @I_COD_PESSOA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);

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
        *                  Pessoa na TB_PESSOA.
        *       Parametro: Objeto Pessoa
        *         Retorno: Pessoa
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public Pessoa FindByCod(Pessoa pobj_Pessoa)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PESSOA " +
                           " WHERE I_COD_PESSOA = @I_COD_PESSOA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Pessoa.Cod_Pessoa);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Pessoa.Nm_Pessoa = obj_Dtr["S_NM_PESSOA"].ToString();
                    pobj_Pessoa.Gen_Pessoa = Convert.ToInt16(obj_Dtr["I_GEN_PESSOA"].ToString());
                    pobj_Pessoa.CPF_Pessoa = obj_Dtr["S_CPF_PESSOA"].ToString();
                    pobj_Pessoa.CEP_Pessoa = obj_Dtr["S_CEL_PESSOA"].ToString();
                    pobj_Pessoa.Mail_Pessoa = obj_Dtr["S_MAIL_PESSOA"].ToString();
                    pobj_Pessoa.End_Pessoa = obj_Dtr["S_END_PESSOA"].ToString();
                    pobj_Pessoa.Bai_Pessoa = obj_Dtr["S_BAI_PESSOA"].ToString();
                    pobj_Pessoa.Cid_Pessoa = obj_Dtr["S_CID_PESSOA"].ToString();
                    pobj_Pessoa.UF_Pessoa = obj_Dtr["S_UF_PESSOA"].ToString();
                    pobj_Pessoa.CEP_Pessoa = obj_Dtr["S_CEP_PESSOA"].ToString();
                    pobj_Pessoa.Tp_Pessoa = Convert.ToInt16(obj_Dtr["I_TP_PESSOA"].ToString());

                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Pessoa;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Pessoa();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Pessoa();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Pessoas na TB_PESSOA.
        *       Parametro: -
        *         Retorno: Lista<Pessoa>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public List<Pessoa> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PESSOA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Pessoa> Lst_Pessoa = new List<Pessoa>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Pessoa obj_Pessoa = new Pessoa();

                        obj_Pessoa.Nm_Pessoa = obj_Dtr["@S_NM_PESSOA"].ToString();
                        obj_Pessoa.Gen_Pessoa = Convert.ToInt16(obj_Dtr["@I_GEN_PESSOA"].ToString());
                        obj_Pessoa.CPF_Pessoa = obj_Dtr["@S_CPF_PESSOA"].ToString();
                        obj_Pessoa.CEP_Pessoa = obj_Dtr["@S_CEL_PESSOA"].ToString();
                        obj_Pessoa.Mail_Pessoa = obj_Dtr["@S_MAIL_PESSOA"].ToString();
                        obj_Pessoa.End_Pessoa = obj_Dtr["@S_END_PESSOA"].ToString();
                        obj_Pessoa.Bai_Pessoa = obj_Dtr["@S_BAI_PESSOA"].ToString();
                        obj_Pessoa.Cid_Pessoa = obj_Dtr["@S_CID_PESSOA"].ToString();
                        obj_Pessoa.UF_Pessoa = obj_Dtr["@S_UF_PESSOA"].ToString();
                        obj_Pessoa.CEP_Pessoa = obj_Dtr["@S_CEP_PESSOA"].ToString();
                        obj_Pessoa.Tp_Pessoa = Convert.ToInt16(obj_Dtr["@I_TP_PESSOA"].ToString());

                        Lst_Pessoa.Add(obj_Pessoa);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Pessoa;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Pessoa>();
            }
        }
    }
}
