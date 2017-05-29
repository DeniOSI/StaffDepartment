namespace StaffDepartment.Models
{
    public interface IEducation
    {
        string CollegeName { get; set; }
        int DipNumber { get; set; }
        int EId { get; set; }
        string SeriesOfDiplom { get; set; }
        string Speciality { get; set; }
        int WId { get; set; }
        Worker Worker { get; set; }
    }
}