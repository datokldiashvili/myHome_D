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
    var users = _context.Users.OrderBy(u => u.UserName).AsQueryable();
    var likes = _context.Likes.AsQueryable();

    if (predicate == "liked")
    {
        likes = likes.Where(like => like.SourceUserId == userId);
        users = likes.Select(like => like.TargetUser);
    }
    if (predicate == "likedBy")
    {
        likes = likes.Where(like => like.TargetUserId == userId);
        users = likes.Select(like => like.SourceUser);
    }

    var usersList = await users.ToListAsync();

    return usersList.Select(user => new LikeDto
{
    Username = user.UserName,
    Age = CalculateAge(user.DateOfBirth), 
    PhotoUrl = user.Photos.FirstOrDefault(x => x.IsMain)?.Url,
    City = user.City,
    Id = user.Id
});

}

        public Task<AppUser> GetUserWithLikes(int userId)
        {
            throw new NotImplementedException();
        }

        private int CalculateAge(DateTime dateOfBirth)
{
    int age = DateTime.UtcNow.Year - dateOfBirth.Year;

    if (dateOfBirth > DateTime.UtcNow.AddYears(-age))
        age--;

    return age;
}


}
    }
