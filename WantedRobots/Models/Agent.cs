namespace WantedRobots.Models
{
    public class Agent
    {

        public int Id { get; set; }
        public string? UrlImage { get; set; }
        public string? Nom { get; set; }
        public string? Zone { get; set; }
         public List<int> RobotIds { get; set; } = new List<int>(); 

        // Propriété statique pour suivre le prochain ID
        public static int NextId { get; private set; } = 4;
      
    }

}