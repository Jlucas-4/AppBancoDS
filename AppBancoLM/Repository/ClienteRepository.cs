using AppBancoLM.Models;
using AppBancoLM.Repository.Contract;
using MySql.Data.MySqlClient;

namespace AppBancoLM.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly string _conexaoMySQL;

        public ClienteRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Cliente cliente)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Cliente cliente)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbcliente(nomeCli, Email, DataNasc, Sexo)" +
                    "values (@nomeCli, @Email, @DataNasc, @Sexo)", conexao);

                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.nomeCli;
                cmd.Parameters.Add("@Email", MySqlDbType.VarChar).Value = cliente.Email;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = cliente.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@nomeCli", MySqlDbType.VarChar).Value = cliente.Sexo;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }


        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public Cliente ObterCliente(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cliente> ObterTodosClientes()
        {
            throw new NotImplementedException();
        }
    }
}
