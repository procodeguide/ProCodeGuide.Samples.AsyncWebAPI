namespace ProCodeGuide.Samples.AsyncWebAPI.DBEntities
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? Designation { get; set; }
        public double Salary { get; set; }
    }
}
