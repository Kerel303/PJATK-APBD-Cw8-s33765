namespace Cw8.Contracts;

using Cw8.DTOs;

public interface IHospitalService
{
    public List<PatientDTO> GetPatients(string? search);
}