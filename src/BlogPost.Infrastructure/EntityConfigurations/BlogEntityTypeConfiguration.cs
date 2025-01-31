namespace BlogPost.Infrastructure.EntityConfigurations
{
    internal class BlogPostsEntityTypeConfiguration : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blogs");

            builder.HasKey(o => o.Id);

            builder.Ignore(b => b.DomainEvents);

            builder.Property(o => o.Id)
                .UseHiLo("Blogseq");
            builder.Property(b => b.Title);


            builder.Property(m => m.BlogGuid)
                .IsRequired();
            builder.HasIndex(m => m.BlogGuid)
             .IsUnique();
            builder.Property(m => m.Title)
                .IsRequired()
                .HasMaxLength(200);
            builder.Property(m => m.ShortDescription)
              .HasMaxLength(300);
            builder.Property(m => m.Content)
               .IsRequired()
               .HasMaxLength(4000);


            builder.OwnsOne(m => m.FeaturedImage, cg =>
            {
                cg.Property(x => x.Url).HasMaxLength(200);
                cg.Property(x => x.AltText).HasMaxLength(100);
            });
            builder.OwnsOne(m => m.UrlHandle, cg =>
            {
                cg.Property(x => x.Value).HasMaxLength(200);

            });

            builder.Property(m => m.PublishedDate)
               .IsRequired(false);

            builder.OwnsOne(m => m.Author, cg =>
            {
                cg.Property(x => x.Firstname).HasMaxLength(200);
                cg.Property(x => x.Lastname).HasMaxLength(100);
            });

            builder.Property(m => m.IsVisible)
                .IsRequired();

            builder.Property(m => m.IsDeleted)
                .IsRequired();

            builder.OwnsMany(m => m.Images, a =>
            {
                a.WithOwner().HasForeignKey("BlogId");

                a.Property(o => o.Id)
               .UseHiLo("imageseq");

                a.HasKey(o => o.Id);

                a.Ignore(b => b.DomainEvents);
                a.Property(st => st.BlogImageGuid)
                   .IsRequired();
                a.Property(st => st.FileName)
                    .IsRequired();
                a.HasIndex(st => st.BlogImageGuid)
                       .IsUnique();
                a.Property(st => st.Title)
                    .IsRequired()
                     .HasMaxLength(50);

                a.Property(st => st.Url)
                    .IsRequired()
                    .HasMaxLength(150);

                a.Property(st => st.IsDeleted)
                    .IsRequired();

                a.ToTable("BlogImage");
            });

            builder.OwnsMany(m => m.CategoryIds, a =>
            {
                a.WithOwner().HasForeignKey("BlogId");
                a.Property<long>("Id").ValueGeneratedOnAdd(); // Configures Id as auto-generated if needed
                a.HasKey("Id"); // Sets Id as the primary key
                a.Property(c => c.CategoryId).IsRequired();
                a.HasOne<Category>()
                    .WithMany()
                    .HasForeignKey(c => c.CategoryId)
                    .OnDelete(DeleteBehavior.NoAction);
                a.ToTable("BlogPostCategories");
            });


        }
    }
}

