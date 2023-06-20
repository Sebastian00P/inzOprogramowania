using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Repos
{
    public interface IAdsRepository
    {
        Task<List<AdsDto>> GetAllByUserId(long userId);
        Task<List<AdsDto>> GetAll();
        Task CreateAds(AdsDto adsDto);
        Task<AdsDto> GetAddById(long adsId);
        Task EditAds(AdsDto adsDto);
    }
}