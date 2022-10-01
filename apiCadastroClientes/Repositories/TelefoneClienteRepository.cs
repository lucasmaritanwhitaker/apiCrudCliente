using apiCadastroClientes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apiCadastroClientes.Repositories
{
    public class TelefoneClienteRepository : BaseRepository
    {
        public List<TelefoneCliente> Get(int id)
        {
            var telefone = new List<TelefoneCliente>();

            try
            {
                ExecuteProcedure("[dbo].[Proc_BuscaTelefone]");
                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;

                var returProcedure = cmd.ExecuteReader();

                while (returProcedure.Read())
                    telefone.Add(new TelefoneCliente(int.Parse(returProcedure["Id"].ToString()),
                                                        returProcedure["ddd"].ToString(),
                                                        returProcedure["ddi"].ToString(),
                                                        returProcedure["numero"].ToString()));
                conn.Close();
                return telefone;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(TelefoneCliente telefone)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_telefone]");
                cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = telefone.IdCliente;
                cmd.Parameters.AddWithValue("@DDI", SqlDbType.Int).Value = telefone.Ddi;
                cmd.Parameters.AddWithValue("@DDD", SqlDbType.Int).Value = telefone.Ddd;
                cmd.Parameters.AddWithValue("@NUMERO", SqlDbType.VarChar).Value = telefone.Numero;
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
                ExecuteProcedure("[dbo].[deletar_telefone]");
                cmd.Parameters.Add(new SqlParameter("@IDCLIENTE", SqlDbType.Int)).Value = idCliente;
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
