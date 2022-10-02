using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using MarkDav.Splore.Models;

namespace MarkDav.Splore.Repository
{
    public class SploreRepository : ISploreRepository, ITransientService
    {
        private readonly SploreContext _db;

        public SploreRepository(SploreContext context)
        {
            _db = context;
        }

        public IEnumerable<Models.Splore> GetSplores(int ModuleId)
        {
            return _db.Splore.Where(item => item.ModuleId == ModuleId);
        }

        public Models.Splore GetSplore(int SploreId)
        {
            return GetSplore(SploreId, true);
        }

        public Models.Splore GetSplore(int SploreId, bool tracking)
        {
            if (tracking)
            {
                return _db.Splore.Find(SploreId);
            }
            else
            {
                return _db.Splore.AsNoTracking().FirstOrDefault(item => item.SploreId == SploreId);
            }
        }

        public Models.Splore AddSplore(Models.Splore Splore)
        {
            _db.Splore.Add(Splore);
            _db.SaveChanges();
            return Splore;
        }

        public Models.Splore UpdateSplore(Models.Splore Splore)
        {
            _db.Entry(Splore).State = EntityState.Modified;
            _db.SaveChanges();
            return Splore;
        }

        public void DeleteSplore(int SploreId)
        {
            Models.Splore Splore = _db.Splore.Find(SploreId);
            _db.Splore.Remove(Splore);
            _db.SaveChanges();
        }
    }
}
