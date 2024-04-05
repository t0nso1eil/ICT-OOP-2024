using System;
using System.Threading.Tasks;
using MentallHealthSupport.Application.Abstractions.Persistence.Repositories;
using MentallHealthSupport.Application.Exceptions;
using MentallHealthSupport.Application.Models.Dto.Review;
using MentallHealthSupport.Application.Models.Entities;

namespace MentallHealthSupport.Application.Events.Handlers.Review
{
    public class UpdateReviewHandler
    {
        private readonly IReviewRepository _reviewRepository;

        public UpdateReviewHandler(IReviewRepository reviewRepository)
        {
            _reviewRepository = reviewRepository;
        }

        public async Task<Models.Entities.Review> Handle(Guid reviewId, UpdateReviewRequest updateReviewRequest)
        {
            var review = await _reviewRepository.GetReviewById(reviewId);

            if (review == null)
            {
                throw new ReviewNotFoundException($"Review with ID {reviewId} not found.");
            }

            if (updateReviewRequest.Rate != null)
            {
                review.Rate = updateReviewRequest.Rate.Value;
            }

            if (updateReviewRequest.Description != null)
            {
                review.Description = updateReviewRequest.Description;
            }

            await _reviewRepository.UpdateReview(review);

            return review;
        }
    }
}