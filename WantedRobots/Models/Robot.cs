namespace WantedRobots.Models
{
    public class Robot
    {

        public int Id { get; set; }
        public string? UrlImage { get; set; }
        public string? Nom { get; set; }
        public int Taille { get; set; }
        public int Poids { get; set; }
        public string? Pays { get; set; }
        // ASSIGNER UN AGENT //
        public int? AgentId { get; set; } 
        // COMMENTAIRE DE L'AGENT //
         public List<Comment>? Commentaires { get; set; } 
        

        // Propriété statique pour suivre le prochain ID
        public static int NextId { get; private set; } = 4;
        public List<string>? HistoriquePays {get;set;}

       
    }

    
}