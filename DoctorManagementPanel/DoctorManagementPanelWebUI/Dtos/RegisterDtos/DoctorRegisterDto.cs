namespace DoctorManagementPanelWebUI.Dtos.RegisterDtos
{
    public class DoctorRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public int BranchID { get; set; }
        public string Degree { get; set; }
    }
}
