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
            var dateTime = DateTime.Now;
            return await _databaseContext.Ads.Where(x => x.ExpiredTime > dateTime).ToListAsync();
        }
        public async Task CreateAds(Ads ads)
        {
            _databaseContext.Ads.Add(ads);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task<List<Ads>> GetAllByUserId(long userId)
        {
            return await _databaseContext.Ads.Where(x => x.UserId == userId).ToListAsync();
        }
        public async Task<Ads> GetAddById(long adsId)
        {           
            return await _databaseContext.Ads.Where(x => x.AdsId == adsId).FirstOrDefaultAsync();
        }
        public async Task EditAds(Ads ads)
        {
            _databaseContext.Ads.Update(ads);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
