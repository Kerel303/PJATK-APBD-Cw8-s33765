using Cw8.Data;

namespace Cw8.Services;

using Cw8.Contracts;
using Cw8.Models;

public class HospitalService : IHospitalService
{
    private readonly HospitalContext context;
    public HospitalService(HospitalContext context)
    {
        this.context = context;
    }

    public List<Patient> GetPatients(string? search)
    {
        var list = context.Patients.Where(patient => patient.Sex == patient.Sex).ToList();

        return list;
    }
}