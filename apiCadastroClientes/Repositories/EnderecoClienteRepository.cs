using apiCadastroClientes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apiCadastroClientes.Repositories
{
    public class EnderecoClienteRepository : BaseRepository
    {
        public List<EnderecoCliente> Get(int id)
        {
            var enderecos = new List<EnderecoCliente>();

            try
            {
                ExecuteProcedure("[dbo].[Proc_BuscaEndereco]");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returProcedure = cmd.ExecuteReader();

                while (returProcedure.Read())
                    enderecos.Add(new EnderecoCliente(int.Parse(returProcedure["Id"].ToString()),
                                                          returProcedure["Cep"].ToString(),
                                                          returProcedure["NomeRua"].ToString(),
                                                          returProcedure["NumeroCasa"].ToString(),
                                                          returProcedure["Bairro"].ToString(),
                                                          returProcedure["Cidade"].ToString(),
                                                          returProcedure["Estado"].ToString(),
                                                          returProcedure["Pais"].ToString()));
                conn.Close();
                return enderecos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EnderecoCliente endereco)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_InsereEndereco]");
                cmd.Parameters.AddWithValue("@CEP", SqlDbType.VarChar).Value = endereco.Cep;
                cmd.Parameters.AddWithValue("@NOMERUA", SqlDbType.VarChar).Value = endereco.NomeRua;
                cmd.Parameters.AddWithValue("@NUMEROCASA", SqlDbType.VarChar).Value = endereco.NumeroCasa;
                cmd.Parameters.AddWithValue("@BAIRRO", SqlDbType.VarChar).Value = endereco.Bairro;
                cmd.Parameters.AddWithValue("@CIDADE", SqlDbType.VarChar).Value = endereco.Cidade;
                cmd.Parameters.AddWithValue("@ESTADO", SqlDbType.VarChar).Value = endereco.Estado;
                cmd.Parameters.AddWithValue("@PAIS", SqlDbType.VarChar).Value = endereco.Pais;
                cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = endereco.IdCliente;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int idCliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_DeletaEndereco]");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = idCliente;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
