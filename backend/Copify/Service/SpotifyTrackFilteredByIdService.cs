using System.Collections.Generic;
using System.Net.Http.Headers;
using Copify.Interfaces;
using System.Text.Json;
using Copify.SpotifyModels;
using Copify.Models;
namespace Copify.Service
{
    public class SpotifyTrackFilteredByIdService : ISpotifyTrackFilteredById
    {
        private readonly HttpClient _httpClient;

        public SpotifyTrackFilteredByIdService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<SpotifyTrackFilteredById> TrackById(string Id, string access_key)
        {
            try
            {

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_key);
            var response = await _httpClient.GetAsync($"tracks/{Id}");
            response.EnsureSuccessStatusCode();
            using var responseStream = await response.Content.ReadAsStreamAsync();
            var resultJson = await JsonSerializer.DeserializeAsync<Track>(responseStream);
            SpotifyTrackFilteredById spotifyRes = new()
            {
                TrackName = resultJson.name,
                DurationMs = resultJson.duration_ms,
                Trackhref = resultJson.href,
                TrackSpotifyId = resultJson.id,
                TrackType = resultJson.type,
                Artis = resultJson.artists.Select(x => new Artis
                {
                    ArtistsName = x.name,
                    ArtistsSpotifyId = x.id,
                    Artistshref = x.href,
                    Artistsuri = x.uri
                }).ToList(),
                ALBUM = new NewAlbum
                {
                    total_tracks = resultJson.album.TotalTracks,
                    uri = resultJson.album.Uri,
                    Name = resultJson.album.Name,
                    SpotifyId = resultJson.album.Id,
                    href = resultJson.album.Href,
                    ReleaseDate = resultJson.album.ReleaseDate,
                    artists = resultJson.album.Artists.Select(x => new Artis
                    {
                        ArtistsName = x.Name,
                        ArtistsSpotifyId = x.Id,
                        Artistshref = x.Href,
                        Artistsuri = x.Uri
                    }).ToList()
                }
            };
            return spotifyRes;
            }
            catch(Exception ex)
            {
                SpotifyTrackFilteredById sp = null;
                return sp;
            }
           
        }
    }
}
