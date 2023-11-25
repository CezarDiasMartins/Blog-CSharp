using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[User]")] // --> P/ buscar no banco como está dentro do colchete, se não, é acrescentado um "s" no final da tabela quando for feito uma busca
    public class User
    {
        public User()
            => Roles = new List<Role>();

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        [Write(false)] // --> Para não incluir este atributo quando for ter que gerar(insert) um user 
        public List<Role> Roles { get; set; }
    }
}