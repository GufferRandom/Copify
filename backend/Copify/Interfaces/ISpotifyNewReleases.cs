using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using Copify.Models;

namespace Copify.Interfaces
{
    public interface ISpotifyNewReleases
    {
        Task<IEnumerable<NewAlbum>> NewReleases(int limit,string access_key);
    }
}