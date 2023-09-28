using System.Collections.Generic;

namespace WantedRobots.Models;

public class AgentData : IAgentData
{
    private int _nextId = 1004;

     // Initialisez la liste AgentRobotLinks dans le constructeur
   
    public List<Agent> Agents { get; } = new List<Agent>
        {
            new Agent
                {
                   Id = 1001,
                   Nom = "Killer",
                   UrlImage = "https://good-hawk-21.deno.dev/Killer",
                   Zone = "Canada"
                },
                new Agent
                {
                    Id = 1002,
                    UrlImage = "https://good-hawk-21.deno.dev/Exterminator",
                    Nom = "Exterminator",
                    Zone = "Maroc"
                },
                new Agent
                {
                    Id = 1003,
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

    public Agent GetAgentById(int idAgent)
    {
        // Recherchez le robot par son ID dans la liste
        var agent = Agents.FirstOrDefault(r => r.Id == idAgent);
        return agent;
    }


}
