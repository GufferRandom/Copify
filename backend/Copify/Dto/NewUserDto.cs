using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copify.Models
{
    public class NewUserDto
    {
        public string Email{get;set;} = string.Empty;
        public string UserName { get; set; } = string.Empty;
        public string Token{get;set;}
    }
}