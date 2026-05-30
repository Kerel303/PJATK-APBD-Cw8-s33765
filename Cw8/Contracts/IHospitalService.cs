namespace Cw8.Contracts;

using Cw8.Models;

public interface IHospitalService
{
    public List<Patient> GetPatients(string? search);
}