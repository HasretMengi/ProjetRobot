// Comment.cs
namespace WantedRobots.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int AgentId { get; set; } // ID de l'agent ayant laissé le commentaire
        public string? Commentaire { get; set; }
        public int Note { get; set; }
    }
}
