using inzOprogramowania.ModelDtos;
using inzOprogramowania.Modeles;

namespace inzOprogramowania.Repos
{
    public interface ICommentsRepository
    {
        Task<List<CommentsDto>> GetAll();
        Task CreateComment(CommentsDto commentDto);
        Task EditComment(CommentsDto commentDto);
    }
}