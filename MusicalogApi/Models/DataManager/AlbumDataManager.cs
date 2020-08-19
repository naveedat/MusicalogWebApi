using Microsoft.EntityFrameworkCore;
using MusicalogApi.Models.DTO;
using MusicalogApi.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicalogApi.Models.DataManager
{
    public class AlbumDataManager : IDataRepository<Album, AlbumDto>
    {
        readonly AlbumStoreContext _albumStoreContext;

        public AlbumDataManager(AlbumStoreContext albumStoreContext)
        {
            _albumStoreContext = albumStoreContext;
        }

        public IEnumerable<Album> GetAll()
        {
            return _albumStoreContext.Album
                .Include(album => album.AlbumInfo)
                .ToList();
        }

        public Album Get(long id)
        {
            var album = _albumStoreContext.Album
                .Include(a => a.AlbumInfo)
                .SingleOrDefault(b => b.Id == id);

            return album;
        }

        public AlbumDto GetDto(long id)
        {
            _albumStoreContext.ChangeTracker.LazyLoadingEnabled = true;

            using (var context = new AlbumStoreContext())
            {
                var album = context.Album
                    .Include(a => a.AlbumInfo)
                    .SingleOrDefault(b => b.Id == id);

                if (album != null) {
                    return AlbumDtoMapper.MapToDto(album);
                }  
                
                return null;
            }
        }

        public void Add(Album entity)
        {
            _albumStoreContext.Album.Add(entity);
            _albumStoreContext.SaveChanges();
        }

        public void Delete(Album entity)
        {
            _albumStoreContext.Remove(entity);
            _albumStoreContext.SaveChanges();
        }
        
        public void Update(Album entityToUpdate, Album entity)
        {
            entityToUpdate = _albumStoreContext.Album
                .Include(a => a.AlbumInfo)
                .Single(b => b.Id == entityToUpdate.Id);

            entityToUpdate.Name = entity.Name;
            entityToUpdate.Artist = entity.Artist;
            entityToUpdate.Type = entity.Type;
            entityToUpdate.Stock = entity.Stock;

            entityToUpdate.AlbumInfo.Label = entity.AlbumInfo.Label;

            _albumStoreContext.SaveChanges();
        }
    }
}
