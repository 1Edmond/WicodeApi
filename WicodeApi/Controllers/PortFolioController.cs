
namespace WicodeApi.Controllers;

[ApiController]
[Route("portfolio")]

public class PortFolioController : Controller
{
    private readonly WicodeApiContext _context;

    public PortFolioController(WicodeApiContext context) => _context = context;


    #region Categorie
    
    [HttpGet]
    [Route("categories")]
    public ActionResult<string> GetCategories()
    {
        List<Categorie> result = _context.Categories.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("categories/{id:int}")]
    public ActionResult<string> GetCategoire(int id)
    {
        var categorie = _context.Categories.Find(id);
        if (categorie == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(categorie));
    }

    [HttpPost]
    [Route("categories/add")]
    public ActionResult<string> AddCategoire (Categorie categorie)
    {
        _context.Add<Categorie>(categorie);
        _context.SaveChanges();
        return Ok();
    }



    #endregion


    #region Feature

    [HttpGet]
    [Route("features")]
    public ActionResult<string> GetFeatures()
    {
        List<Feature> result = _context.Features.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("features/{id:int}")]
    public ActionResult<string> GetFeature(int id)
    {
        var feature = _context.Features.Find(id);
        if (feature == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(feature));
    }



    #endregion


    #region Ressource

    [HttpGet]
    [Route("ressources")]
    public ActionResult<string> GetRessources()
    {
        List<Ressource> result = _context.Ressources.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("ressources/{id:int}")]
    public ActionResult<string> GetRessource(int id)
    {
        var ressource = _context.Ressources.Find(id);
        if (ressource == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(ressource));
    }



    #endregion


    #region Skill

    [HttpGet]
    [Route("skills")]
    public ActionResult<string> GetSkill()
    {
        List<Skill> result = _context.Skills.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("skills/{id:int}")]
    public ActionResult<string> GetSkill(int id)
    {
        var skill = _context.Skills.Find(id);
        if (skill == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(skill));
    }





    #endregion


    #region Settings

    [HttpGet]
    [Route("settings")]
    public ActionResult<string> GetSettings()
    {
        List<Settings> result = _context.Settings.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }


    [HttpGet]
    [Route("settings/{id:int}")]
    public ActionResult<string> GetSetting(int id)
    {
        var settings = _context.Settings.Find(id);
        if (settings == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(settings));
    }





    #endregion


    #region Porjet

    [HttpGet]
    [Route("projets")]
    public ActionResult<string> Getprojets()
    {
        List<Projet> result = _context.Projets.Where(c => c.Etat == 0).ToList();
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("projets/{id:int}")]
    public ActionResult<string> GetProjet(int id)
    {
        var projet = _context.Projets.Find(id);
        if (projet == null)
            return NotFound();
        else
            return Ok(JsonConvert.SerializeObject(projet));
    }






    #endregion














}
