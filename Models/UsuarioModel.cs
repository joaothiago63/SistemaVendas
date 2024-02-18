using SistemaVendas.Uteis;
using System.Data;

namespace SistemaVendas.Models
{
    public class UsuarioModel
    {
        public string Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public UsuarioModel(LoginModel login)
        {
            Email = login.Email;
            Senha = login.Senha;
            CarregarNomeSenha();
        }

        public UsuarioModel()
        {

        }

        private void CarregarNomeSenha()
        {
            string sql = $"SELECT ID , NOME FROM vendedor WHERE EMAIL = '{Email}'";

            DAL dal = new DAL();
            DataTable data = dal.RetDataTable(sql);

            Id = data.Rows[0]["ID"].ToString();
            Nome = data.Rows[0]["NOME"].ToString();
        }

    }
}
