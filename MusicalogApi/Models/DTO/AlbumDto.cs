
namespace MusicalogApi.Models.DTO
{
    public class AlbumDto
    {
        public AlbumDto()
        {
        }
        public long Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Type { get; set; }
        public bool Stock { get; set; }

        public AlbumInfoDto AlbumInfo { get; set; }
    }
}
