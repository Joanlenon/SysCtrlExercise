/********************************************************************
 *  Nome da Classe: BDCliente
 *       Descrição: Esta classe de Controle de objeto negocia com o 
 *                  Banco de dados os métodos publicos: Incluir, 
 *                  Excluir, Alterar, FindByCodCliente e 
 *                  FindAllCliente
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
    class BDCliente
    {
        //Metodo Destruct
        ~BDCliente()
        {

        }

        /********************************************************************
        *  Nome do Método: Incluir
        *       Descrição: Responsável por incluir o Registro (Tupla) do 
        *                  Cliente na TB_CLIENTE.
        *       Parametro: Objeto Cliente
        *         Retorno: Código do Cliente (PK)
        *     Dt. Criação: 08/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public int Incluir(Cliente pobj_Cliente)
        {

            BDPessoa obj_BDPessoa = new BDPessoa();
            Pessoa obj_Pessoa = new Pessoa();

            obj_Pessoa.Nm_Pessoa = pobj_Cliente.Nm_Pessoa;
            obj_Pessoa.Gen_Pessoa = pobj_Cliente.Gen_Pessoa;
            obj_Pessoa.CPF_Pessoa = pobj_Cliente.CPF_Pessoa;
            obj_Pessoa.Cel_Pessoa = pobj_Cliente.Cel_Pessoa;
            obj_Pessoa.Mail_Pessoa = pobj_Cliente.Mail_Pessoa;
            obj_Pessoa.End_Pessoa = pobj_Cliente.End_Pessoa;
            obj_Pessoa.Bai_Pessoa = pobj_Cliente.Bai_Pessoa;
            obj_Pessoa.Cid_Pessoa = pobj_Cliente.Cid_Pessoa;
            obj_Pessoa.UF_Pessoa = pobj_Cliente.UF_Pessoa;
            obj_Pessoa.CEP_Pessoa = pobj_Cliente.CEP_Pessoa;

            obj_Pessoa.Cod_Pessoa = obj_BDPessoa.Incluir(obj_Pessoa);

            pobj_Cliente.Cod_Pessoa = obj_Pessoa.Cod_Pessoa;

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " INSERT INTO TB_CLIENTE " +
                           " ( " +
                           " I_COD_PESSOA, " +
                           " I_COD_PLANO, " +
                           " I_COD_CONVENIO, " +
                           " S_MAT_CLIENTE " +
                           " ) " +
                           " VALUES " +
                           " ( " +
                           " @I_COD_PESSOA, " +
                           " @I_COD_PLANO, " +
                           " @I_COD_CONVENIO, " +
                           " @S_MAT_CLIENTE " +
                           " ); " +
                           " SELECT IDENT_CURRENT('TB_CLIENTE') AS COD";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Cliente.Cod_Pessoa);
            obj_Com.Parameters.AddWithValue("@I_COD_PLANO", pobj_Cliente.Cod_Plano);
            obj_Com.Parameters.AddWithValue("@I_COD_CONVENIO", pobj_Cliente.Cod_Convenio);
            obj_Com.Parameters.AddWithValue("@S_MAT_CLIENTE", pobj_Cliente.Mat_Cliente);

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
                return pobj_Cliente.Cod_Cliente;
            }
            
        }

        /********************************************************************
        *  Nome do Método: Alterar
        *       Descrição: Responsável por Alterar o Registro (Tupla) do 
        *                  Cliente na TB_CLIENTE.
        *       Parametro: Objeto Cliente
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Alterar(Cliente pobj_Cliente)
        {

            if (pobj_Cliente.Cod_Cliente != -1)
            {

                BDPessoa obj_BDPessoa = new BDPessoa();
                Pessoa obj_Pessoa = new Pessoa();

                obj_Pessoa.Nm_Pessoa = pobj_Cliente.Nm_Pessoa;
                obj_Pessoa.Gen_Pessoa = pobj_Cliente.Gen_Pessoa;
                obj_Pessoa.CPF_Pessoa = pobj_Cliente.CPF_Pessoa;
                obj_Pessoa.Cel_Pessoa = pobj_Cliente.Cel_Pessoa;
                obj_Pessoa.Mail_Pessoa = pobj_Cliente.Mail_Pessoa;
                obj_Pessoa.End_Pessoa = pobj_Cliente.End_Pessoa;
                obj_Pessoa.Bai_Pessoa = pobj_Cliente.Bai_Pessoa;
                obj_Pessoa.Cid_Pessoa = pobj_Cliente.Cid_Pessoa;
                obj_Pessoa.UF_Pessoa = pobj_Cliente.UF_Pessoa;
                obj_Pessoa.CEP_Pessoa = pobj_Cliente.CEP_Pessoa;
                obj_Pessoa.Cod_Pessoa = pobj_Cliente.Cod_Pessoa;

                obj_BDPessoa.Alterar(obj_Pessoa);


                //Conexão com o BD
                SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

                string s_Sql = " UPDATE TB_CLIENTE SET " +
                               " I_COD_PESSOA   = @I_COD_PESSOA, " +
                               " I_COD_PLANO    = @I_COD_PLANO, " +
                               " I_COD_CONVENIO = @I_COD_CONVENIO, " +
                               " S_MAT_CLIENTE  = @S_MAT_CLIENTE " +
                               " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

                SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
                obj_Com.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
                obj_Com.Parameters.AddWithValue("@I_COD_PESSOA", pobj_Cliente.Cod_Pessoa);
                obj_Com.Parameters.AddWithValue("@I_COD_PLANO", pobj_Cliente.Cod_Plano);
                obj_Com.Parameters.AddWithValue("@I_COD_CONVENIO", pobj_Cliente.Cod_Convenio);
                obj_Com.Parameters.AddWithValue("@S_MAT_CLIENTE", pobj_Cliente.Mat_Cliente);

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
        *                  Cliente na TB_CLIENTE.
        *       Parametro: Objeto Cliente
        *         Retorno: Booleano
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public bool Excluir(Cliente pobj_Cliente)
        {
            
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " DELETE FROM TB_CLIENTE " +
                           " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);
            
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
        *                  Cliente na TB_CLIENTE.
        *       Parametro: Objeto Cliente
        *         Retorno: Cliente
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public Cliente FindByCod(Cliente pobj_Cliente)
        {

            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_CLIENTE " +
                           " WHERE I_COD_CLIENTE = @I_COD_CLIENTE ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            obj_Com.Parameters.AddWithValue("@I_COD_CLIENTE", pobj_Cliente.Cod_Cliente);

            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                if (obj_Dtr.HasRows)
                {
                    obj_Dtr.Read();

                    pobj_Cliente.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"].ToString());
                    pobj_Cliente.Cod_Plano = Convert.ToInt16(obj_Dtr["I_COD_PLANO"].ToString());
                    pobj_Cliente.Cod_Convenio = Convert.ToInt16(obj_Dtr["I_COD_CONVENIO"].ToString());
                    pobj_Cliente.Mat_Cliente = obj_Dtr["S_MAT_CLIENTE"].ToString();
                    
                    obj_Conn.Close();
                    obj_Dtr.Close();

                    Pessoa obj_Pessoa = new Pessoa();
                    BDPessoa obj_BDPessoa = new BDPessoa();

                    obj_Pessoa.Cod_Pessoa = pobj_Cliente.Cod_Pessoa;

                    obj_Pessoa = obj_BDPessoa.FindByCod(obj_Pessoa);


                    pobj_Cliente.Nm_Pessoa  = obj_Pessoa.Nm_Pessoa   ;
                    pobj_Cliente.Gen_Pessoa = obj_Pessoa.Gen_Pessoa  ;
                    pobj_Cliente.CPF_Pessoa = obj_Pessoa.CPF_Pessoa  ;
                    pobj_Cliente.Cel_Pessoa = obj_Pessoa.Cel_Pessoa  ;
                    pobj_Cliente.Mail_Pessoa= obj_Pessoa.Mail_Pessoa ;
                    pobj_Cliente.End_Pessoa = obj_Pessoa.End_Pessoa  ;
                    pobj_Cliente.Bai_Pessoa = obj_Pessoa.Bai_Pessoa  ;
                    pobj_Cliente.Cid_Pessoa = obj_Pessoa.Cid_Pessoa  ;
                    pobj_Cliente.UF_Pessoa  = obj_Pessoa.UF_Pessoa   ;
                    pobj_Cliente.CEP_Pessoa = obj_Pessoa.CEP_Pessoa  ;

                    return pobj_Cliente;
                }
                else
                {
                    obj_Conn.Close();
                    obj_Dtr.Close();
                    return new Cliente();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR POR CÓDIGO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new Cliente();
            }
        }

        /********************************************************************
        *  Nome do Método: FindAll
        *       Descrição: Responsável por Encontrar Todos os Registros (Tuplas) 
        *                  dos Clientes na TB_CLIENTE.
        *       Parametro: -
        *         Retorno: Lista<Cliente>
        *     Dt. Criação: 09/05/2023
        *   Dt. Alteração: --/--/---- ( -- )
        *      Criada por:Lenon's 
        ********************************************************************/
        public List<Cliente> FindAll()
        {
            //Conexão com o BD
            SqlConnection obj_Conn = new SqlConnection(BDConnection.ConnectionPath());

            string s_Sql = " SELECT * FROM TB_CLIENTE ";

            SqlCommand obj_Com = new SqlCommand(s_Sql, obj_Conn);
            
            try
            {
                obj_Conn.Open();
                SqlDataReader obj_Dtr = obj_Com.ExecuteReader();

                List<Cliente> Lst_Cliente = new List<Cliente>();

                if (obj_Dtr.HasRows)
                {
                    while(obj_Dtr.Read())
                    {
                        Cliente obj_Cliente = new Cliente();

                        obj_Cliente.Cod_Cliente = Convert.ToInt16(obj_Dtr["I_COD_CLIENTE"].ToString());
                        obj_Cliente.Cod_Pessoa = Convert.ToInt16(obj_Dtr["I_COD_PESSOA"].ToString());
                        obj_Cliente.Cod_Plano = Convert.ToInt16(obj_Dtr["I_COD_PLANO"].ToString());
                        obj_Cliente.Cod_Convenio = Convert.ToInt16(obj_Dtr["I_COD_CONVENIO"].ToString());
                        obj_Cliente.Mat_Cliente = obj_Dtr["S_MAT_CLIENTE"].ToString();


                        Pessoa obj_Pessoa = new Pessoa();
                        BDPessoa obj_BDPessoa = new BDPessoa();

                        obj_Pessoa.Cod_Pessoa = obj_Cliente.Cod_Pessoa;

                        obj_Pessoa = obj_BDPessoa.FindByCod(obj_Pessoa);


                        obj_Cliente.Nm_Pessoa = obj_Pessoa.Nm_Pessoa;
                        obj_Cliente.Gen_Pessoa = obj_Pessoa.Gen_Pessoa;
                        obj_Cliente.CPF_Pessoa = obj_Pessoa.CPF_Pessoa;
                        obj_Cliente.Cel_Pessoa = obj_Pessoa.Cel_Pessoa;
                        obj_Cliente.Mail_Pessoa = obj_Pessoa.Mail_Pessoa;
                        obj_Cliente.End_Pessoa = obj_Pessoa.End_Pessoa;
                        obj_Cliente.Bai_Pessoa = obj_Pessoa.Bai_Pessoa;
                        obj_Cliente.Cid_Pessoa = obj_Pessoa.Cid_Pessoa;
                        obj_Cliente.UF_Pessoa = obj_Pessoa.UF_Pessoa;
                        obj_Cliente.CEP_Pessoa = obj_Pessoa.CEP_Pessoa;

                        Lst_Cliente.Add(obj_Cliente);

                    }
                }
                obj_Conn.Close();
                obj_Dtr.Close();
                return Lst_Cliente;
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message, "ERRO AO ENCONTRAR TODOS", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return new List<Cliente>();
            }
        }
    }
}
