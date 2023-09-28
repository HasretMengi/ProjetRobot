using System.Collections.Generic;
using System.Linq;

namespace WantedRobots.Models;

public interface IAgentData
{

    public List<Agent> Agents { get; }
    public void AddAgent(Agent newAgent);
    public Agent GetAgentById(int idAgent);

}