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
    List<Robot> GetRobotsByCountry(string country);

}