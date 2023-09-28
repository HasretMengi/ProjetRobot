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
    private readonly IAgentData agentData;
 

    public AgentController(ILogger<AgentController> logger, IAgentData agentData )
    {
        _logger = logger;
        this.agentData = agentData;
      
    }


    public IActionResult AgentList()
    {
        var agents = agentData.Agents;
       
        return View(agents);
    }



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



    public IActionResult CountryError()
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

