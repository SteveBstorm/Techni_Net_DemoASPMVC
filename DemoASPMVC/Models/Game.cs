using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoASPMVC.Models
{
    public class Game
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Titre du jeu")]
        [MinLength(5, ErrorMessage = "Le titre doit faire minimum 5 caractères")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}
