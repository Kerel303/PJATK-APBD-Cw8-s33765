using Cw8.Data;
using Microsoft.EntityFrameworkCore;

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
        List<Patient> list = new List<Patient>();
        if (search == null)
        {
            list = context.Patients.Where(patient => patient.Sex == patient.Sex).Include(p => p.Admissions).ToList();
            return list;
        }
        
        list = context.Patients.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search)).ToList();
        
        return list;
    }
}