using EpiphanyMusic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Services
{
    class ConcertService
    {
        private readonly Guid _userId;

        public ConcertService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateConcert(ConcertCreate model)
        {
            var entity =
                new ConcertService()
                {
                    ConcertId = _userId,
                    Artist = model.Artist,
                    Location = model.Location,
                    Price = model.Price,
                    Date = model.Date,

                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Concert.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ConcertItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Concerts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ConcertItem
                                {
                                    ConcertId = e.ConcertId,
                                    Artist = e.Artist,
                                    Location = e.Location,
                                    Price = e. Price,
                                    DateTime = e.Date,
                                    CreatedUtc = e.CreatedUtc
                                }
                        );
                return query.ToArray();
            }
        }


        public ConcertDetail GetConcertById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx

                     .Concerts
                     .Single(e => e.ConcertId == id && e.OwnerId == _userId);
                return
                    new ConcertDetail
                    {
                        ConcertId = entity.ConcertId,
                        Artist = entity.Artist,
                        Location = entity.Location,
                        Price = entity.Price,
                        Date = entity.Date,
                    };
            }
        }


        public bool UpdateConcert(ConcertEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Concerts
                        .Single(e => e.ConcertId == model.ConcertId);

                entity.Artist = model.Artist;
                entity.Location = model.Location;
                entity.Price = model.Price;
                entity.Date = model.Date;
                return ctx.SaveChanges() == 1;
            }
        }


        public bool DeleteConcert(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Concerts
                        .Single(e => e.ConcertId == Id && e.OwnertId == _userId);

                ctx.Concerts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
