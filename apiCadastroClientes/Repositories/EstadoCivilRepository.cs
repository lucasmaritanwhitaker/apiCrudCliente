using apiCadastroClientes.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace apiCadastroClientes.Repositories
{
    public class EstadoCivilRepository : BaseRepository
    {
        public List<EstadoCivil> Get()
        {
            var estadosCivils = new List<EstadoCivil>();

            try
            {
                ExecuteProcedure("[dbo].[busca_estadoCivil]");
                var returnProcedure = cmd.ExecuteReader();

                while (returnProcedure.Read())
                    estadosCivils.Add(new EstadoCivil(byte.Parse(returnProcedure["Id"].ToString()),
                                                                   returnProcedure["NmEstadoCivil"].ToString()));
                conn.Close();
                return estadosCivils;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EstadoCivil estadoCivil)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_estadoCivil]");
                cmd.Parameters.AddWithValue("@NOMEESTADOCIVIL", SqlDbType.VarChar).Value = estadoCivil.NmEstadoCivil;
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(byte id)
        {
            try
            {
                ExecuteProcedure("[dbo].[deletar_estadoCivil]");
                cmd.Parameters.AddWithValue("@ID", SqlDbType.TinyInt).Value = id;
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
