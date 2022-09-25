
namespace WicodeApi.Controllers;

[ApiController]
[Route("portfolio")]
[Authorize(Roles = "Admin")]
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
        if(!_context.Categories.Any(c => c.Libelle == categorie.Libelle))
        {
            _context.Add<Categorie>(categorie);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode : 300, title: "Erreur",detail : "Il existe une categorie avec ce libelle.");
    }


    [HttpPut]
    [Route("categories/update")]
    public ActionResult<string> UpdateInscription(Categorie categorie)
    {
        try
        {
            if (_context.Categories.Any(x => x.Id == categorie.Id))
            {
                var rep = _context.Categories.Update(categorie);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail : ex.Message , statusCode : 400);

        }
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

    [HttpPost]
    [Route("features/add")]
    public ActionResult<string> AddFeature(Feature feature)
    {
        if (!_context.Features.Any(c => c.Libelle == feature.Libelle))
        {
            _context.Add<Feature>(feature);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe une fonctionnalite avec ce libelle.");
    }
    
    [HttpPost]
    [Route("features/{id:int}/add")]
    public ActionResult<string> AddProjetFeatureFeature(int id, Feature feature)
    {
        if (!_context.Features.Any(c => c.Libelle == feature.Libelle))
        {
           var f = _context.Add<Feature>(feature);
            _context.SaveChanges();
            _context.Add(new ProjetFeature
            {
                FeatureId = f.Entity.Id,
                ProjetId = id
            });
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe une fonctionnalite avec ce libelle.");
    }

    [HttpPut]
    [Route("features/update")]
    public ActionResult<string> UpdateFeature(Feature feature)
    {
        try
        {
            if (_context.Features.Any(x => x.Id == feature.Id))
            {
                var rep = _context.Features.Update(feature);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail: ex.Message, statusCode: 400);

        }
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


    [HttpPost]
    [Route("ressources/add")]
    public ActionResult<string> AddRessource(Ressource ressource)
    {
        if (!_context.Ressources.Any(c => c.Libelle == ressource.Libelle))
        {
            _context.Add<Ressource>(ressource);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe une ressource avec ce libelle.");
    }


    [HttpPut]
    [Route("ressources/update")]
    public ActionResult<string> UpdateRessource(Ressource ressource)
    {
        try
        {
            if (_context.Ressources.Any(x => x.Id == ressource.Id))
            {
                var rep = _context.Ressources.Update(ressource);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail: ex.Message, statusCode: 400);

        }
    }



    #endregion


    #region Skill

    [HttpGet]
    [Route("skills")]
    public ActionResult<string> GetSkills()
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


    [HttpPost]
    [Route("skills/add")]
    public ActionResult<string> Addskill(Skill skill)
    {
        if (!_context.Skills.Any(c => c.Name == skill.Name))
        {
            _context.Add<Skill>(skill);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe une competence avec ce nom.");
    }


    [HttpPut]
    [Route("skills/update")]
    public ActionResult<string> UpdateSkill(Skill skill)
    {
        try
        {
            if (_context.Skills.Any(x => x.Id == skill.Id))
            {
                var rep = _context.Skills.Update(skill);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail: ex.Message, statusCode: 400);

        }
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


    [HttpPost]
    [Route("settings/add")]
    public ActionResult<string> AddSettings(Settings settings)
    {
        if (!_context.Skills.Any(c => c.Name == settings.Name))
        {
            _context.Add<Settings>(settings);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe un parametre avec ce nom.");
    }


    [HttpPut]
    [Route("settings/update")]
    public ActionResult<string> UpdateSettings(Settings settings)
    {
        try
        {
            if (_context.Settings.Any(x => x.Id == settings.Id))
            {
                var rep = _context.Settings.Update(settings);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail: ex.Message, statusCode: 400);

        }
    }





    #endregion


    #region Porjet

    [HttpGet]
    [Route("projets")]
    public ActionResult<string> Getprojets()
    {
        List<Projet> result = _context.Projets.Where(c => c.Etat != 1).ToList();
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

    [HttpPost]
    [Route("projets/add")]
    public ActionResult<string> AddProjet(Projet projet)
    {
        if (!_context.Projets.Any(c => c.Name == projet.Name))
        {
            _context.Add<Projet>(projet);
            _context.SaveChanges();
            return Ok();
        }
        return Problem(statusCode: 300, title: "Erreur", detail: "Il existe un projet avec ce nom.");
    }


    [HttpPut]
    [Route("projets/updateInfo")]
    public ActionResult<string> UpdateProjet(Projet projet)
    {
        try
        {
            if (_context.Projets.Any(x => x.Id == projet.Id))
            {
                var rep = _context.Projets.Update(projet);
                _context.SaveChanges();
                return Ok();
            }
            return NotFound();


        }
        catch (Exception ex)
        {
            return Problem(title: "Exception", detail: ex.Message, statusCode: 400);
        }
    }

    [HttpGet]
    [Route("projets/{id:int}/ressources")]
    public ActionResult<string> GetProjetRessources(int id)
    {
       
        var projet = _context.Projets.Find(id);
        if (projet == null)
            return NotFound();
        else
        {
            var ressources = _context.Ressources.Where(p => p.ProjetId == id && p.Etat == 0).ToList();
            return Ok(JsonConvert.SerializeObject(ressources, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
    }
    
    [HttpGet]
    [Route("projets/{id:int}/features")]
    public ActionResult<string> GetProjetFeatures(int id)
    {
       
        var projet = _context.Projets.Find(id);
        if (projet == null)
            return NotFound();
        else
        {
            var projetFeature = _context.ProjetFeatures.Where(p => p.ProjetId == id).Select(d => d.FeatureId).ToList();
            var features = _context.Features.Where(p => projetFeature.Contains(p.Id)).ToList();
            return Ok(JsonConvert.SerializeObject(features, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }));
        }
    }


    [HttpPut]
    [Route("projets/{id:int}/features/update")]
    public ActionResult<string> UpdatePojetFeature(int id, List<int> features)
    {
        if(_context.Projets.Any(p => p.Id == id))
        {
            var projetFeature = _context.ProjetFeatures.Where(p => p.ProjetId == id).ToList();
            projetFeature.ForEach(x =>
            {
                if (!features.Contains(x.FeatureId))
                    _context.ProjetFeatures.Remove(x);
            });

             _context.SaveChanges();
            features.ForEach( x =>
            {
                if (!projetFeature.Any(y => y.FeatureId == x))
                    _context.Add(new ProjetFeature()
                    {
                        FeatureId = x,
                        ProjetId = id
                    });
            });
            _context.SaveChanges();
            return Ok();

        }
        return NotFound();
    }

    #endregion














}
