using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace PROJETOFINAL
{
    class cidade
    {
        private int idcidade;
        private string nomecidade;
        private string ufcidade;
        //class da tabela
        public int Idcidade
        {
            get
            {
                return idcidade;
            }
            set
            {
                idcidade = value;

            }
        }
        public string Nomecidade
        {
            get
            {
                return nomecidade;
            }
            set
            {
                nomecidade = value;
            }
        }
        public string Ufcidade
        {
            get
            {
                return ufcidade;

            }
            set
            {
                ufcidade = value;
            }
        }
        //listar os dados
        public DataTable Listar()
        {
            SqlDataAdapter daCidade;

            DataTable dtCidade = new DataTable();

            try
            {
                daCidade = new SqlDataAdapter("SELECT * FROM CIDADE", Form1.conexao);
                daCidade.Fill(dtCidade);
                daCidade.FillSchema(dtCidade, SchemaType.Source);
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return dtCidade;
        }

        //salvar dados
        public int Salvar()
        {
            int retorno = 0;
            try
            {
                SqlCommand mycommand;


                mycommand = new SqlCommand("INSERT INTO CIDADE VALUES (@nome_cidade,@uf_cidade)",Form1.conexao);

                mycommand.Parameters.Add(new SqlParameter("@nome_cidade", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@uf_cidade", SqlDbType.VarChar));

                mycommand.Parameters["@nome_cidade"].Value = Nomecidade;
                mycommand.Parameters["@uf_cidade"].Value = Ufcidade;

                retorno = mycommand.ExecuteNonQuery();


            }


            catch (Exception  )
            {
                throw ;

            }
            return retorno;
        }


        public int Alterar()
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;


                mycommand = new SqlCommand("UPDATE CIDADE SET nome_cidade = @nome_cidade, uf_cidade = @uf_cidade WHERE id_cidade = @id_cidade", Form1.conexao);


                mycommand.Parameters.Add(new SqlParameter("@id_cidade", SqlDbType.Int));
                mycommand.Parameters.Add(new SqlParameter("@nome_cidade", SqlDbType.VarChar));
                mycommand.Parameters.Add(new SqlParameter("@uf_cidade", SqlDbType.VarChar));

                mycommand.Parameters["@id_cidade"].Value = idcidade;
                mycommand.Parameters["@nome_cidade"].Value = nomecidade;
                mycommand.Parameters["@uf_cidade"].Value = ufcidade;

                retorno = mycommand.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;

            }
            return retorno;
        }

        public int Excluir()
        {
            int retorno = 0;

            try
            {
                SqlCommand mycommand;

                mycommand = new SqlCommand("DELETE FROM CIDADE WHERE id_cidade = @id_cidade", Form1.conexao);

                mycommand.Parameters.Add(new SqlParameter("@id_cidade", SqlDbType.Int));

                mycommand.Parameters["@id_cidade"].Value = Convert.ToInt16(idcidade);


                retorno = mycommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return retorno;
        }

    }

}
        
    

