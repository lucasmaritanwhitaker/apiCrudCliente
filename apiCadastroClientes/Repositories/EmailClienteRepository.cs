using apiCadastroClientes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apiCadastroClientes.Repositories
{
    public class EmailClienteRepository : BaseRepository
    {
        public List<EmailCliente> Get(int id)
        {
            var emails = new List<EmailCliente>();

            try
            {
                ExecuteProcedure("[dbo].[Proc_BuscaEmail]");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returnProcedure = cmd.ExecuteReader();

                while (returnProcedure.Read())
                    emails.Add(new EmailCliente(int.Parse(returnProcedure["Id"].ToString()),
                                                    returnProcedure["nomeEmail"].ToString()));


                conn.Close();
                return emails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EmailCliente email)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_InsereEmail]");
                cmd.Parameters.AddWithValue("@NOMEEMAIL", SqlDbType.VarChar).Value = email.NomeEmail;
                cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = email.IdCliente;
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
                ExecuteProcedure("[dbo].[deletar_email]");
                cmd.Parameters.AddWithValue("@IDCLIENTE", SqlDbType.Int).Value = idCliente;
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
