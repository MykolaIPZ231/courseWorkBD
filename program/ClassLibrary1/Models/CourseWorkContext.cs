using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary1.Models;

public partial class CourseWorkContext : DbContext
{
    public CourseWorkContext()
    {
    }

    public CourseWorkContext(DbContextOptions<CourseWorkContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CCase> CCases { get; set; }

    public virtual DbSet<Cpu> Cpus { get; set; }

    public virtual DbSet<Gpu> Gpus { get; set; }

    public virtual DbSet<Mboard> Mboards { get; set; }

    public virtual DbSet<PowerSup> PowerSups { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<Storage> Storages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=CourseWork;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CCase>(entity =>
        {
            entity.HasKey(e => e.IdCase).HasName("PK__cCase__70179C40C48AA6CB");

            entity.ToTable("cCase");

            entity.Property(e => e.IdCase).HasColumnName("ID_case");
            entity.Property(e => e.CaseBrand)
                .HasMaxLength(50)
                .HasColumnName("case_brand");
            entity.Property(e => e.CaseFormFactor)
                .HasMaxLength(50)
                .HasColumnName("case_formFactor");
            entity.Property(e => e.CaseModel)
                .HasMaxLength(50)
                .HasColumnName("case_model");
            entity.Property(e => e.CasePrise)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("case_prise");
        });

        modelBuilder.Entity<Cpu>(entity =>
        {
            entity.HasKey(e => e.IdCpu).HasName("PK__CPU__23F9E60A623C68EF");

            entity.ToTable("CPU");

            entity.Property(e => e.IdCpu).HasColumnName("ID_cpu");
            entity.Property(e => e.CpuBrand)
                .HasMaxLength(50)
                .HasColumnName("cpu_brand");
            entity.Property(e => e.CpuCores).HasColumnName("cpu_cores");
            entity.Property(e => e.CpuFrequency)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("cpu_frequency");
            entity.Property(e => e.CpuModel)
                .HasMaxLength(50)
                .HasColumnName("cpu_model");
            entity.Property(e => e.CpuPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("cpu_price");
            entity.Property(e => e.CpuThreads).HasColumnName("cpu_threads");
        });

        modelBuilder.Entity<Gpu>(entity =>
        {
            entity.HasKey(e => e.IdGpu).HasName("PK__GPU__26C8F5C0205596D0");

            entity.ToTable("GPU");

            entity.Property(e => e.IdGpu).HasColumnName("ID_gpu");
            entity.Property(e => e.GpuBrand)
                .HasMaxLength(50)
                .HasColumnName("gpu_brand");
            entity.Property(e => e.GpuFrequency)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("gpu_frequency");
            entity.Property(e => e.GpuMemorySize).HasColumnName("gpu_memorySize");
            entity.Property(e => e.GpuModel)
                .HasMaxLength(50)
                .HasColumnName("gpu_model");
            entity.Property(e => e.GpuPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("gpu_price");
        });

        modelBuilder.Entity<Mboard>(entity =>
        {
            entity.HasKey(e => e.IdMboard).HasName("PK__Mboard__05124384C5ED3960");

            entity.ToTable("Mboard");

            entity.Property(e => e.IdMboard).HasColumnName("ID_mboard");
            entity.Property(e => e.MboardBrand)
                .HasMaxLength(50)
                .HasColumnName("mboard_brand");
            entity.Property(e => e.MboardChipset)
                .HasMaxLength(50)
                .HasColumnName("mboard_chipset");
            entity.Property(e => e.MboardFormFactor)
                .HasMaxLength(50)
                .HasColumnName("mboard_formFactor");
            entity.Property(e => e.MboardModel)
                .HasMaxLength(50)
                .HasColumnName("mboard_model");
            entity.Property(e => e.MboardPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("mboard_price");
            entity.Property(e => e.MboardSocket)
                .HasMaxLength(50)
                .HasColumnName("mboard_socket");
        });

        modelBuilder.Entity<PowerSup>(entity =>
        {
            entity.HasKey(e => e.IdPowerSup).HasName("PK__PowerSup__9213C7F6D2AEF4FE");

            entity.ToTable("PowerSup");

            entity.Property(e => e.IdPowerSup).HasColumnName("ID_powerSup");
            entity.Property(e => e.PowerSupBrand)
                .HasMaxLength(50)
                .HasColumnName("powerSup_brand");
            entity.Property(e => e.PowerSupEfficincy)
                .HasMaxLength(50)
                .HasColumnName("powerSup_efficincy");
            entity.Property(e => e.PowerSupModel)
                .HasMaxLength(50)
                .HasColumnName("powerSup_model");
            entity.Property(e => e.PowerSupPowerWatt).HasColumnName("powerSup_powerWatt");
            entity.Property(e => e.PowerSupPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("powerSup_price");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.IdRam).HasName("PK__RAM__182BC5CF2FC24AE9");

            entity.ToTable("RAM");

            entity.Property(e => e.IdRam).HasColumnName("ID_ram");
            entity.Property(e => e.RamBrand)
                .HasMaxLength(50)
                .HasColumnName("ram_brand");
            entity.Property(e => e.RamFrequency)
                .HasColumnType("decimal(7, 2)")
                .HasColumnName("ram_frequency");
            entity.Property(e => e.RamMemorySize).HasColumnName("ram_memorySize");
            entity.Property(e => e.RamModel)
                .HasMaxLength(50)
                .HasColumnName("ram_model");
            entity.Property(e => e.RamPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("ram_price");
            entity.Property(e => e.RamType)
                .HasMaxLength(50)
                .HasColumnName("ram_type");
        });

        modelBuilder.Entity<Storage>(entity =>
        {
            entity.HasKey(e => e.IdStorage).HasName("PK__Storage__596DD58A755FAD68");

            entity.ToTable("Storage");

            entity.Property(e => e.IdStorage).HasColumnName("ID_storage");
            entity.Property(e => e.StorageBrand)
                .HasMaxLength(50)
                .HasColumnName("storage_brand");
            entity.Property(e => e.StorageCapacity).HasColumnName("storage_capacity");
            entity.Property(e => e.StorageModel)
                .HasMaxLength(50)
                .HasColumnName("storage_model");
            entity.Property(e => e.StoragePrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("storage_price");
            entity.Property(e => e.StorageType)
                .HasMaxLength(50)
                .HasColumnName("storage_type");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
