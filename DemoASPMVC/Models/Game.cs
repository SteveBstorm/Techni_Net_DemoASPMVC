﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DemoASPMVC.Models
{
    public class Game
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [DisplayName("Titre du jeu")]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
    }
}