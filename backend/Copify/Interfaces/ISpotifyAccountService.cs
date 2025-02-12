using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copify.Service
{
    public interface ISpotifyAccountService
    {
        Task<string> GetToken(string clientId,string clientSecret);
    }
}