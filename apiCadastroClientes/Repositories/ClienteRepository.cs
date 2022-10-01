using apiCadastroClientes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Xceed.Wpf.Toolkit;

namespace apiCadastroClientes.Repositories
{
    public class ClienteRepository : BaseRepository
    {
        public List<Cliente> Get()
        {
            var clientes = new List<Cliente>();

            try
            {
                ExecuteProcedure("[dbo].[Proc_BuscaClientes]");
                var returnProc = cmd.ExecuteReader();

                while (returnProc.Read())
                    clientes.Add(new Cliente(returnProc["Nome"].ToString(),
                                    int.Parse(returnProc["Id"].ToString()),
                                    returnProc["Sexo"].ToString(),
                                    returnProc["EstadoCivil"].ToString(),
                                    returnProc["Nacionalidade"].ToString()));

                conn.Close();
                return clientes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Cliente Get(int id)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_BuscaCliente]");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returnProc = cmd.ExecuteReader();

                if (returnProc.Read())
                    return new Cliente(returnProc["Nome"].ToString(),
                                            int.Parse(returnProc["Id"].ToString()),
                                            byte.Parse(returnProc["Sexo"].ToString()),
                                            byte.Parse(returnProc["EstadoCivil"].ToString()),
                                            short.Parse(returnProc["Nacionalidade"].ToString()));
                conn.Close();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Post(Cliente cliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_InsereCliente]");
                cmd.Parameters.AddWithValue("@NOME", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.AddWithValue("@SEXO", SqlDbType.TinyInt).Value = cliente.Sexo;
                cmd.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.TinyInt).Value = cliente.EstadoCivil;
                cmd.Parameters.AddWithValue("@NACIONALIDADE", SqlDbType.SmallInt).Value = cliente.Nacionalidade;

                return int.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Put(Cliente cliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_AtualizaCliente]");
                cmd.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = cliente.Id;
                cmd.Parameters.AddWithValue("@NOME", SqlDbType.VarChar).Value = cliente.Nome;
                cmd.Parameters.AddWithValue("@SEXO", SqlDbType.TinyInt).Value = cliente.Sexo;
                cmd.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.TinyInt).Value = cliente.EstadoCivil;
                cmd.Parameters.AddWithValue("@NACIONALIDADE", SqlDbType.SmallInt).Value = cliente.Nacionalidade;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ExecuteProcedure("[dbo].[Proc_DeletaCliente]");
                cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
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
