using EpiphanyMusic.Data;
using EpiphanyMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Services
{
    public class PlayListService
    {
        private readonly Guid _userId;

        public PlayListService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreatePlayList(PlayListCreate model)
        {
            var entity =
                new PlayList()
                {
                    OwnerId = _userId,
                    Artist = model.Artist,
                    Song = model.Song,
                    Genre = model.Genre,
                    Youtube = model.Youtube,

                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.PlayLists.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<PlayListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .PlayLists
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new PlayListItem
                                {
                                    PlayListId = e.PlayListId,
                                    Artist = e.Artist,
                                    Song = e.Song,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }


        public PlayListDetail GetPlayListById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                     .PlayLists
                     .Single(e => e.PlayListId == id && e.OwnerId == _userId);
                return
                    new PlayListDetail
                    {
                        PlayListId = entity.PlayListId,
                        Artist = entity.Artist,
                        Song = entity.Song,
                        Genre = entity.Genre,
                        Youtube = entity.Youtube,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }


        public bool UpdatePlayList(PlayListEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayLists
                        .Single(e => e.PlayListId == model.PlayListId);

                entity.Artist = model.Artist;
                entity.Song = model.Song;
                entity.Genre = model.Genre;
                entity.Youtube = model.Youtube;
                entity.ModifiedUtc = DateTimeOffset.UtcNow;
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeletePlayList(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .PlayLists
                        .Single(e => e.PlayListId == Id && e.OwnerId == _userId);

                ctx.PlayLists.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}