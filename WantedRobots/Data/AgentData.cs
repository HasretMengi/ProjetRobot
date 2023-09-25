using System.Collections.Generic;

namespace WantedRobots.Models;

public class AgentData : IAgentData
{
    private int _nextId = 4;

     // Initialisez la liste AgentRobotLinks dans le constructeur
   
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

    




}
