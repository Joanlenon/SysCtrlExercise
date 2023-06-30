/********************************************************************
 *  Nome da Classe: BDPlano
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodPlano e 
 *                  FindAllPlano
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
    class BDPlano
    {
        //Metodo Destruct
        ~BDPlano()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Plano na TB_PLANO.
        *       Parametro: Objeto Plano
        *         Retorno: Código do Plano (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public int Incluir(Plano pobj_Plano)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_PLANO " +
                           " ( " +
                           " S_NM_PLANO, " +
                           " S_DESC_PLANO, " +
                           " D_VLR_PLANO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_PLANO, " +
                           " @S_DESC_PLANO, " +
                           " @D_VLR_PLANO " +
                           " ) " +
                           " SELECT IDENT_CURRENT('TB_PLANO') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@S_NM_PLANO", pobj_Plano.Nm_Plano);
            obj_Com.Parameters.AddWithValue("@S_DESC_PLANO", pobj_Plano.Desc_Plano);
            obj_Com.Parameters.AddWithValue("@D_VLR_PLANO", pobj_Plano.Vlr_Plano);

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
                return pobj_Plano.Cod_Plano;
            }

        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Plano na TB_PLANO.
        *       Parametro: Objeto Plano
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Alterar(Plano pobj_Plano)
        {
            if (pobj_Plano.Cod_Plano != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_PLANO SET " +
                               " S_NM_PLANO  = @S_NM_PLANO,  " +
                               " D_VLR_PLANO= @D_VLR_PLANO " +
                               " WHERE I_COD_PLANO = @I_COD_PLANO ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_PLANO", pobj_Plano.Cod_Plano);
                obj_Com.Parameters.AddWithValue("@S_NM_PLANO", pobj_Plano.Nm_Plano);
                obj_Com.Parameters.AddWithValue("@S_DESC_PLANO", pobj_Plano.Desc_Plano);
                obj_Com.Parameters.AddWithValue("@D_VLR_PLANO", pobj_Plano.Vlr_Plano);

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
        *                  Plano na TB_PLANO.
        *       Parametro: Objeto Plano
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Excluir(Plano pobj_Plano)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_PLANO " +
                           " WHERE I_COD_PLANO = @I_COD_PLANO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PLANO", pobj_Plano.Cod_Plano);

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
        *                  Plano na TB_PLANO.
        *       Parametro: Objeto Plano
        *         Retorno: Plano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public Plano FindByCod(Plano pobj_Plano)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PLANO " +
                           " WHERE I_COD_PLANO = @I_COD_PLANO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PLANO", pobj_Plano.Cod_Plano);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Plano.Nm_Plano = obj_Dtr["S_NM_PLANO"].ToString();
                    pobj_Plano.Desc_Plano = obj_Dtr["S_DESC_PLANO"].ToString();
                    pobj_Plano.Vlr_Plano = Convert.ToDouble(obj_Dtr["D_VLR_PLANO"].ToString());

                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Plano;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Plano();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Plano();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Planos na TB_PLANO.
        *       Parametro: -
        *         Retorno: Lista<Plano>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public List<Plano> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_PLANO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Plano> Lst_Plano = new List<Plano>();

                if (obj_Dtr.HasRows)
                {
                    while (obj_Dtr.Read())
                    {
                        Plano obj_Plano = new Plano();

                        obj_Plano.Cod_Plano = Convert.ToInt16(obj_Dtr["I_COD_PLANO"].ToString());
                        obj_Plano.Nm_Plano = obj_Dtr["S_NM_PLANO"].ToString();
                        obj_Plano.Desc_Plano = obj_Dtr["S_DESC_PLANO"].ToString();
                        obj_Plano.Vlr_Plano = Convert.ToDouble(obj_Dtr["D_VLR_PLANO"].ToString());

                        Lst_Plano.Add(obj_Plano);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Plano;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Plano>();
            }
        }
    }
}
