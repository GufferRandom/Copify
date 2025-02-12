using Copify.Models;
using Copify.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.ObjectModel;
using Copify.Dto;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
namespace Copify.Service
{
    public class SpotifyGetNewReleases:ISpotifyNewReleases
    {
        private readonly HttpClient _httpClient;

        public SpotifyGetNewReleases(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<NewAlbumDto>> NewReleases(string CountryCode,int limit,string access_key){
            _httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",access_key);
            var response=await _httpClient.GetAsync($"browse/new-releases?country={CountryCode}&limit={limit}");
            response.EnsureSuccessStatusCode();
            var responseStream=await response.Content.ReadAsStreamAsync();
            var resultJson=await JsonSerializer.DeserializeAsync<Release>(responseStream);
            var albumDtos = resultJson.Albums.Items.Select(i =>new NewAlbumDto
            {
                Name = i.Name,
                ReleaseDate = i.ReleaseDate,
                uri = i.Uri,
                total_tracks = i.TotalTracks,
                href = i.Href,
                artists = i.Artists.Select(x => new ArtisDto
                {
                    Name = x.Name,
                    SpotifyId = x.Id,
                    href = x.Href,
                    uri = x.Uri
                }).ToList() 
            }); 
        return albumDtos;
         }
        

    }
}
