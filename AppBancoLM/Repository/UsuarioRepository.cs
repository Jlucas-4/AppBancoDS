using AppBancoLM.Models;
using AppBancoLM.Repository.Contract;
using MySql.Data.MySqlClient;
using System.Data;

namespace AppBancoLM.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }
        public void Atualizar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("Update tbusuario set nomeUsua=@nomeUsua, Cargo=@Cargo," +
                "DataNasc=@DataNasc Where IdUsu=@IdUsu", conexao);

                cmd.Parameters.Add("@nomeUsua", MySqlDbType.VarChar).Value = usuario.nomeUsua;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");
                cmd.Parameters.Add("@IdUsu", MySqlDbType.VarChar).Value = usuario.IdUsu;

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbusuario(nomeUsua, cargo, DataNasc) " +
                                                    " values (@nomeUsua, @Cargo, @DataNasc)", conexao);
                cmd.Parameters.Add("@nomeUsua", MySqlDbType.VarChar).Value = usuario.nomeUsua;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();

            }
        }

        public void Excluir(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("delete from tbusuario where IdUsu=@IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", id);
                int i = cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            List<Usuario> UsuarioList = new List<Usuario>();
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("select * from tbusuario", conexao);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                conexao.Clone();

                foreach (DataRow dr in dt.Rows)
                {
                    UsuarioList.Add(
                        new Usuario
                        {
                            IdUsu = Convert.ToInt32(dr["IdUsu"]),
                            nomeUsua = (string)dr["nomeUsua"],
                            Cargo = (string)dr["Cargo"],
                            DataNasc = Convert.ToDateTime(dr["DataNasc"])
                        });
                }
                return UsuarioList;
            }
        }

        public Usuario ObterUsuario(int id)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * from tbusuario " +
                                                    "where IdUsu = @IdUsu", conexao);
                cmd.Parameters.AddWithValue("@IdUsu", id);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                MySqlDataReader dr;

                Usuario usuario = new Usuario();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                while (dr.Read())
                {
                    usuario.IdUsu = Convert.ToInt32(dr["IdUsu"]);
                    usuario.nomeUsua = (string)(dr["nomeUsu"]);
                    usuario.Cargo = (string)(dr["Cargo"]);
                    usuario.DataNasc = Convert.ToDateTime(dr["DataNasc"]);
                }
                return usuario;
            }

        }
    }
}
/*
public class UsuarioRepository : IUsuarioRepository
    {
        private readonly string _conexaoMySQL;

        public UsuarioRepository(IConfiguration conf)
        {
            _conexaoMySQL = conf.GetConnectionString("ConexaoMySQL");
        }

        public void Atualizar(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario usuario)
        {
            using (var conexao = new MySqlConnection(_conexaoMySQL))
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("insert into tbusuario(nomeUsua,Cargo,DataNasc)" +
                    "values (@nomeUsua, @Cargo, @DataNasc)", conexao);

                cmd.Parameters.Add("@nomeUsua", MySqlDbType.VarChar).Value = usuario.nomeUsua;
                cmd.Parameters.Add("@Cargo", MySqlDbType.VarChar).Value = usuario.Cargo;
                cmd.Parameters.Add("@DataNasc", MySqlDbType.VarChar).Value = usuario.DataNasc.ToString("yyyy/MM/dd");

                cmd.ExecuteNonQuery();
                conexao.Close();
            }
        }

       

        public void Excluir(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> ObterTodosUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario ObterUsuario(int id)
        {
            throw new NotImplementedException();
        }
    }
}


*/