using System.Collections.Generic;

namespace WantedRobots.Models;

public class RobotData : IRobotData
{
    private int _nextId = 4;
    public List<Robot> Robots { get; } = new List<Robot>
        {
            new Robot
                {
                    Id = 1,
                    UrlImage = "https://robohash.org/Alice",
                    Nom = "Alice",
                    Taille = 5000,
                    Poids = 8000,
                    Pays = "Palestine"
                },
                new Robot
                {
                    Id = 2,
                    UrlImage = "https://robohash.org/Andre",
                    Nom = "Andre",
                    Taille = 104,
                    Poids = 8001,
                    Pays = "Turquie"
                },
                new Robot
                {
                    Id = 3,
                    UrlImage = "https://robohash.org/Bob",
                    Nom = "Bob",
                    Taille = 59,
                    Poids = 2500,
                    Pays = "Brésil"
                }
        };

    public void AddRobot(Robot newRobot)
    {
        newRobot.Id = _nextId;
        Robots.Add(newRobot);
        _nextId++;
    }

    public Robot GetRobotById(int idRobot)
    {
        // Recherchez le robot par son ID dans la liste
        var robot = Robots.FirstOrDefault(r => r.Id == idRobot);
        return robot;
    }
    public Robot GetRobotByName(string nomRobot)
    {
        var robot = Robots.FirstOrDefault(r => r.Nom == nomRobot);
        return robot;
    }

    public void UpdateRobotPays(int idRobot, string nouveauPays)
    {
        // Recherchez le robot par son ID dans la liste
        var robot = Robots.FirstOrDefault(r => r.Id == idRobot);
        if (robot != null)
        {
            robot.Pays = nouveauPays;
        }
    }

    public void DeleteRobot(int idRobot)
    {
        // Recherchez le robot par son ID dans la liste
        var robot = Robots.FirstOrDefault(r => r.Id == idRobot);

        if (robot != null)
        {
            // Supprimez le robot de la liste
            Robots.Remove(robot);

        }
    }
    public List<Robot> GetRobotsByCountry(string country)
    {
        return Robots.Where(r => string.Equals(r.Pays, country, StringComparison.OrdinalIgnoreCase)).ToList();
    }


}
