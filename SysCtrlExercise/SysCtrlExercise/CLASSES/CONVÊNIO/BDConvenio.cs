/********************************************************************
 *  Nome da Classe: BDConvenio
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodConvenio e 
 *                  FindAllConvenio
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
    class BDConvenio

    {
        //Metodo Destruct
        ~BDConvenio()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Convenio na TB_CONVENIO.
        *       Parametro: Objeto Convenio
        *         Retorno: Código do Convenio (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public int Incluir(Convenio pobj_Convenio)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_CONVENIO " +
                           " ( " +
                           " S_NM_CONVENIO, " +
                           " S_NRO_CONVENIO, " +
                           " I_TP_CONVENIO, " +
                           " S_CAT_CONVENIO " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @S_NM_CONVENIO, " +
                           " @S_NRO_CONVENIO, " +
                           " @I_TP_CONVENIO, " +
                           " @S_CAT_CONVENIO " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_CONVENIO') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@S_NM_CONVENIO", pobj_Convenio.Nm_Convenio);
            obj_Com.Parameters.AddWithValue("@S_NRO_CONVENIO", pobj_Convenio.Nro_Convenio);
            obj_Com.Parameters.AddWithValue("@I_TP_CONVENIO", pobj_Convenio.Tp_Convenio);
            obj_Com.Parameters.AddWithValue("@S_CAT_CONVENIO", pobj_Convenio.Cat_Convenio);

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
                return pobj_Convenio.Cod_Convenio;
            }
            
        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Convenio na TB_CONVENIO.
        *       Parametro: Objeto Convenio
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Alterar(Convenio pobj_Convenio)
        {
            if (pobj_Convenio.Cod_Convenio != -1)
            {
                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_CONVENIO SET " +
                               " S_NM_CONVENIO  = @S_NM_CONVENIO, " +
                               " S_NRO_CONVENIO = @S_NRO_CONVENIO, " +
                               " I_TP_CONVENIO  = @I_TP_CONVENIO, " +
                               " S_CAT_CONVENIO = @S_CAT_CONVENIO " +
                               " WHERE I_COD_CONVENIO = @I_COD_CONVENIO ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@S_NM_CONVENIO", pobj_Convenio.Nm_Convenio);
                obj_Com.Parameters.AddWithValue("@S_NRO_CONVENIO", pobj_Convenio.Nro_Convenio);
                obj_Com.Parameters.AddWithValue("@I_TP_CONVENIO", pobj_Convenio.Tp_Convenio);
                obj_Com.Parameters.AddWithValue("@S_CAT_CONVENIO", pobj_Convenio.Cat_Convenio);

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
        *                  Convenio na TB_CONVENIO.
        *       Parametro: Objeto Convenio
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public bool Excluir(Convenio pobj_Convenio)
        {
            
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_CONVENIO " +
                           " WHERE I_COD_CONVENIO = @I_COD_CONVENIO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_CONVENIO", pobj_Convenio.Cod_Convenio);
            
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
        *                  Convenio na TB_CONVENIO.
        *       Parametro: Objeto Convenio
        *         Retorno: Convenio
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public Convenio FindByCod(Convenio pobj_Convenio)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_CONVENIO " +
                           " WHERE I_COD_CONVENIO = @I_COD_CONVENIO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_CONVENIO", pobj_Convenio.Cod_Convenio);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Convenio.Nm_Convenio = obj_Dtr["S_NM_CONVENIO"].ToString();
                    pobj_Convenio.Nro_Convenio = obj_Dtr["S_NRO_CONVENIO"].ToString();
                    pobj_Convenio.Tp_Convenio = Convert.ToInt16(obj_Dtr["I_TP_CONVENIO"].ToString());
                    pobj_Convenio.Cat_Convenio = obj_Dtr["S_CAT_CONVENIO"].ToString();

                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return pobj_Convenio;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Convenio();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Convenio();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Convenios na TB_CONVENIO.
        *       Parametro: -
        *         Retorno: Lista<Convenio>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por: mFacine (Monstro)
        ********************************************************************/
        public List<Convenio> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_CONVENIO ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            
            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Convenio> Lst_Convenio = new List<Convenio>();

                if (obj_Dtr.HasRows)
                {
                    while(obj_Dtr.Read())
                    {
                        Convenio obj_Convenio = new Convenio();

                        obj_Convenio.Cod_Convenio = Convert.ToInt16(obj_Dtr["I_COD_CONVENIO"].ToString());
                        obj_Convenio.Nm_Convenio = obj_Dtr["S_NM_CONVENIO"].ToString();
                        obj_Convenio.Nro_Convenio = obj_Dtr["S_NRO_CONVENIO"].ToString();
                        obj_Convenio.Tp_Convenio = Convert.ToInt16(obj_Dtr["I_TP_CONVENIO"].ToString());
                        obj_Convenio.Cat_Convenio = obj_Dtr["S_CAT_CONVENIO"].ToString();

                        Lst_Convenio.Add(obj_Convenio);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Convenio;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Convenio>();
            }
        }
    }
}
