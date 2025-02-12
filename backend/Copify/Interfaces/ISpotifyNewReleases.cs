using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations;
using Copify.Models;
using Copify.Dto;

namespace Copify.Interfaces
{
    public interface ISpotifyNewReleases
    {
        Task<IEnumerable<NewAlbumDto>> NewReleases(string CountryCode,int limit,string access_key);

    }
}