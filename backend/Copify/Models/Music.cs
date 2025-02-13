using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
namespace Copify.Models
{
    public class Music
    {
        [Required]
        public int id { get; set; }
        [Required]
        public string Name { set; get; } = string.Empty;
        public string Album { get; set; } = string.Empty;
        public DateTime DataAdded { get; set; } = DateTime.Now;
        public int Duration { get; set; } = 0;
        public Author? author{get;set;}
    }
}