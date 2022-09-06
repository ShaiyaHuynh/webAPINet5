using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebAPI_DB_First.Entities
{
    public partial class WebAPI_DB_FirstContext : DbContext
    {
        public WebAPI_DB_FirstContext()
        {
        }

        public WebAPI_DB_FirstContext(DbContextOptions<WebAPI_DB_FirstContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietChuyenBay> ChiTietChuyenBays { get; set; }
        public virtual DbSet<ChuyenBay> ChuyenBays { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<HangGhe> HangGhes { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SanBay> SanBays { get; set; }
        public virtual DbSet<TinhTrang> TinhTrangs { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=WebAPI_DB_First;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ChiTietChuyenBay>(entity =>
            {
                entity.HasKey(e => e.MaChiTiet)
                    .HasName("PK__ChiTietC__CDF0A1147C0FF317");

                entity.ToTable("ChiTietChuyenBay");

                entity.Property(e => e.Gia).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaChuyenBay)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.NgayTao)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.MaChuyenBayNavigation)
                    .WithMany(p => p.ChiTietChuyenBays)
                    .HasForeignKey(d => d.MaChuyenBay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChiTietChuyenBay_ChuyenBay");

                entity.HasOne(d => d.MaHangGheNavigation)
                    .WithMany(p => p.ChiTietChuyenBays)
                    .HasForeignKey(d => d.MaHangGhe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChiTietChuyenBay_HangGhe");

                entity.HasOne(d => d.TinhTrangNavigation)
                    .WithMany(p => p.ChiTietChuyenBays)
                    .HasForeignKey(d => d.TinhTrang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChiTietChuyenBay_TinhTrang");
            });

            modelBuilder.Entity<ChuyenBay>(entity =>
            {
                entity.HasKey(e => e.MaChuyenBay)
                    .HasName("PK__ChuyenBa__9B5036A3DB1B0A5A");

                entity.ToTable("ChuyenBay");

                entity.HasIndex(e => new { e.MaSanBayFrom, e.MaSanBayTo, e.ThoiGianKhoiKhanh }, "index_ChuyenBay");

                entity.Property(e => e.MaChuyenBay).HasMaxLength(10);

                entity.Property(e => e.FlgDel).HasColumnName("flgDel");

                entity.Property(e => e.GhiChu).HasMaxLength(100);

                entity.Property(e => e.MaMayBay)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MaSanBayFrom)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.MaSanBayTo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.ThoiGianKetThuc).HasColumnType("smalldatetime");

                entity.Property(e => e.ThoiGianKhoiKhanh).HasColumnType("smalldatetime");

                entity.HasOne(d => d.MaSanBayFromNavigation)
                    .WithMany(p => p.ChuyenBayMaSanBayFromNavigations)
                    .HasForeignKey(d => d.MaSanBayFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChuyenBay_SanBayFrom");

                entity.HasOne(d => d.MaSanBayToNavigation)
                    .WithMany(p => p.ChuyenBayMaSanBayToNavigations)
                    .HasForeignKey(d => d.MaSanBayTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChuyenBay_SanBayTo");

                entity.HasOne(d => d.TinhTrangNavigation)
                    .WithMany(p => p.ChuyenBays)
                    .HasForeignKey(d => d.TinhTrang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_ChuyenBay_TinhTrang");
            });

            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasKey(e => e.MaDonHang)
                    .HasName("PK__DonHang__129584ADB66DCF69");

                entity.ToTable("DonHang");

                entity.Property(e => e.NgayTao)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.NguoiDung)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.MaChiTietChuyenBayNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.MaChiTietChuyenBay)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DonHang_ChiTietChuyenBay");

                entity.HasOne(d => d.NguoiDungNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.NguoiDung)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DonHang_NguoiDung");

                entity.HasOne(d => d.TinhTrangNavigation)
                    .WithMany(p => p.DonHangs)
                    .HasForeignKey(d => d.TinhTrang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_DonHang_TinhTrang");
            });

            modelBuilder.Entity<HangGhe>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__HangGhe__3214CC9FEC163F1F");

                entity.ToTable("HangGhe");

                entity.Property(e => e.ChiChu)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<NguoiDung>(entity =>
            {
                entity.HasKey(e => e.Email)
                    .HasName("PK__NguoiDun__AB6E6165DDF6DFD4");

                entity.ToTable("NguoiDung");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName).HasMaxLength(30);

                entity.Property(e => e.LastName).HasMaxLength(30);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<SanBay>(entity =>
            {
                entity.HasKey(e => e.Ma)
                    .HasName("PK__SanBay__3214CC9F9FFE3F9A");

                entity.ToTable("SanBay");

                entity.Property(e => e.Ma).HasMaxLength(10);

                entity.Property(e => e.FlgDel).HasColumnName("flgDel");

                entity.Property(e => e.Ten)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<TinhTrang>(entity =>
            {
                entity.HasKey(e => e.MaTinhTrang)
                    .HasName("PK__TinhTran__89F8F6699D095E7C");

                entity.ToTable("TinhTrang");

                entity.Property(e => e.MaTinhTrang).ValueGeneratedNever();

                entity.Property(e => e.TenTinhTrang).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
