using Copify.Models;

namespace Copify.Interfaces
{
    public interface ISpotifyGetAlbumTracks
    {
         Task<IEnumerable<AlbumTrackFiltred>> GetAlbumTracks(string albumId,int limit, string access_key);
    }
}
