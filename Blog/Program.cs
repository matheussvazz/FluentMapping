using Blog.Screens.TagScreens;
using Microsoft.Data.SqlClient;


namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$";

        static void Main(string[] args)
        {
            using var context = new BlogDataContext();

            context.Users.Add(new User());
            {

              using var context = new BlogDataContext();

              context.Users.Add (New User)
              {
                Bio = " 9x Microsoft MVP",
                Email = "andre@balta.io",
                Image ="https://balta.io",
                Name = "André Baltieri",
                PasswordHash = "1234",
                Slug ="andre-baltieri" 
              });
              context.SaveChanges();

              var user = context.Users.FirstOrDefault();
              var post = new Post 
              {
                  Author = null,
                  Body = "Meu Artigo"
                  Category = new Category 
                  {
                    Name = "Baclend",
                    Slug = "backend"
                  },
                  CreateDate = System.DateTime.Now,
                  Slug = "meu-artigo",
                  Summary = "Neste artigo vamos conferir..."
                  Title = "Meu artigo",
              };
              context.Posts.Add(post);
              context.SaveChanges();


            }

        }

    }

}


