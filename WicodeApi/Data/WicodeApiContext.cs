namespace WicodeApi.Data;

public class WicodeApiContext : DbContext
{
    public WicodeApiContext (DbContextOptions<WicodeApiContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=ec2-34-200-205-45.compute-1.amazonaws.com;Username=nuxaflmexzdbby;Password=a3361bf1b0f37009ec064d116d9325d1ee5752aab6302ad8af1bfa4bbe663703;Database=ddns8d0vef4lc3");


    public DbSet<Inscription> Inscriptions { get; set; } = default!;
    public DbSet<Payement> Payements { get; set; } = default!;
    public DbSet<Projet> Projets { get; set; } = default!;
    public DbSet<Feature> Features { get; set; } = default!;
    public DbSet<Ressource> Ressources { get; set; } = default!;
    public DbSet<Settings> Settings { get; set; } = default!;
    public DbSet<Categorie> Categories { get; set; } = default!;
    public DbSet<ProjetFeature> ProjetFeatures { get; set; } = default!;
    public DbSet<Skill> Skills { get; set; } = default!;

}
