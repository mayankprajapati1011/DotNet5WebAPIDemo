namespace BusinessLayer.Dtos
{
    public class StateForCreateDto
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }
    }

    public class StateForListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
    }
   
}
