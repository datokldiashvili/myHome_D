namespace API.DTOs
{
    public class FilterDto
    {
       
        public string Location { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
        
    }
}
