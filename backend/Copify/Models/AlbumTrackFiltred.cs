namespace Copify.Models
{
    public class AlbumTrackFiltred
    {
        public ICollection<Artis> artists { get; set; }
        public int duration_ms { get; set; }
        public bool explicitLyrics { get; set; }
        public string SpotifyId { get; set; }
        public bool is_playable { get; set; }
        public string name { get; set; }
        public int track_number { get; set; }
        public string uri { get; set; }
    }
}
