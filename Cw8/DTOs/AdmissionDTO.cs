namespace Cw8.DTOs;

public class AdmissionDTO
{
    public int Id { get; set; }

    public DateTime AdmissionDate { get; set; }

    public DateTime? DischargeDate { get; set; }

    public virtual WardDTO Ward { get; set; } = null!;
}