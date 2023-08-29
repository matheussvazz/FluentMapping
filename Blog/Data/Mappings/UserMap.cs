using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Data.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            buider.ToTable("User");

            //Chave Primária
            builder.HasKey(x => x.Id)

           // Identity
            builder.Property(x => x.Id)
                   .ValueGenerateOnAdd()      // Mapeamento de chave primaria e Identity 
                   .UseIdentityColumn();

            // Propriedades (API FLUENTE)
            builder.Property(x => x.Name)
                           .IsRequired() // GERA O NOT NULL 
                           .HasColumnName("Name")
                           .HasColumnType("NVARCHAR")
                           .HasMaxLength(80);

            builder.Property(x => x.Bio);
            builder.Property(x => x.Email);
            builder.Property(x => x.Image);
            builder.Property(x => x.PasswordHash);


            builder.Property(x => x.Slug)
                         .IsRequired() // GERA O NOT NULL 
                         .HasColumnName("Slug")
                         .HasColumnType("NVARCHAR")
                         .HasMaxLength(80);

            //Índices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug") // <- Espera inicialmente dois parametros
                   .IsUnique(); // <- transforma o índice em unico

          // Relacionameto muitos para muitos
            builder
                   .HasMany(x=> x.Roles) // muitas tags
                   .WithMany(x=> x.Users)// muitos posts 
                   .UsingEntity<Dictionary<string , object>>(    // geração de uma tabela virtual baseade em um dictionary 
                     "UserRole", // string do dictionary
                     role => post
                         .HasOne<Role>()
                         .WithMany()
                         .HasForeignKey("RoleId") // chave estrangeira
                         .HasConstraintName("FK_UserRole_RoleId") 
                         .OnDelete(DeleteBehabior.Cascade),        //objeto do dictionary dividido em dois, Post e a Tag
                     user => user 
                            .HasOne<User>()
                            .WithMany()
                            .HasForeignKey("UserId")
                            .HasConstraintName("FK_UserRole_UserId")
                            .OnDelete(DeleteBehabior.Cascade));

        }

    }

}