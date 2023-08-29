namespace Blog.Data.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Tabela
            buider.ToTable("Category");

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

            builder.Property(x => x.Slug)
                           .IsRequired() // GERA O NOT NULL 
                           .HasColumnName("Slug")
                           .HasColumnType("NVARCHAR")
                           .HasMaxLength(80);

            //Índices
            builder.HasIndex(x => x.Slug, "IX_Category_Slug") // <- Espera inicialmente dois parametros
                   .IsUnique(); // <- transforma o índice em unico 
        }


    }
}