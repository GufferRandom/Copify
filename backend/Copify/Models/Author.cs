using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Copify.Models
{
    public class Author
    {
        [Required]
        public int Id{get;set;}
        [Required]
        public string Name{get;set;}=string.Empty;
        public DateTime DataAdded{get;set;}=DateTime.Now;
        public string Description{get;set;}=string.Empty;
        public bool Verify=false;
        public int? Music_Id{get;set;}
        public ICollection<Music>? musics;
    }
}