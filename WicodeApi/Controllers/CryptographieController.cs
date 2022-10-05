namespace WicodeApi.Controllers;

[Route("cryptographie")]
[ApiController]
[Authorize]
public class CryptographieController : ControllerBase
{
    private readonly WicodeApiContext _context;

    public CryptographieController(WicodeApiContext context) => _context = context;


    #region Inscriptions

    [HttpGet]
    [Route("inscriptions")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> GetInscription()
    {
        ApiResult<Inscription> result = new()
        {
            StatusCode = "200",
            Message = "Réussie",
            Results = _context.Inscriptions.ToList(),
        };
        return JsonConvert.SerializeObject(result);
    }
    
    [HttpGet]
    [Route("inscriptions/{id:int}/payements/validate")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> ValidateInscription(int id)
    {
        var payements = _context.Payements.Where(p => p.InscriptionId == id).ToList();
        payements.ForEach(x => x.Etat = 2);
        _context.UpdateRange(payements);
        ApiResult<Inscription> result = new()
        {
            StatusCode = "200",
            Message = $"Réussie",
        };
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("inscriptions/{id:int}")]
    public ActionResult<string> GetInscription(int id)
    {
        var result = new ApiResult<Inscription>();
        var inscription = _context.Inscriptions.Find(id);
        if (inscription == null)
        {
            result.StatusCode = "404";
            result.Message = "Erreur id non disponible.";
            result.Results = new List<Inscription>();
        }
        else
        {
            result.StatusCode = "200";
            result.Message = "Réussie.";
            result.Element = inscription;
        }

        return JsonConvert.SerializeObject(result);
    }
    [HttpGet]
    [Route("inscriptions/exist/{contact}")]
    public ActionResult<string> ExistInscription(string contact)
    {
        var result = new ApiResult<Inscription>();
        var inscription = _context.Inscriptions.Any(x => x.Contact == contact);
        if (inscription)
            (result.StatusCode, result.Message) = ("200", "true");
        else
            (result.StatusCode, result.Message) = ("200", "false");
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("inscriptions/{id:int}/payements")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> GetInscriptionPayement(int id)
    {
        var result = new ApiResult<Payement>();
        var inscription = _context.Inscriptions.Find(id);
        if (inscription == null)
        {
            result.StatusCode = "404";
            result.Message = "Erreur id non disponible.";
            result.Results = new List<Payement>();
        }
        else
        {
            result.StatusCode = "200";
            result.Message = "Réussie.";
            result.Results = _context.Payements.Where(x => x.InscriptionId == inscription.Id).ToList();
        }

        return JsonConvert.SerializeObject(result);
    }

    [HttpPost]
    [Route("inscriptions/add")]
    public ActionResult<string> CreateInscription(Inscription inscription)
    {
        _context.Add<Inscription>(inscription);
        var result = new ApiResult<Inscription>()
        {
            Message = "Une inscription à été ajouté",
            StatusCode = "200",
            Element = inscription
        };
        _context.SaveChanges();
        return JsonConvert.SerializeObject(result);
    }

    [HttpDelete]
    [Route("inscriptions/delete/{id:int}")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> InscriptionDelete(int id)
    {
        var result = new ApiResult<Inscription>();
        if (_context.Inscriptions.Any(i => i.Id == id))
        {
            result.Element = _context.Inscriptions.Find(id);
            _context.Inscriptions.Remove(result.Element);
            result.Message = "Suprresion réussie.";
            result.StatusCode = "200";
            _context.SaveChanges();
        }
        else
        {
            result.StatusCode = "404";
            result.Message = "Innscrirption non trouvé.";
        }

        return JsonConvert.SerializeObject(result);
    }

    [HttpPut]
    [Route("inscriptions/update")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> UpdateInscription(Inscription inscription)
    {
        try
        {
            if (_context.Inscriptions.Any(x => x.Id == inscription.Id))
            {
                var rep = _context.Inscriptions.Update(inscription);
                var result = new ApiResult<Inscription>()
                {
                    Message = "Une inscription à été mise à jour",
                    StatusCode = "200",
                    Element = rep.Entity
                };
                _context.SaveChanges();
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ApiResult<Inscription>()
            {
                Message = "Inscription non trouvé",
                StatusCode = "500",
                Element = inscription
            });


        }
        catch (Exception ex)
        {
            return JsonConvert.SerializeObject(new ApiResult<Inscription>()
            {
                Message = ex.Message,
                StatusCode = "500",
                Element = inscription
            });

        }
    }


    #endregion

    #region Payements

    [HttpGet]
    [Route("payements")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> GetPayements()
    {
        ApiResult<Payement> result = new()
        {
            StatusCode = "200",
            Message = "Réussie",
            Results = _context.Payements.ToList(),
        };
        return JsonConvert.SerializeObject(result);
    }

    [HttpGet]
    [Route("payements/{id:int}")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> GetPayement(int id)
    {
        var result = new ApiResult<Payement>();
        var Payement = _context.Payements.Find(id);
        if (Payement == null)
        {
            result.StatusCode = "404";
            result.Message = "Erreur id non disponible.";
            result.Results = new List<Payement>();
        }
        else
        {
            result.StatusCode = "200";
            result.Message = "Réussie.";
            result.Element = Payement;
        }

        return JsonConvert.SerializeObject(result);
    }


    [HttpPost]
    [Route("payements/add")]
    public ActionResult<string> CreatePayement([Bind("Reference, InscriptionId, Etat, Id, DatePayement")] Payement payement)
    {
        try
        {
            var rep = _context.Add(new Payement(payement));
            var result = new ApiResult<Payement>()
            {
                Message = "Un payement à été ajouté",
                StatusCode = "200",
                Element = rep.Entity
            };
            _context.SaveChanges();
            return JsonConvert.SerializeObject(result);

        }
        catch (Exception ex)
        {
            return JsonConvert.SerializeObject(new ApiResult<Payement>()
            {
                Message = ex.Message,
                StatusCode = "500",
                Element = payement
            });

        }
    }

    [HttpGet]
    [Route("payements/delete/{id:int}")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> PayementDelete(int id)
    {
        var result = new ApiResult<Payement>();
        if (_context.Payements.Any(i => i.Id == id))
        {
            result.Element = _context.Payements.Find(id);
            if(result.Element != null)
            {
                _context.Payements.Remove(result.Element);
                result.Message = "Suprresion réussie.";
                result.StatusCode = "404";
                _context.SaveChanges();
            }
        }
        else
        {
            result.StatusCode = "404";
            result.Message = "Payement non trouvé.";
        }

        return JsonConvert.SerializeObject(result);
    }

    [HttpPut]
    [Route("payements/update")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> UpdatePayement(Payement payement)
    {
        try
        {
            if (_context.Payements.Any(x => x.Id == payement.Id))
            {
                var rep = _context.Payements.Update(payement);
                var result = new ApiResult<Payement>()
                {
                    Message = "Un payement à été mis à jour",
                    StatusCode = "200",
                    Element = rep.Entity
                };
                _context.SaveChanges();
                return JsonConvert.SerializeObject(result);
            }
            return JsonConvert.SerializeObject(new ApiResult<Payement>()
            {
                Message = "Payement non trouvé",
                StatusCode = "500",
                Element = payement
            });


        }
        catch (Exception ex)
        {
            return JsonConvert.SerializeObject(new ApiResult<Payement>()
            {
                Message = ex.Message,
                StatusCode = "500",
                Element = payement
            });

        }

    }

    [HttpGet]
    [Route("payements/exist/{reference}")]
    [Authorize(Roles = "Admin")]
    public ActionResult<string> ExistPayement(string reference)
    {
        var result = new ApiResult<Payement>();
        var payement = _context.Payements.Any(x => x.Reference == reference);
        if (payement)
            (result.StatusCode, result.Message) = ("200", "true");
        else
            (result.StatusCode, result.Message) = ("200", "false");
        return JsonConvert.SerializeObject(result);
    }

    #endregion


}
