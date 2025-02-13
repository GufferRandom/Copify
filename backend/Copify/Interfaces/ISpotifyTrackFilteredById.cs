using Copify.Models;    
namespace Copify.Interfaces
{
    public interface ISpotifyTrackFilteredById
    {
        Task<SpotifyTrackFilteredById> TrackById(string Id,string access_key);
    }
}
