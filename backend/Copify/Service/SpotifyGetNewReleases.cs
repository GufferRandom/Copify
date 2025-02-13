using Copify.Interfaces;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Reflection.Metadata.Ecma335;
using Copify.SpotifyModels;
using Copify.Models;
namespace Copify.Service
{
    public class SpotifyGetNewReleases:ISpotifyNewReleases
    {
        private readonly HttpClient _httpClient;

        public SpotifyGetNewReleases(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<NewAlbum>> NewReleases(int limit,string access_key){
            _httpClient.DefaultRequestHeaders.Authorization=new AuthenticationHeaderValue("Bearer",access_key);
            var response=await _httpClient.GetAsync($"browse/new-releases?limit={limit}");
            response.EnsureSuccessStatusCode();
           using var responseStream=await response.Content.ReadAsStreamAsync();
            var resultJson=await JsonSerializer.DeserializeAsync<Release>(responseStream);
            var albumDtos = resultJson.Albums.Items.Select(i =>new NewAlbum
            {
                Name = i.Name,
                ReleaseDate = i.ReleaseDate,
                uri = i.Uri,
                total_tracks = i.TotalTracks,
                href = i.Href,
                SpotifyId=i.Id,
                artists = i.Artists.Select(x => new Artis
                {
                    ArtistsName = x.Name,
                    ArtistsSpotifyId = x.Id,
                    Artistshref = x.Href,
                    Artistsuri = x.Uri
                }).ToList() 
            }); 
        return albumDtos;
         }
        

    }
}
