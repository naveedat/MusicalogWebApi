
namespace MusicalogApi.Models
{
    public partial class AlbumInfo
    {
        public long AlbumId { get; set; }
        public string Label { get; set; }

        public virtual Album Album { get; set; }
    }
}
