using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Services;
using inzOprogramowania.Services.AdsService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdsController : ControllerBase
    {
        private readonly IAdsService _adsService;

        public AdsController(IAdsService adsService)
        {
            _adsService = adsService;
        }

        [Route("GetAll")]
        [HttpGet]
        public async Task<List<AdsDto>> GetAll()
        {
           return await _adsService.GetAll();
        }
        [Route("Create")]
        [HttpPost]
        public async Task Create(AdsDto ads)
        {
           await _adsService.CreateAds(ads);
        }
        [Route("GetAllByUserId")]
        [HttpGet]
        public async Task<List<AdsDto>> GetAllByUserId(long userId)
        {
            return await _adsService.GetAllByUserId(userId);
        }
        [Route("GetAdsById")]
        [HttpGet]
        public async Task<AdsDto> GetAdsById(long adsId)
        {
            return await _adsService.GetAddById(adsId);
        }
        [Route("EditAdd")]
        [HttpPost]
        public async Task EditAdd(AdsDto ads)
        {
            await _adsService.EditAds(ads);
        }
    }
}
