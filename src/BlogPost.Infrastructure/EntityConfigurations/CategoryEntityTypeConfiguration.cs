namespace BlogPost.Infrastructure.EntityConfigurations
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(o => o.Id)
                .UseHiLo("Categoriesseq");

            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(m => m.UrlHandle, cg =>
            {
                cg.Property(x => x.Value).HasMaxLength(200);
            });

            builder.Property(e => e.IsDeleted)
                   .IsRequired();
        }
    }
}
