using Microsoft.EntityFrameworkCore;
using Blog.Models;


namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
       
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostWithTagsCount> PostWithTagsCount {get; set;}

        override.OnConfiguring(DbContextOptionsBuilder options)
        {
              // Configuração 
           protected override void OnConfiguring(DbContextOptionBuilder options)
            => options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$");


            //Criação dos modelos                                                                           
            protected override void OnModelCreating(ModelBuilder modelBuilder)     // Informando para o dataContext que temos arquivo de mapeamento
                                                                                  // isso é feito num método chamado de OnModelCreating     
            {                                                                     //ModelBuilder serve para aplicar as configurações
                 modelBuilder.ApplyConfiguration(new CategoryMap());
                 modelBuilder.ApplyConfiguration(new UserMap());
                 modelBuilder.ApplyConfiguration(new PostMap());  

                 modelBuilder.Entity<PostWithTagsCount>(X => 
                 {
                    X.ToSqlQuery(@"SELECT [Title] AS [Name] ,
                                  SELECT Count [Id] FROM Tags WHERE PostId = Id AS [Count]
                                   FROM 
                                       [Posts]");

                 });                                                               
            }         

            //Isso é tudo que nós precisamos para rodar a aplicação  quanto criar um banco dedados a partir dela                                                             
            
        }


    }
}