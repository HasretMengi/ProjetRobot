namespace WantedRobots.Test;


using WantedRobots.Models;

[TestClass]
public class UnitRobotDataTest
{
    IRobotData robotData = new RobotData(new AgentData());

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
            Pays = "Turquie"
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
            Pays = "Turquie"
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
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);
        robotData.UpdateRobotPays(4, "Turquie");
        Assert.AreEqual(robot1.Pays, "Turquie");
    }
    [TestMethod]
    public void TestGetRobotById()
    {

        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);
        Assert.AreEqual(robotData.GetRobotById(4).Id, 4);
    }
    [TestMethod]
    public void TestGetRobotByName()
    {

        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);
        Assert.AreEqual(robotData.GetRobotByName("Gucci").Nom, "Gucci");
    }
    [TestMethod]
    public void TestAssignAgent()
    {
        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);

        int agentId = 1001;

        robotData.AssignAgent(robot1.Id, agentId);

        var robot = robotData.GetRobotById(robot1.Id);
        Assert.AreEqual(agentId, robot.AgentId);
    }
    [TestMethod]
    public void TestUnassignAgent()
    {
        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);

        robotData.UnassignAgent(robot1.Id);

        Assert.AreEqual(robot1.AgentId, null);
    }

    public void TestSubmitComment()
    {

        Robot robot1 = new Robot
        {
            Nom = "Gucci",
            Taille = 89,
            Poids = 25,
            Pays = "Turquie"
        };
        robotData.AddRobot(robot1);

        robotData.SubmitComment(robot1.Id, "1001", "allo", 7);
        // Vérifiez que le robot a des commentaires après l'ajout
        Assert.IsNotNull(robot1.Commentaires);

        // Vérifiez que le nombre de commentaires est égal à 1
        Assert.AreEqual(1, robot1.Commentaires.Count);
        // Vérifiez le contenu du commentaire ajouté
        var addedComment = robot1.Commentaires[0];
        Assert.AreEqual(1001, addedComment.AgentId);
        Assert.AreEqual("allo", addedComment.Commentaire);
        Assert.AreEqual(7, addedComment.Note);

    }




}
