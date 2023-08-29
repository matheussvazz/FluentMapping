
using Dapper.Contrib.Extensions;

namespace Blog.Models
{

    [Table("[User]")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGenerateOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public string Slug { get; set; }

        public Ilist<Post> Post { get; set; }

        public Ilist<Role> Roles { get; set; }


    }
}