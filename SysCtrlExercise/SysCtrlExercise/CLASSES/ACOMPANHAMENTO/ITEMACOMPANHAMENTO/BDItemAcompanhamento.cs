/********************************************************************
 *  Nome da Classe: BDItemAcompanhamento
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodItemAcompanhamento e 
 *                  FindAllItemAcompanhamento
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
    class BDItemAcompanhamento
    {
        //Metodo Destruct
        ~BDItemAcompanhamento()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  ItemAcompanhamento na TB_ITEMACOMPANHAMENTO.
        *       Parametro: Objeto ItemAcompanhamento
        *         Retorno: Código do ItemAcompanhamento (PK)
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public int Incluir(ItemAcompanhamento pobj_ItemAcompanhamento)
        {
            

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_ITEMACOMPANHAMENTO " +
                           " ( " +
                           " I_COD_ACOMPANHAMENTO, " +
                           " D_PEITO_ITEMACOMPANHAMENTO, " +
                           " D_COXD_ITEMACOMPANHAMENTO, " +
                           " D_COXE_ITEMACOMPANHAMENTO, " +
                           " D_BICPD_ITEMACOMPANHAMENTO, " +
                           " D_BICPE_ITEMACOMPANHAMENTO, " +
                           " D_PANTD_ITEMACOMPANHAMENTO, " +
                           " D_PANTE_ITEMACOMPANHAMENTO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_ACOMPANHAMENTO, " +
                           " @D_PEITO_ITEMACOMPANHAMENTO, " +
                           " @D_COXD_ITEMACOMPANHAMENTO, " +
                           " @D_COXE_ITEMACOMPANHAMENTO, " +
                           " @D_BICPD_ITEMACOMPANHAMENTO, " +
                           " @D_BICPE_ITEMACOMPANHAMENTO, " +
                           " @D_PANTD_ITEMACOMPANHAMENTO, " +
                           " @D_PANTE_ITEMACOMPANHAMENTO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_ITEMACOMPANHAMENTO') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("I_COD_ACOMPANHAMENTO", pobj_ItemAcompanhamento.Cod_Acompanhamento);
            obj_Com.Parameters.AddWithValue("D_PEITO_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Peito_ItemAcompanhamento);
            obj_Com.Parameters.AddWithValue("D_COXD_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Coxd_ItemAcompanhamento);
            obj_Com.Parameters.AddWithValue("D_COXE_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Coxe_ItemAcompanhamento);
            obj_Com.Parameters.AddWithValue("D_BICPD_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Bicpd_ItemAcompanhamento);
            obj_Com.Parameters.AddWithValue("D_BICPE_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Bicpe_ItemAcompanhamento );
            obj_Com.Parameters.AddWithValue("D_PANTD_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Pantud_ItemAcompanhamento);
            obj_Com.Parameters.AddWithValue("D_PANTE_ITEMACOMPANHAMENTO", pobj_ItemAcompanhamento.Pantue_ItemAcompanhamento);

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
                return pobj_ItemAcompanhamento.Cod_ItemAcompanhamento;
            }
            
        }



        /********************************************************************
        *  Nome do Método: ExcluirByAcompanhamento
        *       Descrição: Responsável por Excluir o Registro (Tupla) do 
        *                  ItemAcompanhamento na TB_ITEMACOMPANHAMENTO pelo
        *                  código do Acompanhamento.
        *       Parametro: Objeto ItemAcompanhamento
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool ExcluirByCodAcompanhamento(ItemAcompanhamento pobj_ItemAcompanhamento)
        {
            
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_ITEMACOMPANHAMENTO " +
                           " WHERE I_COD_ACOMPANHAMENTO = @I_COD_ACOMPANHAMENTO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_ACOMPANHAMENTO", pobj_ItemAcompanhamento.Cod_Acompanhamento);
            
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
        *  Nome do Método: FindAllByCodAcompanhamento
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos ItemAcompanhamentos na TB_ITEMACOMPANHAMENTO pelo
        *                  código do Acompanhamento.
        *       Parametro: -
        *         Retorno: Lista<ItemAcompanhamento>
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public List<ItemAcompanhamento> FindAllByCodAcompanhamento()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_ITEMACOMPANHAMENTO "+
                           " WHERE I_COD_ACOMPANHAMENTO = @I_COD_ACOMPANHAMENTO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            
            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<ItemAcompanhamento> Lst_ItemAcompanhamento = new List<ItemAcompanhamento>();

                if (obj_Dtr.HasRows)
                {
                    while(obj_Dtr.Read())
                    {
                        ItemAcompanhamento obj_ItemAcompanhamento = new ItemAcompanhamento();

                        obj_ItemAcompanhamento.Cod_ItemAcompanhamento = Convert.ToInt16(obj_Dtr["I_COD_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Cod_Acompanhamento = Convert.ToInt16(obj_Dtr["I_COD_ACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Peito_ItemAcompanhamento  = Convert.ToDouble(obj_Dtr["D_PEITO_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Coxd_ItemAcompanhamento   = Convert.ToDouble(obj_Dtr["D_COXD_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Coxe_ItemAcompanhamento   = Convert.ToDouble(obj_Dtr["D_COXE_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Bicpd_ItemAcompanhamento  = Convert.ToDouble(obj_Dtr["D_BICPD_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Bicpe_ItemAcompanhamento  = Convert.ToDouble(obj_Dtr["D_BICPE_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Pantud_ItemAcompanhamento = Convert.ToDouble(obj_Dtr["D_PANTUD_ITEMACOMPANHAMENTO"].ToString());
                        obj_ItemAcompanhamento.Pantue_ItemAcompanhamento = Convert.ToDouble(obj_Dtr["D_PANTUE_ITEMACOMPANHAMENTO"].ToString());


                        Lst_ItemAcompanhamento.Add(obj_ItemAcompanhamento);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_ItemAcompanhamento;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ItemAcompanhamento>();
            }
        }
    }
}
