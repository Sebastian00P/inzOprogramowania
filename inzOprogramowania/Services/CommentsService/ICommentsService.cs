﻿using inzOprogramowania.Modeles;

namespace inzOprogramowania.Services.CommentsService
{
    public interface ICommentsService
    {
        Task<List<Comments>> GetCommentsByAdId(long adsId);
    }
}
