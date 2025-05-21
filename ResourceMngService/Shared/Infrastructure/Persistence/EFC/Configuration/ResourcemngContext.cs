using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ResourceMngService.Domain.Model.Aggregates;
using ResourceMngService.Domain.Model.Entities;

namespace ResourceMngService.Shared.Infrastructure.Persistence.EFC.Configuration;

public partial class ResourcemngContext : DbContext
{
    public ResourcemngContext()
    {
    }

    public ResourcemngContext(DbContextOptions<ResourcemngContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<TypesReport> TypesReports { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("server=localhost;database=resourcemng;user=root;password=password;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("reports");

            entity.HasIndex(e => e.TypesReports, "types_reports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AdminsId).HasColumnName("admins_id");
            entity.Property(e => e.Description)
                .HasMaxLength(200)
                .HasColumnName("description");
            entity.Property(e => e.FileUrl)
                .HasMaxLength(6000)
                .HasColumnName("file_url");
            entity.Property(e => e.Title)
                .HasMaxLength(50)
                .HasColumnName("title");
            entity.Property(e => e.TypesReports).HasColumnName("types_reports");
            entity.Property(e => e.WorkersId).HasColumnName("workers_id");

            entity.HasOne(d => d.TypesReportsNavigation).WithMany(p => p.Reports)
                .HasForeignKey(d => d.TypesReports)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("reports_ibfk_1");
        });

        modelBuilder.Entity<TypesReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("types_reports");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
