
namespace MusicalogApi.Models.DTO
{
    public static class AlbumDtoMapper
    {
        public static AlbumDto MapToDto(Album album)
        {
            return new AlbumDto()
            {
                Id = album.Id,
                Name = album.Name,
                Artist = album.Artist,
                Type = album.Type,
                Stock = album.Stock,

                AlbumInfo = new AlbumInfoDto()
                {
                    AlbumId = album.Id,
                    Label = album.AlbumInfo.Label
                }
            };
        }
    }
}
