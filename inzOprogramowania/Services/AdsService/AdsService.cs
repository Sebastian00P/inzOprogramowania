using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Repos;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Services.AdsService
{
    public class AdsService : IAdsService
    {
        private readonly IAdsRepository _adsRepository;
        public AdsService(IAdsRepository adsRepository)
        {
            _adsRepository = adsRepository;
        }

        public async Task<List<AdsDto>> GetAll()
        {
            var dateTime = DateTime.Now;
            var daysToDisplay = dateTime.AddDays(-14);
            var ads = await _adsRepository.GetAll();
            return ads.Where(x => x.ExpiredTime > dateTime && x.CreationTime >= daysToDisplay).ToList();
        }
        public async Task CreateAds(AdsDto ads)
        {
            await _adsRepository.CreateAds(ads);           
        }
        public async Task<List<AdsDto>> GetAllByUserId(long userId)
        {
            return await _adsRepository.GetAllByUserId(userId);
        }
        public async Task<AdsDto> GetAddById(long adsId)
        {           
            return await _adsRepository.GetAddById(adsId);
        }
        public async Task EditAds(AdsDto ads)
        {
            await _adsRepository.EditAds(ads);
        }
    }
}
