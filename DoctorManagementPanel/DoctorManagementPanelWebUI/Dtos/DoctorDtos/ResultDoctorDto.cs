namespace DoctorManagementPanelWebUI.Dtos.DoctorDtos
{
    public class ResultDoctorDto
    {
        public int DoctorID { get; set; }
        public string? DoctorName { get; set; }
        public string? DoctorSurname { get; set; }
        public string? Degree { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? StartingDate { get; set; }
        public bool? Status { get; set; }
        public bool? IsExists { get; set; }
        public string BranchName { get; set; }
    }
}
