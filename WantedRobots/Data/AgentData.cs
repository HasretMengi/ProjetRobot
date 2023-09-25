using System.Collections.Generic;

namespace WantedRobots.Models;

public class AgentData : IAgentData
{
    private int _nextId = 4;
    public List<Agent> Agents { get; } = new List<Agent>
        {
            new Agent
                {
                   Id = 1,
                   Nom = "Killer",
                   UrlImage = "https://good-hawk-21.deno.dev/Killer",
                   Zone = "Canada"
                },
                new Agent
                {
                    Id = 2,
                    UrlImage = "https://good-hawk-21.deno.dev/Exterminator",
                    Nom = "Exterminator",
                    Zone = "Maroc"
                },
                new Agent
                {
                    Id = 3,
                    UrlImage = "https://good-hawk-21.deno.dev/Reaper",
                    Nom = "Reaper",
                    Zone = "Palestine"
                }
        };

    public void AddAgent(Agent newAgent)
    {
        newAgent.Id = _nextId;
        Agents.Add(newAgent);
        _nextId++;
    }

   /* public Agent GetAgentById(int idAgent)
    {
        // Recherchez le agent par son ID dans la liste
        var agent = Agents.FirstOrDefault(r => r.Id == idAgent);
        return agent;
    }
    public Agent GetAgentByName(string nomAgent)
    {
        var agent = Agents.FirstOrDefault(r => r.Nom == nomAgent);
        return agent;
    }*

    /* public void UpdateAgentPays(int idRobot, string nouveauPays)
     {
         // Recherchez le agent par son ID dans la liste
         var agent = Agents.FirstOrDefault(r => r.Id == idRobot);
         if (agent != null)
         {
             agent.Pays = nouveauPays;
         }
     }

     public void DeleteRobot(int idAgent)
     {
         // Recherchez le agent par son ID dans la liste
         var agent = Agents.FirstOrDefault(r => r.Id == idAgent);

         if (agent != null)
         {
             // Supprimez le agent de la liste
             Agents.Remove(agent);

         }
     }*/
    /*public List<Agent> GetRobotsByCountry(string country)
    {
        return Agents.Where(r => string.Equals(r.Zone, country, StringComparison.OrdinalIgnoreCase)).ToList();
    }*/


}
