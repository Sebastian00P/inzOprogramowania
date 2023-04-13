using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services.AdsService
{
    public interface IAdsService
    {
        Task<List<Ads>> GetAll();
        Task CreateAds(Ads ads);
    }
}
