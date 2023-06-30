/********************************************************************
 *  Nome da Classe: BDAparelho
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodAparelho e 
 *                  FindAllAparelho
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
    class BDAparelho

    {
        //Metodo Destruct
        ~BDAparelho()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Aparelho na TB_APARELHO.
        *       Parametro: Objeto Aparelho
        *         Retorno: Código do Aparelho (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public int Incluir(Aparelho pobj_Aparelho)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_APARELHO " +
                           " ( " +
                           " S_NM_APARELHO, " +
                           " S_GRUP_APARELHO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_APARELHO, " +
                           " @S_GRUP_APARELHO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_APARELHO') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@S_NM_APARELHO", pobj_Aparelho.Nm_Aparelho);
            obj_Com.Parameters.AddWithValue("@S_GRUP_APARELHO", pobj_Aparelho.Grup_Aparelho);

            try
            {
                obj_Conn.Open();
                int i_Cod = Convert.ToInt16(obj_Com.ExecuteScalar());
                obj_Conn.Close();
                return i_Cod;
            }
            catch(Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO INCLUIR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return pobj_Aparelho.Cod_Aparelho;
            }
            
        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Aparelho na TB_APARELHO.
        *       Parametro: Objeto Aparelho
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Alterar(Aparelho pobj_Aparelho)
        {
            if (pobj_Aparelho.Cod_Aparelho != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_APARELHO SET " +
                               " S_NM_APARELHO  = @S_NM_APARELHO,  " +
                               " S_GRUP_APARELHO= @S_GRUP_APARELHO " +
                               " WHERE I_COD_APARELHO = @I_COD_APARELHO ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_APARELHO", pobj_Aparelho.Cod_Aparelho);
                obj_Com.Parameters.AddWithValue("@S_NM_APARELHO", pobj_Aparelho.Nm_Aparelho);
                obj_Com.Parameters.AddWithValue("@S_GRUP_APARELHO", pobj_Aparelho.Grup_Aparelho);

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
        *                  Aparelho na TB_APARELHO.
        *       Parametro: Objeto Aparelho
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Excluir(Aparelho pobj_Aparelho)
        {
            
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_APARELHO " +
                           " WHERE I_COD_APARELHO = @I_COD_APARELHO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_APARELHO", pobj_Aparelho.Cod_Aparelho);
            
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
        *                  Aparelho na TB_APARELHO.
        *       Parametro: Objeto Aparelho
        *         Retorno: Aparelho
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public Aparelho FindByCod(Aparelho pobj_Aparelho)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_APARELHO " +
                           " WHERE I_COD_APARELHO = @I_COD_APARELHO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_APARELHO", pobj_Aparelho.Cod_Aparelho);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Aparelho.Nm_Aparelho = obj_Dtr["S_NM_APARELHO"].ToString();
                    pobj_Aparelho.Grup_Aparelho = obj_Dtr["S_GRUP_APARELHO"].ToString();

                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Aparelho;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Aparelho();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Aparelho();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Aparelhos na TB_APARELHO.
        *       Parametro: -
        *         Retorno: Lista<Aparelho>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public List<Aparelho> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_APARELHO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            
            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Aparelho> Lst_Aparelho = new List<Aparelho>();

                if (obj_Dtr.HasRows)
                {
                    while(obj_Dtr.Read())
                    {
                        Aparelho obj_Aparelho = new Aparelho();

                        obj_Aparelho.Cod_Aparelho = Convert.ToInt16(obj_Dtr["I_COD_APARELHO"].ToString());
                        obj_Aparelho.Nm_Aparelho = obj_Dtr["S_NM_APARELHO"].ToString();
                        obj_Aparelho.Grup_Aparelho = obj_Dtr["S_GRUP_APARELHO"].ToString();

                        Lst_Aparelho.Add(obj_Aparelho);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Aparelho;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Aparelho>();
            }
        }
    }
}
