namespace Copify.Dto
{
    public class NewAlbumDto{
        public string Name{get;set;}
        public string ReleaseDate{get;set;}
        public string uri  {get;set;}
        public int total_tracks{get;set;}
        public string href{get;set;}
        public string SpotifyId{get;set;}
        public ICollection<ArtisDto> artists{get;set;}
    }
    public class ArtisDto{
        public string Name{get;set;}
        public string href{get;set;}
        public string  uri {get;set;}
        public string SpotifyId{get;set;}

    }
}
