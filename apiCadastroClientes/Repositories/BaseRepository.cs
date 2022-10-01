using System.Data;
using System.Data.SqlClient;

namespace apiCadastroClientes.Repositories
{
    public class BaseRepository
    {
        public SqlConnection conn;
        public SqlCommand cmd;

        public BaseRepository()
        {
            conn = new SqlConnection(@"Data Source=LUCAS-PC\SQLEXPRESS;Initial Catalog=crudClietnes;Integrated Security=True");
        }

        public void ExecuteProcedure(string procedure)
        {
            cmd = new(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
        }
    }
}
