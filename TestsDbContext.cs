using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace cursach;

public partial class TestsDbContext : DbContext
{
    public TestsDbContext()
    {
    }

    public TestsDbContext(DbContextOptions<TestsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Test> Tests { get; set; }

    public virtual DbSet<Testresult> Testresults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-Q8117JT\\MSSQLSERVER2022;Database=TestsDB;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__STUDENT__3214EC278F7DFC7E");

            entity.ToTable("STUDENT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Group)
                .HasMaxLength(50)
                .HasColumnName("Group_");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Name_");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Surname).HasMaxLength(50);
        });

        modelBuilder.Entity<Test>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TEST__3214EC27F3B2A8F7");

            entity.ToTable("TEST");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("Name_");
        });

        modelBuilder.Entity<Testresult>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__TESTRESU__3214EC276997FE14");

            entity.ToTable("TESTRESULT");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Mark).HasColumnName("MARK");
            entity.Property(e => e.StudentId).HasColumnName("STUDENT_ID");
            entity.Property(e => e.TestId).HasColumnName("TEST_ID");

            entity.HasOne(d => d.Student).WithMany(p => p.Testresults)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__TESTRESUL__STUDE__3B75D760");

            entity.HasOne(d => d.Test).WithMany(p => p.Testresults)
                .HasForeignKey(d => d.TestId)
                .HasConstraintName("FK__TESTRESUL__TEST___3C69FB99");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
