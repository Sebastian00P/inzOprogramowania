using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Services.CommentsService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inzOprogramowania.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;
        public CommentsController (ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }
        [Route("GetAllByAdsId")]
        [HttpGet]
        public async Task<List<CommentsDto>> GetAllByAdsId(long adsId)
        {
           return await _commentsService.GetCommentsByAdId(adsId);
        }
        [Route("CreateComment")]
        [HttpPost]
        public async Task CreateComment(CommentsDto commentsDto)
        {
            await _commentsService.CreateComment(commentsDto);
        }
    }
}
