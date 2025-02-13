using System.Diagnostics;
using System.Net.Http.Headers;
using Copify.Interfaces;
using Copify.Models;
using Copify.SpotifyModels;
using System.Text.Json;
namespace Copify.Service
{
    public class SpotifyGetAlbumTracks:ISpotifyGetAlbumTracks
    {
        private readonly HttpClient _httpClient;
        public SpotifyGetAlbumTracks(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<IEnumerable<AlbumTrackFiltred>> GetAlbumTracks(string albumId,int limit, string access_key)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_key);
            var response = await _httpClient.GetAsync($"albums/{albumId}/tracks?limit={limit}");
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync();
            var resultJson = await JsonSerializer.DeserializeAsync<AlbumTracks>(stream);
            var albumTrackFiltered = resultJson.items.Select(i => new AlbumTrackFiltred
            {
                name = i.name,
                duration_ms= i.duration_ms,
                uri= i.uri,
                explicitLyrics= i._explicit,
                SpotifyId = i.id,
                is_playable = i.is_playable,
                track_number = i.track_number,
                artists = i.artists.Select(x => new Artis
                {
                    ArtistsName = x.name,
                    ArtistsSpotifyId = x.id,
                    Artistshref = x.href,
                    Artistsuri = x.uri
                }).ToList()
            }).ToList();
            return albumTrackFiltered;
        }
    }
}
