using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class LikesRepository : ILikesRepository
    {
        private readonly DataContext _context;

        public LikesRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<UserLike> GetUserLike(int sourceUserId, int targetUserId)
        {
            return await _context.Likes.FindAsync(sourceUserId, targetUserId);
        }

        public async Task<IEnumerable<LikeDto>> GetUserLikes(string predicate, int userId)
        {
            var likes = _context.Likes.AsQueryable();

            if (predicate == "liked")
            {
                likes = likes.Where(like => like.SourceUserId == userId);
            }
            else if (predicate == "likedBy")
            {
                likes = likes.Where(like => like.TargetUserId == userId);
            }

            var likedUsers = await likes
                .Select(like => new LikeDto
                {
                    Username = GetUsername(like, predicate),
                    Age = GetAge(like, predicate),
                    PhotoUrl = GetPhotoUrl(like, predicate),
                    City = GetCity(like, predicate),
                    Id = predicate == "liked" ? like.TargetUserId : like.SourceUserId
                })
                .ToListAsync();

            return likedUsers;
        }

        private string GetUsername(UserLike like, string predicate)
        {
            if (predicate == "liked")
            {
                if (like.TargetUser != null)
                    return like.TargetUser.UserName;
            }
            else if (predicate == "likedBy")
            {
                if (like.SourceUser != null)
                    return like.SourceUser.UserName;
            }
            return null;
        }

        private int GetAge(UserLike like, string predicate)
        {
            DateTime? dateOfBirth = predicate == "liked" ? like.TargetUser?.DateOfBirth : like.SourceUser?.DateOfBirth;
            if (dateOfBirth.HasValue)
            {
                int age = DateTime.UtcNow.Year - dateOfBirth.Value.Year;
                if (dateOfBirth.Value.Date > DateTime.UtcNow.Date.AddYears(-age))
                    age--;
                return age;
            }
            return 0; 
        }

        private string GetPhotoUrl(UserLike like, string predicate)
        {
            if (predicate == "liked")
            {
                if (like.TargetUser != null)
                    return like.TargetUser.Photos.FirstOrDefault(x => x.IsMain)?.Url;
            }
            else if (predicate == "likedBy")
            {
                if (like.SourceUser != null)
                    return like.SourceUser.Photos.FirstOrDefault(x => x.IsMain)?.Url;
            }
            return null;
        }

        private string GetCity(UserLike like, string predicate)
        {
            if (predicate == "liked")
            {
                if (like.TargetUser != null && like.TargetUser.City != null)
                    return like.TargetUser.City.Name;
            }
            else if (predicate == "likedBy")
            {
                if (like.SourceUser != null && like.SourceUser.City != null)
                    return like.SourceUser.City.Name;
            }
            return null;
        }

        public Task<AppUser> GetUserWithLikes(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
