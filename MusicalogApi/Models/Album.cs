
namespace MusicalogApi.Models
{
    public partial class Album
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
        public bool Stock { get; set; }

        public virtual AlbumInfo AlbumInfo { get; set; }
    }
}
