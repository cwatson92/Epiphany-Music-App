using EpiphanyMusic.Data;
using EpiphanyMusic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EpiphanyMusic.Services
{
    public class ConcertService
    {
        private readonly Guid _userId;

        public ConcertService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateConcert(ConcertCreate model)
        {
            var entity =
                new Concert()
                {
                    OwnerId = _userId,
                    Artist = model.Artist,
                    TourName = model.TourName,
                    City = model.City,
                    State = model.State,
                    Price = model.Price,
                    Date = model.Date,

                    CreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Concerts.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<ConcertListItem> GetNotes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Concerts
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new ConcertListItem
                                {
                                    ConcertId = e.ConcertId,
                                    TourName = e.TourName,
                                    City = e.City,
                                    State = e.State,
                                    Price = e.Price,
                                    Date = e.Date,
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
                    ConcertDetail toReturn = new ConcertDetail
                    {
                        ConcertId = entity.ConcertId,
                        Artist = entity.Artist,
                        TourName = entity.TourName,
                        City = entity.City,
                        State = entity.State,
                        Price = entity.Price,
                        DateTime = entity.Date,
                        CreatedUtc = entity.CreatedUtc,
                        ModifiedUtc = entity.ModifiedUtc
                    };
                return toReturn;
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
                entity.TourName = model.TourName;
                entity.City = model.City;
                entity.State = model.State;
                entity.Price = model.Price;
                entity.Date = model.Date;

                entity.ModifiedUtc = DateTimeOffset.UtcNow;
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
                            .Single(e => e.ConcertId == Id && e.OwnerId == _userId);

                    ctx.Concerts.Remove(entity);

                    return ctx.SaveChanges() == 1;
                }
            }
    }
}
    
    
