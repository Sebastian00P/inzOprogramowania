using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<List<CommentsDto>> GetCommentsByAdId(long adsId);
        Task CreateComment(CommentsDto comment);
        Task EditComment(CommentsDto comment);
    }
}
