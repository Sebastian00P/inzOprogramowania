using inzOprogramowania.DataContext;
using inzOprogramowania.Modeles;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly DatabaseContext _databaseContext;
        public AdsService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<List<Ads>> GetAll()
        {
            return await _databaseContext.Ads.ToListAsync();
        }
        public async Task CreateAds(Ads ads)
        {
            _databaseContext.Ads.Add(ads);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
