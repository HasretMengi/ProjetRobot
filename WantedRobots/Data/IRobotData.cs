using System.Collections.Generic;
using System.Linq;

namespace WantedRobots.Models;

public interface IRobotData
{

    public List<Robot> Robots { get; }
    public void AddRobot(Robot newRobot);
    public Robot GetRobotById(int idRobot);
    public Robot GetRobotByName(string nomRobot);
    public void UpdateRobotPays(int idRobot, string nouveauPays);
    public void DeleteRobot(int idRobot);
    public void AssignAgent (int robotId, int agentId);
    public void UnassignAgent(int robotId);
     public void SubmitComment(int robotId, string agentId, string commentaire, int note);
    List<Robot> GetRobotsByCountry(string country);

}