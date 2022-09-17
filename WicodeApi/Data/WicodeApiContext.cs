namespace WicodeApi.Data;

public class WicodeApiContext : DbContext
{
    public WicodeApiContext (DbContextOptions<WicodeApiContext> options)
        : base(options)
    {
    }

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
