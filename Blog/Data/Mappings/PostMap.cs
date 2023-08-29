using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data.Mappings
{
    public class PostMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            buider.ToTable("Post");

            //Chave Primária
            builder.HasKey(x => x.Id)

           // Identity
            builder.Property(x => x.Id)
                   .ValueGenerateOnAdd()      // Mapeamento de chave primaria e Identity 
                   .UseIdentityColumn();

            // Propriedades (API FLUENTE)
            builder.Property(x => x.LastUpdateDate)
                           .IsRequired() // GERA O NOT NULL 
                           .HasColumnName("Name")
                           .HasColumnType("SMALLDATETIME")
                           //   .HasDefaultValueSql("GETDATE()");
                           .HasDefaultValue(DateTime.Now.ToUniversalTime());


            //Índices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug") // <- Espera inicialmente dois parametros
                   .IsUnique(); // <- transforma o índice em unico 


            //Relacionamentos um para muitos
            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Posts) // função que define muitos "POSTS"
                   .HasConstraintName("FK_Post_Author")
                   .OnDelete(DeleteBehavior.Cascade); // exclui todos os autores e o post relacionado ao autor

            // Relacionamento muitos para muitos
            builder.HasMany(x=> x.Tags) // muitas tags
                   .WithMany(x=> x.Posts)// muitos posts 
                   .UsingEntity<Dictionary<string , object>>(    // geração de uma tabela virtual baseade em um dictionary 
                     "PostTag", // string do dictionary
                     post => post.HasOne<Tag>()
                         .WithMany()
                         .HasForeignKey("PostId")
                         .HasConstraintName("FK_PostTag_PostId")
                         .OnDelete(DeleteBehabior.Cascade),        //objeto do dictionary dividido em dois, Post e a Tag
                     tag => tag.HasOne<Post>()
                            .WithMany()
                            .HasForeignKey("TagId")
                            .HasConstraintName("FK_PostTag_TagId")
                            .OnDelete(DeleteBehabior.Cascade));

                     
                   )
                   
                   

        }
    }
}