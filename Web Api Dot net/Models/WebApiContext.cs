using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Web_Api_Dot_net.Models;

public partial class WebApiContext : DbContext
{
    public WebApiContext()
    {
    }

    public WebApiContext(DbContextOptions<WebApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Table> Tables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-A0HEMGG\\SQLEXPRESS;initial catalog=WEB API;user id=sa;password=danish; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Table>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Table__3214EC071B267A29");

            entity.ToTable("Table");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Company)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("company");
            entity.Property(e => e.Name)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("name");
            entity.Property(e => e.RolNumber).HasColumnName("rol_number");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
