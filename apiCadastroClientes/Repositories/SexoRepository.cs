using apiCadastroClientes.Entity;
using apiCadastroClientes.Extensions;
using System.Data;

namespace apiCadastroClientes.Repositories
{
    public class SexoRepository : BaseRepository
    {
        public List<Sexo> Get()
        {
            var sexos = new List<Sexo>();

            try
            {
                ExecuteProcedure("[dbo].[busca_sexo]");
                var returProcedure = cmd.ExecuteReader();

                while (returProcedure.Read())
                    sexos.Add(new Sexo(returProcedure["NmSexo"].ToString(), returProcedure["Id"].ToByte()));

                conn.Close();
                return sexos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(Sexo sexo)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_sexo]");
                cmd.Parameters.AddWithValue("@NOMESEXO", SqlDbType.VarChar).Value = sexo.NmSexo;
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
                ExecuteProcedure("[dbo].[deletar_sexo]");
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


//    public abstract class Animal
//    {
//        public string Cor { get; set; }

//        public string Fala { get; set; }

//        public virtual void Andar()
//        {

//        }

//        public abstract void Falar();
//    }

//    public class Cachorro : Animal
//    {
//        public override void Falar()
//        {
//            Console.WriteLine("Uau Uau Uau");
//        }
//    }

//    public class Gato : Animal
//    {
//        public override void Falar()
//        {
//            Console.WriteLine("Mialll");
//        }
//    }

//    public class Canguru : Animal
//    {
//        public override void Andar()
//        {
//            base.Andar();
//        }

//        public override void Falar()
//        {
//            Console.WriteLine("Aoba");
//        }
//    }
//}



//Mods 2