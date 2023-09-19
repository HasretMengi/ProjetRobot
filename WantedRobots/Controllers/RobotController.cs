using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WantedRobots.Models;
namespace WantedRobots.Controllers;


public class AddRobotRequest
{
    public string? Nom { get; set; }
    public int Taille { get; set; }
    public int Poids { get; set; }
    public string? Pays { get; set; }
}


public class RobotController : Controller
{
    private readonly List<string> AllowedCountries = CountryList.AllowedCountries;

    private readonly ILogger<RobotController> _logger;
    private readonly IRobotData robotData;//

    public RobotController(ILogger<RobotController> logger, IRobotData robotData)
    {
        _logger = logger;
        this.robotData = robotData;
    }


    public IActionResult WantedRobotList()
    {
        var robots = robotData.Robots;
        return View(robots);
    }

    public ActionResult RobotDetails(int id)
    {
        // Recherchez le robot par son nom dans la liste
        var robot = robotData.GetRobotById(id);
        if (robot == null)
        {
            return NotFound();
        }
        return View(robot);
    }

    public IActionResult AddRobot()
    {
        return View();
    }



    [HttpPost]
    [ActionName("ajout-robot")]
    public IActionResult AjoutRobot(AddRobotRequest req)
    {
        if (!IsCountryValid(req.Pays))
        {
            return RedirectToAction("CountryError");
        }

        // Trouvez la valeur de l'ID la plus élevée actuellement utilisée
        int maxId = robotData.Robots.Max(r => r.Id);

        // Incrémentez l'ID pour le nouveau robot
        int newId = maxId + 1;

        // Créez un nouveau robot avec le nouvel ID
        var newRobot = new Robot
        {
            Id = newId,
            Nom = req.Nom,
            Taille = req.Taille,
            Poids = req.Poids,
            Pays = req.Pays
        };

        // Ajoutez le pays initial à l'historique des pays du nouveau robot
        if (newRobot.HistoriquePays == null)
        {
            newRobot.HistoriquePays = new List<string>();
        }
        newRobot.HistoriquePays.Add(req.Pays); // Ajoutez le pays initial

        // Ajoutez le nouveau robot à la liste existante
        robotData.AddRobot(newRobot);

        // Redirigez directement vers la page "WantedRobotList"
        return RedirectToAction("WantedRobotList");
    }

    public IActionResult UpdateRobotPays()
    {

        return View();
    }

    [HttpPost]
    public IActionResult UpdateRobotPays(int idRobot, string nouveauPays)
    {
        if (!IsCountryValid(nouveauPays))
        {
            return RedirectToAction("CountryError");
        }

        // Appelez la méthode de mise à jour dans RobotData avec l'ID
        robotData.UpdateRobotPays(idRobot, nouveauPays);

        //Historique Pays 
        var robot = robotData.GetRobotById(idRobot);
        var ancienPays = robot.Pays;
        if (robot.HistoriquePays == null)
        {
            robot.HistoriquePays = new List<string>();
        }


        // Mettez à jour le pays actuel
        robot.Pays = nouveauPays;
        //Ajouter le pays a lhistorique
        robot.HistoriquePays.Add(ancienPays);

        // Redirigez vers la page de détails du robot mis à jour
        return RedirectToAction("RobotDetails", new { id = idRobot });
    }

    public IActionResult DeleteRobot()
    {

        return View();
    }

    [HttpPost]
    public IActionResult DeleteRobot(int idRobot)
    {
        // Appelez la méthode de mise à jour dans RobotData avec l'ID
        robotData.DeleteRobot(idRobot);

        // Redirigez l'utilisateur vers la page de détails du robot mis à jour
        return RedirectToAction("WantedRobotList");
    }

    public IActionResult CountryError()
    {
        return View();
    }

    public IActionResult SearchByCountry(string country)
    {
        var robots = robotData.GetRobotsByCountry(country);
        if (IsCountryValid(country) == false)
        {
            return RedirectToAction("CountryError");

        }
        else if (robots.Count == 0)
        {
            return View("SearchCountryError");
        }
        else { return View("WantedRobotList", robots); }

    }

    public IActionResult SearchCountryError()
    {
        return View();
    }
    private bool IsCountryValid(string country)
    {
        // Convertir en minuscules pour ignorer la casse
        string countryLower = country.ToLower();

        // Convertir également la liste des pays en minuscules
        var allowedCountriesLower = AllowedCountries.Select(c => c.ToLower());

        return allowedCountriesLower.Contains(countryLower);
    }

}

