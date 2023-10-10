namespace Entities.FilterModels
{
    public class UserFilterModel
    {
        public int MinAge { get; set; }
        public int MaxAge { get; set; }
        public string? Name { get; set; } = "";
        public string? Email { get; set; } = "";
                     
        public string? SortType { get; set; }
        public bool AgeIsValid() => MinAge < MaxAge;
    }
}
