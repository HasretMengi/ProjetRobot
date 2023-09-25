using Microsoft.AspNetCore.Mvc;
using WantedRobots.Models;
namespace WantedRobots.Controllers;


public class AddAgentRequest
{
    public string? Nom { get; set; }
    public int Id { get; set; }
    public string? Zone { get; set; }

}


public class AgentController : Controller
{
    
   private readonly List<string> AllowedCountries = CountryList.AllowedCountries;
    private readonly ILogger<AgentController> _logger;
    private readonly IAgentData agentData;//

    public AgentController(ILogger<AgentController> logger, IAgentData agentData)
    {
        _logger = logger;
        this.agentData = agentData;
    }


    public IActionResult AgentList()
    {
        var agents = agentData.Agents;
        return View(agents);
    }

    /*public ActionResult AgentDetails(int id)
    {
        // Recherchez le agent par son nom dans la liste
        var agent = agentData.GetAgentById(id);
        if (agent == null)
        {
            return NotFound();
        }
        return View(agent);
    }*/

    public IActionResult AddAgent()
    {
        return View();
    }



    [HttpPost]
    [ActionName("ajout-agent")]
    public IActionResult AjoutAgent(AddAgentRequest req)
    {
        if (!IsCountryValid(req.Zone))
        {
            return RedirectToAction("CountryError");
        }


        // Créez un nouveau agent avec le nouvel ID
        var newAgent = new Agent
        {
           
            Nom = req.Nom,
            Id = req.Id,
            Zone = req.Zone
        };

        
        // Ajoutez le nouveau agent à la liste existante
        agentData.AddAgent(newAgent);

        // Redirigez directement vers la page "WantedRobotList"
        return RedirectToAction("AgentList");
    }

    /*public IActionResult UpdateAgentPays()
    {

        return View();
    }*/

    /*[HttpPost]
    public IActionResult UpdateRobotPays(int idRobot, string nouveauPays)
    {
        if (!IsCountryValid(nouveauPays))
        {
            return RedirectToAction("CountryError");
        }

        // Appelez la méthode de mise à jour dans RobotData avec l'ID
        agentData.UpdateRobotPays(idRobot, nouveauPays);

        //Historique Pays 
        var agent = agentData.GetRobotById(idRobot);
        var ancienPays = agent.Pays;
        if (agent.HistoriquePays == null)
        {
            agent.HistoriquePays = new List<string>();
        }


        // Mettez à jour le pays actuel
        agent.Pays = nouveauPays;
        //Ajouter le pays a lhistorique
        agent.HistoriquePays.Add(ancienPays);

        // Redirigez vers la page de détails du agent mis à jour
        return RedirectToAction("RobotDetails", new { id = idRobot });
    }*/

   /* public IActionResult DeleteRobot()
    {

        return View();
    }

    [HttpPost]
    public IActionResult DeleteRobot(int idRobot)
    {
        // Appelez la méthode de mise à jour dans RobotData avec l'ID
        agentData.DeleteRobot(idRobot);

        // Redirigez l'utilisateur vers la page de détails du agent mis à jour
        return RedirectToAction("WantedRobotList");
    }*/

    public IActionResult CountryError()
    {
        return View();
    }
/*
    public IActionResult SearchByCountry(string country)
    {
        var agents = agentData.GetRobotsByCountry(country);
        if (IsCountryValid(country) == false)
        {
            return RedirectToAction("CountryError");

        }
        else if (agents.Count == 0)
        {
            return View("SearchCountryError");
        }
        else { return View("WantedRobotList", agents); }

    }

    public IActionResult SearchCountryError()
    {
        return View();
    }*/
    private bool IsCountryValid(string country)
    {
        // Convertir en minuscules pour ignorer la casse
        string countryLower = country.ToLower();

        // Convertir également la liste des pays en minuscules
        var allowedCountriesLower = AllowedCountries.Select(c => c.ToLower());

        return allowedCountriesLower.Contains(countryLower);
    }

}

