using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace LINEScratch.Models
{
    public partial class DBContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<LINEMember> LINEMember { get; set; }
        public virtual DbSet<Prize> Prize { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DBConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LINEMember>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.Comment).HasColumnName("Comment");

                entity.Property(e => e.LineId).HasColumnName("Line_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.PicUrl).HasColumnName("Pic_url");

                entity.Property(e => e.Status).HasColumnName("Status");
            });

            modelBuilder.Entity<Prize>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

                entity.Property(e => e.PrizeName)
                    .HasColumnName("Prize_name")
                    .HasMaxLength(50);

                entity.Property(e => e.PrizeId).HasColumnName("Prize_id");
                entity.Property(e => e.PrizePic).HasColumnName("Prize_pic");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
