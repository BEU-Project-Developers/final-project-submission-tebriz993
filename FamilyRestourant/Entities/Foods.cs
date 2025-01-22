﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FamilyRestourant.Entities
{
    public class Foods
    {
        [Required]
        public int Id { get; set; }
        public string? Image { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }

        public string Title { get; set; }
        public double Price { get; set; }
        public string Subtitle { get; set; }
        public List<MenusFoods> MenusFoods { get; set; }
    }
}
