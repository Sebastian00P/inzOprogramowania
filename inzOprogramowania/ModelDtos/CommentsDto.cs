using inzOprogramowania.Modeles;

namespace inzOprogramowania.ModelDtos
{
    public class CommentsDto
    {
        public long CommentId { get; set; }
        public string Content { get; set; }
        public DateTime CreationTime { get; set; }
        public long AdsId { get; set; }
        public long UserId { get; set; }     

        public CommentsDto MapCommentsDto(Comments comments)
        {
            var commentsDto = new CommentsDto()
            {
                CommentId = comments.CommentId,
                Content = comments.Content,
                CreationTime = comments.CreationTime,        
                AdsId = comments.AdsId,
                UserId = comments.UserId              
            };
            return commentsDto;
        }
    }
}
