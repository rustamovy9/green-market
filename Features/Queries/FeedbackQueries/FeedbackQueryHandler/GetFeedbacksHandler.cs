using System.Linq.Expressions;
using GreenMarket.API.Extensions.Mappers;
using GreenMarket.API.Extensions.PatternResultExtensions;
using GreenMarket.Data;
using GreenMarket.Features.Entities;
using GreenMarket.Features.Queries.FeedbackQueries.FeedbackViewModels;
using GreenMarket.Repositories.BaseRepository;
using GreenMarket.Responses;
using GreenMarket.UOW;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Features.Queries.FeedbackQueries.FeedbackQueryHandler;

public sealed class GetFeedbacksHandler(IUnitOfWork<Feedback> unitOfWork) : IRequestHandler<GetFeedbackVmRequest, Result<PagedResponse<IEnumerable<GetFeedbackVm>>>>
{

    public async Task<Result<PagedResponse<IEnumerable<GetFeedbackVm>>>> Handle(GetFeedbackVmRequest request, CancellationToken cancellationToken)
    {
        IGenericFindRepository<Feedback> repository = unitOfWork.FeedbackFindRepository;

        Expression<Func<Feedback, bool>> filterExpression = feedback =>
            (request.Filter.MinRating == null || feedback.Rating >= request.Filter.MinRating) &&
            (request.Filter.MaxRating == null || feedback.Rating <= request.Filter.MaxRating) &&
            (string.IsNullOrEmpty(request.Filter.Comment) || feedback.Comment.ToLower().Contains(request.Filter.Comment.ToLower()));

        IEnumerable<Feedback> query = (await repository
            .FindAsync(filterExpression)).ToList();
        
        int totalRecords = query.Count();
        
        
        IEnumerable<GetFeedbackVm> result =  query
            .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
            .Take(request.Filter.PageSize)
            .Select(x => x.ToReadInfo()).ToList();
        

        PagedResponse<IEnumerable<GetFeedbackVm>> response = PagedResponse<IEnumerable<GetFeedbackVm>>.Create(
            request.Filter.PageNumber, 
            request.Filter.PageSize, 
            totalRecords, 
            result
        );

        return Result<PagedResponse<IEnumerable<GetFeedbackVm>>>.Success(response);
    }
}
