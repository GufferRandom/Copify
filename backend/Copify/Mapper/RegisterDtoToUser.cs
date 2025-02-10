using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Copify.Dto;
using Copify.Models;

namespace Copify.Mapper
{
    public static class RegisterDtoToUser
    {
        public static AppUser ToAppUser(RegisterDto registerDto){
            
            AppUser user = new AppUser(){
                FirstName=registerDto.FirstName,
                UserName=registerDto.UserName,
                LastName =registerDto.LastName,
                PhoneNumber=registerDto.PhoneNumber,
                Email=registerDto.Gmail,
                Country=registerDto.Country,
                City=registerDto.City
            };
            return user;
        }
    }
}