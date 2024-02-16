using SistemaVendas.Uteis;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace SistemaVendas.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Digite o Email")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a Senha")]
        public string Senha { get; set; }

        public bool ValidarLogin()
        {
            string sql = $"SELECT id FROM vendedor WHERE email = '{Email}' and senha = '{Senha}' ";

            DAL obj = new DAL();
            DataTable table = obj.RetDataTable(sql);

            return table.Rows.Count == 1;
        }

    }
}
