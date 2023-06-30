/********************************************************************
 *  Nome da Classe: BDItemPrograma
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodItemPrograma e 
 *                  FindAllItemPrograma
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
    class BDItemPrograma
    {
        //Metodo Destruct
        ~BDItemPrograma()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  ItemPrograma na TB_ITEMPROGRAMA.
        *       Parametro: Objeto ItemPrograma
        *         Retorno: Código do ItemPrograma (PK)
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public int Incluir(ItemPrograma pobj_ItemPrograma)
        {
            

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_ITEMPROGRAMA " +
                           " ( " +
                           " I_COD_PROGRAMA, " +
                           " I_COD_APARELHO, " +
                           " S_NM_ITEMPROGRAMA, " +
                           " S_RESP_ITEMPROGRAMA " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_PROGRAMA, " +
                           " @I_COD_APARELHO, " +
                           " @S_NM_ITEMPROGRAMA, " +
                           " @S_RESP_ITEMPROGRAMA " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_ITEMPROGRAMA') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PROGRAMA", pobj_ItemPrograma.Cod_Programa);
            obj_Com.Parameters.AddWithValue("@I_COD_APARELHO", pobj_ItemPrograma.Cod_Aparelho);
            obj_Com.Parameters.AddWithValue("@S_NM_ITEMPROGRAMA", pobj_ItemPrograma.Nm_ItemPrograma);
            obj_Com.Parameters.AddWithValue("@S_RESP_ITEMPROGRAMA", pobj_ItemPrograma.Rep_ItemPrograma);
            
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
                return pobj_ItemPrograma.Cod_ItemPrograma;
            }
            
        }



        /********************************************************************
        *  Nome do Método: ExcluirByPrograma
        *       Descrição: Responsável por Excluir o Registro (Tupla) do 
        *                  ItemPrograma na TB_ITEMPROGRAMA pelo
        *                  código do Programa.
        *       Parametro: Objeto ItemPrograma
        *         Retorno: Booleano
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool ExcluirByPrograma(ItemPrograma pobj_ItemPrograma)
        {
            
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_ITEMPROGRAMA " +
                           " WHERE I_COD_PROGRAMA = @I_COD_PROGRAMA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PROGRAMA", pobj_ItemPrograma.Cod_Programa);
            
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
        *  Nome do Método: FindAllByCodPrograma
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos ItemProgramas na TB_ITEMPROGRAMA pelo
        *                  código do Programa.
        *       Parametro: -
        *         Retorno: Lista<ItemPrograma>
        *     Dt. Criação: 15/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public List<ItemPrograma> FindAllByCodPrograma()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_ITEMPROGRAMA "+
                           " WHERE I_COD_PROGRAMA = @I_COD_PROGRAMA ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            
            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<ItemPrograma> Lst_ItemPrograma = new List<ItemPrograma>();

                if (obj_Dtr.HasRows)
                {
                    while(obj_Dtr.Read())
                    {
                        ItemPrograma obj_ItemPrograma = new ItemPrograma();

                        obj_ItemPrograma.Cod_ItemPrograma = Convert.ToInt16(obj_Dtr["I_COD_ITEMPROGRAMA"].ToString());
                        obj_ItemPrograma.Cod_Programa = Convert.ToInt16(obj_Dtr["I_COD_PROGRAMA"].ToString());
                        obj_ItemPrograma.Cod_Aparelho  = Convert.ToInt16(obj_Dtr["I_COD_PROGRAMA"].ToString());
                        obj_ItemPrograma.Nm_ItemPrograma   = obj_Dtr["NM_ITEMPROGRAMA"].ToString();
                        obj_ItemPrograma.Rep_ItemPrograma   = obj_Dtr["RESP_ITEMPROGRAMA"].ToString();

                        Lst_ItemPrograma.Add(obj_ItemPrograma);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_ItemPrograma;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<ItemPrograma>();
            }
        }
    }
}
