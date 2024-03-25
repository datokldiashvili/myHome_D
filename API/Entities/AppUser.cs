using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {

    public DateTime DateOfBirth { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow; 
    public DateTime LastActive { get; set; } = DateTime.UtcNow; 
    public int GenderId { get; set; } 
    public Gender Gender { get; set; } 
    public int CityId { get; set; } 
    public City City { get; set; } 
    public int CountryId { get; set; }
    public Country Country { get; set; } 
    public List<Photo> Photos { get; set; }
    public List<UserLike> LikedByUsers { get; set; }
    public List<UserLike> LikedUsers { get; set; }
    public ICollection<AppUserRole> UserRoles { get; set; }

}

public class Gender
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }
}

public class City
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }
}

public class Country
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<AppUser> Users { get; set; }
}

    }
