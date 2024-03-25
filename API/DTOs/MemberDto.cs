using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MemberDto
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhotoUrl { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public GenderDto Gender { get; set; } 
        public CityDto City { get; set; } 
        public CountryDto Country { get; set; } 
        public List<PhotoDto> Photos { get; set; }
    }
}
