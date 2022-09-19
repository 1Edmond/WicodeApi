namespace WicodeApi.Data;

public class WicodeApiContext : DbContext
{
    public WicodeApiContext (DbContextOptions<WicodeApiContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql(@"Host=ec2-54-204-241-136.compute-1.amazonaws.com;Username=txmwmwfrxofkfk;Password=bacc105f9c8727672368fcad96af94fde9e1a267f21b31ca931af50afd78b4e4;Database=damfo3htosel2k");


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
