using Microsoft.EntityFrameworkCore;
using Projekt.Models.Entities;

namespace Projekt.Models.Context;
public partial class ProjektDbContext : DbContext
{
    public ProjektDbContext()
    {
    }

    public ProjektDbContext(DbContextOptions<ProjektDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdrEwidencja> AdrEwidencjas { get; set; }

    public virtual DbSet<DkPozycjeNaDokumencie> DkPozycjeNaDokumencies { get; set; }

    public virtual DbSet<DokDokument> DokDokuments { get; set; }

    public virtual DbSet<KhKontrahent> KhKontrahents { get; set; }

    public virtual DbSet<KhTypKontrahentum> KhTypKontrahenta { get; set; }

    public virtual DbSet<SlCechaTw> SlCechaTws { get; set; }

    public virtual DbSet<SlCennik> SlCenniks { get; set; }

    public virtual DbSet<SlGrupaKh> SlGrupaKhs { get; set; }

    public virtual DbSet<SlGrupaTw> SlGrupaTws { get; set; }

    public virtual DbSet<SlKategoriaDokumentu> SlKategoriaDokumentus { get; set; }

    public virtual DbSet<SlMagazyn> SlMagazyns { get; set; }

    public virtual DbSet<SlPanstwo> SlPanstwos { get; set; }

    public virtual DbSet<SlPolaWlasne> SlPolaWlasnes { get; set; }

    public virtual DbSet<SlPolaWlasneTowarow> SlPolaWlasneTowarows { get; set; }

    public virtual DbSet<SlWojewodztwo> SlWojewodztwos { get; set; }

    public virtual DbSet<TwCechaTw> TwCechaTws { get; set; }

    public virtual DbSet<TwCena> TwCenas { get; set; }

    public virtual DbSet<TwTowar> TwTowars { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;TrustServerCertificate=True;Integrated Security=True;Database=ProjektSubiekt");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdrEwidencja>(entity =>
        {
            entity.HasKey(e => e.AdrId).HasName("PK__adr_Ewid__05550567E3ADEAB4");

            entity.HasOne(d => d.AdrIdPanstwoNavigation).WithMany(p => p.AdrEwidencjas).HasConstraintName("FK__adr_Ewide__adr_I__00200768");

            entity.HasOne(d => d.AdrIdWojewodztwoNavigation).WithMany(p => p.AdrEwidencjas).HasConstraintName("FK__adr_Ewide__adr_I__01142BA1");
        });

        modelBuilder.Entity<DkPozycjeNaDokumencie>(entity =>
        {
            entity.HasKey(e => e.DkpId).HasName("PK__dk_Pozyc__BBCE4A4C876A6EC5");

            entity.HasOne(d => d.DkpIdDokumentuNavigation).WithMany(p => p.DkPozycjeNaDokumencies).HasConstraintName("FK__dk_Pozycj__dkp_I__0A9D95DB");

            entity.HasOne(d => d.DkpIdTowaruNavigation).WithMany(p => p.DkPozycjeNaDokumencies).HasConstraintName("FK__dk_Pozycj__dkp_I__09A971A2");
        });

        modelBuilder.Entity<DokDokument>(entity =>
        {
            entity.HasKey(e => e.DokId).HasName("PK__dok_Doku__23BAC2859C421765");

            entity.HasOne(d => d.DokKategoriaDokumentu).WithMany(p => p.DokDokuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DOK_DOKUMENT_SLKATEGORIADOKUMENTU");

            entity.HasOne(d => d.DokMag).WithMany(p => p.DokDokuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__dok_Dokum__dok_M__08B54D69");

            entity.HasOne(d => d.DokOdbiorca).WithMany(p => p.DokDokuments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Dok_OdbiorcaId_Kh_KontrahentKhId");
        });

        modelBuilder.Entity<KhKontrahent>(entity =>
        {
            entity.HasKey(e => e.KhId).HasName("PK__kh_Kontr__667866ABF1272C6C");

            entity.HasOne(d => d.KhIdAdresuNavigation).WithMany(p => p.KhKontrahents).HasConstraintName("FK_Kontrahent_Ewidencja");

            entity.HasOne(d => d.KhIdGrupaNavigation).WithMany(p => p.KhKontrahents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__kh_Kontra__kh_Id__02FC7413");

            entity.HasOne(d => d.KhIdTypKontrahentaNavigation).WithMany(p => p.KhKontrahents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("kh_IdTypKontrahenta_kh_TypKontrahenta");
        });

        modelBuilder.Entity<KhTypKontrahentum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__kh_TypKo__3214EC07FB62E4BA");
        });

        modelBuilder.Entity<SlCechaTw>(entity =>
        {
            entity.HasKey(e => e.CtwId).HasName("PK__sl_Cecha__C9E092B4508F3959");
        });

        modelBuilder.Entity<SlGrupaKh>(entity =>
        {
            entity.HasKey(e => e.GrkId).HasName("PK__sl_Grupa__4CDE7946CBB6539D");
        });

        modelBuilder.Entity<SlGrupaTw>(entity =>
        {
            entity.HasKey(e => e.GrtId).HasName("PK__sl_Grupa__D4D82EA317DF5573");
        });

        modelBuilder.Entity<SlKategoriaDokumentu>(entity =>
        {
            entity.HasKey(e => e.KdId).HasName("PK__sl_Kateg__62BE2D2ED834A836");
        });

        modelBuilder.Entity<SlMagazyn>(entity =>
        {
            entity.HasKey(e => e.MagId).HasName("PK__sl_Magaz__AE17CDEAC4931CC6");
        });

        modelBuilder.Entity<SlPanstwo>(entity =>
        {
            entity.HasKey(e => e.PaId).HasName("PK__sl_Panst__029AC75E79EEB177");
        });

        modelBuilder.Entity<SlPolaWlasne>(entity =>
        {
            entity.HasKey(e => e.PwId).HasName("PK__sl_PolaW__7038C82048C7D5D5");
        });

        modelBuilder.Entity<SlPolaWlasneTowarow>(entity =>
        {
            entity.HasKey(e => e.PwtId).HasName("PK__sl_PolaW__41C9CD64DA8471C7");

            entity.HasOne(d => d.PwtIdPoleWlasneNavigation).WithMany(p => p.SlPolaWlasneTowarows).HasConstraintName("FK__sl_PolaWl__pwt_I__0C85DE4D");

            entity.HasOne(d => d.PwtIdTowarNavigation).WithMany(p => p.SlPolaWlasneTowarows).HasConstraintName("FK__sl_PolaWl__pwt_I__0B91BA14");
        });

        modelBuilder.Entity<SlWojewodztwo>(entity =>
        {
            entity.HasKey(e => e.WojId).HasName("PK__sl_Wojew__B0E8333AFC8AD2E2");
        });

        modelBuilder.Entity<TwCechaTw>(entity =>
        {
            entity.HasKey(e => e.ChtId).HasName("PK__tw_Cecha__7FA7D8C077B30AA5");

            entity.HasOne(d => d.ChtIdCechaNavigation).WithMany(p => p.TwCechaTws).HasConstraintName("FK__tw_CechaT__cht_I__06CD04F7");

            entity.HasOne(d => d.ChtIdTowarNavigation).WithMany(p => p.TwCechaTws).HasConstraintName("FK__tw_CechaT__cht_I__05D8E0BE");
        });

        modelBuilder.Entity<TwCena>(entity =>
        {
            entity.HasKey(e => e.TcId).HasName("PK__tw_Cena__E61CFBB8D6DCDBE7");

            entity.Property(e => e.TcCenaNettoZakupu).HasDefaultValueSql("((0))");
            entity.Property(e => e.TcNazwaCena1Id).HasDefaultValueSql("((1))");
            entity.Property(e => e.TcNazwaCena2Id).HasDefaultValueSql("((2))");
            entity.Property(e => e.TcNazwaCena3Id).HasDefaultValueSql("((3))");
            entity.Property(e => e.TcNazwaCena4Id).HasDefaultValueSql("((4))");

            entity.HasOne(d => d.TcIdTowarNavigation).WithMany(p => p.TwCenas).HasConstraintName("FK__tw_Cena__tc_IdTo__07C12930");
        });

        modelBuilder.Entity<TwTowar>(entity =>
        {
            entity.HasKey(e => e.TwId).HasName("PK__tw_Towar__8D23D4B4DF1044E3");

            entity.Property(e => e.TwUsuniety).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.TwIdGrupaNavigation).WithMany(p => p.TwTowars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tw_Towar__tw_IdG__04E4BC85");

            entity.HasOne(d => d.WIdPodstDostawcaNavigation).WithMany(p => p.TwTowars)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tw_Towar__w_IdPo__7C4F7684");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
