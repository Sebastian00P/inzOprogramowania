using inzOprogramowania.DataContext;
using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;
using inzOprogramowania.Repos;
using Microsoft.EntityFrameworkCore;

namespace inzOprogramowania.Services.CommentsService
{
    public class CommentsService : ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        public async Task<List<CommentsDto>> GetCommentsByAdId(long adsId)
        {
            var comments = await _commentsRepository.GetAll();
            return comments.Where(x => x.AdsId == adsId).OrderBy(x => x.CreationTime).ToList();
        }
        public async Task CreateComment(CommentsDto comment)
        {
            await _commentsRepository.CreateComment(comment);
        }
        public async Task EditComment(CommentsDto comment)
        {
            await _commentsRepository.EditComment(comment);
        }

    }
}
