namespace WantedRobots.Test;

using System;
using WantedRobots.Models;

[TestClass]
public class UnitRobotDataTest
{
    IRobotData robotData = new RobotData();

    [TestMethod]
    public void TestAddRobotCount()
    {

        Assert.AreEqual(robotData.Robots.Count, 3);
        Robot robot = new Robot
        {
            Id = 98,
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "haha"
        };
        robotData.AddRobot(robot);
        Assert.AreEqual(robotData.Robots.Count, 4);

    }
    [TestMethod]
    public void TestDeleteRobotCount()
    {
        Assert.AreEqual(robotData.Robots.Count, 3);
        Robot robot = new Robot
        {
            Id = 98,
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "haha"
        };
        robotData.AddRobot(robot);
        robotData.DeleteRobot(4);
        Assert.AreEqual(robotData.Robots.Count, 3);
    }
    [TestMethod]
    public void TestUpdateRobotPays()
    {

        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "haha"
        };
        robotData.AddRobot(robot1);
        robotData.UpdateRobotPays(4, "Perou");
        Assert.AreEqual(robot1.Pays, "Perou");
    }
}