namespace Cw8.DTOs;

public class PatientDTO
{
    public string Pesel { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public int Age { get; set; }

    public bool Sex { get; set; }

    public List<AdmissionDTO> Admissions { get; set; } = new List<AdmissionDTO>();

    public List<BedAssignmentDTO> BedAssignments { get; set; } = new List<BedAssignmentDTO>();
}