namespace Copify.Models
{
    public class SpotifyTrackFilteredById
    {
        public string TrackName { get; set; }
        public NewAlbum ALBUM { get; set; }
        public ICollection<Artis> Artis { get; set; }
        public int DurationMs { get; set; } = 0;
        public string TrackType { get; set; }
        public string Trackhref { get; set; }
        public string TrackSpotifyId { get; set; }
    }
}
