/********************************************************************
 *  Nome da Classe: BDAcompanhamento
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodAcompanhamento e 
 *                  FindAllAcompanhamento
 *     Dt. Criação: 15/05/2023
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
    class BDAcompanhamento
    {
        //Metodo Destruct
        ~BDAcompanhamento()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Acompanhamento na TB_ACOMPANHAMENTO.
        *       Parametro: Objeto Acompanhamento
        *         Retorno: Código do Acompanhamento (PK)
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public int Incluir(Acompanhamento pobj_Acompanhamento)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_ACOMPANHAMENTO " +
                           " ( " +
                           " I_COD_CLIENTE, " +
                           " I_COD_INSTRUTOR,  " +
                           " D_PESO_ACOMPANHAMENTO, " +
                           " D_ALT_ACOMPANHAMENTO, " +
                           " DT_AFER_ACOMPANHAMENTO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_CLIENTE, " +
                           " @I_COD_INSTRUTOR,  " +
                           " @D_PESO_ACOMPANHAMENTO, " +
                           " @D_ALT_ACOMPANHAMENTO, " +
                           " @DT_AFER_ACOMPANHAMENTO " +
                           " ) " +
                           " SELECT IDENT_CURRENT('TB_ACOMPANHAMENTO') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Acompanhamento.Cod_Cliente);
            obj_Com.Parameters.AddWithValue("@I_COD_INSTRUTOR", pobj_Acompanhamento.Cod_Instrutor);
            obj_Com.Parameters.AddWithValue("@D_PESO_ACOMPANHAMENTO", pobj_Acompanhamento.Peso_Acompanhamento);
            obj_Com.Parameters.AddWithValue("@D_ALT_ACOMPANHAMENTO", pobj_Acompanhamento.Alt_Acompanhamento);
            obj_Com.Parameters.AddWithValue("@DT_AFER_ACOMPANHAMENTO", pobj_Acompanhamento.Afer_Acompanhamento);


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
                return pobj_Acompanhamento.Cod_Acompanhamento;
            }

        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Acompanhamento na TB_ACOMPANHAMENTO.
        *       Parametro: Objeto Acompanhamento
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Alterar(Acompanhamento pobj_Acompanhamento)
        {
            if (pobj_Acompanhamento.Cod_Acompanhamento != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_ACOMPANHAMENTO SET " +
                               " I_COD_CLIENTE          = @I_COD_CLIENTE, " +
                               " I_COD_INSTRUTOR        = @I_COD_INSTRUTOR, " +
                               " D_PESO_ACOMPANHAMENTO  = @D_PESO_ACOMPANHAMENTO, " +
                               " D_ALT_ACOMPANHAMENTO   = @D_ALT_ACOMPANHAMENTO, " +
                               " DT_AFER_ACOMPANHAMENTO = @DT_AFER_ACOMPANHAMENTO " +
                               " WHERE I_COD_ACOMPANHAMENTO = @I_COD_ACOMPANHAMENTO ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_ACOMPANHAMENTO", pobj_Acompanhamento.Cod_Acompanhamento );
                obj_Com.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Acompanhamento.Cod_Cliente);
                obj_Com.Parameters.AddWithValue("@I_COD_INSTRUTOR", pobj_Acompanhamento.Cod_Instrutor);
                obj_Com.Parameters.AddWithValue("@D_PESO_ACOMPANHAMENTO", pobj_Acompanhamento.Peso_Acompanhamento);
                obj_Com.Parameters.AddWithValue("@D_ALT_ACOMPANHAMENTO", pobj_Acompanhamento.Alt_Acompanhamento);
                obj_Com.Parameters.AddWithValue("@DT_AFER_ACOMPANHAMENTO", pobj_Acompanhamento.Afer_Acompanhamento);


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
        *                  Acompanhamento na TB_ACOMPANHAMENTO.
        *       Parametro: Objeto Acompanhamento
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Excluir(Acompanhamento pobj_Acompanhamento)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_ACOMPANHAMENTO " +
                           " WHERE I_COD_ACOMPANHAMENTO = @I_COD_ACOMPANHAMENTO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_ACOMPANHAMENTO", pobj_Acompanhamento.Cod_Acompanhamento);

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
        *                  Acompanhamento na TB_ACOMPANHAMENTO.
        *       Parametro: Objeto Acompanhamento
        *         Retorno: Acompanhamento
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public Acompanhamento FindByCod(Acompanhamento pobj_Acompanhamento)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_ACOMPANHAMENTO " +
                           " WHERE I_COD_ACOMPANHAMENTO = @I_COD_ACOMPANHAMENTO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_ACOMPANHAMENTO", pobj_Acompanhamento.Cod_Acompanhamento);
            

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Acompanhamento.Cod_Cliente = Convert.ToInt16(obj_Dtr["@I_COD_CLIENTE"].ToString());
                    pobj_Acompanhamento.Cod_Instrutor = Convert.ToInt16(obj_Dtr["@I_COD_INSTRUTOR"].ToString());
                    pobj_Acompanhamento.Peso_Acompanhamento = Convert.ToDouble(obj_Dtr["@D_PESO_ACOMPANHAMENTO"].ToString());
                    pobj_Acompanhamento.Alt_Acompanhamento = Convert.ToDouble(obj_Dtr["@D_ALT_ACOMPANHAMENTO"].ToString());
                    pobj_Acompanhamento.Afer_Acompanhamento = Convert.ToDateTime(obj_Dtr["@DT_AFER_ACOMPANHAMENTO"].ToString());
                    
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Acompanhamento;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Acompanhamento();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Acompanhamento();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Acompanhamentos na TB_ACOMPANHAMENTO.
        *       Parametro: -
        *         Retorno: Lista<Acompanhamento>
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public List<Acompanhamento> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_ACOMPANHAMENTO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Acompanhamento> Lst_Acompanhamento = new List<Acompanhamento>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Acompanhamento obj_Acompanhamento = new Acompanhamento();

                        obj_Acompanhamento.Cod_Acompanhamento = Convert.ToInt16(obj_Dtr["I_COD_ACOMPANHAMENTO"].ToString());
                        obj_Acompanhamento.Cod_Cliente = Convert.ToInt16(obj_Dtr["@I_COD_CLIENTE"].ToString());
                        obj_Acompanhamento.Cod_Instrutor = Convert.ToInt16(obj_Dtr["@I_COD_INSTRUTOR"].ToString());
                        obj_Acompanhamento.Peso_Acompanhamento = Convert.ToDouble(obj_Dtr["@D_PESO_ACOMPANHAMENTO"].ToString());
                        obj_Acompanhamento.Alt_Acompanhamento = Convert.ToDouble(obj_Dtr["@D_ALT_ACOMPANHAMENTO"].ToString());
                        obj_Acompanhamento.Afer_Acompanhamento = Convert.ToDateTime(obj_Dtr["@DT_AFER_ACOMPANHAMENTO"].ToString());

                        Lst_Acompanhamento.Add(obj_Acompanhamento);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Acompanhamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Acompanhamento>();
            }
        }
    }
}
