using Dapper.Contrib.Extensions;

namespace Blog.Models
{
    [Table("[Category]")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGenerateOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column"Name", TypeName = "NVARCHAR"]
        public string Name { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(80)]
        [Column"Name", TypeName = "VARCHAR"]
        public string Slug { get; set; }
    }
}