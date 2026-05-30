using Cw8.Data;
using Cw8.DTOs;
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

    public List<PatientDTO> GetPatients(string? search)
    {
        List<PatientDTO> list = new List<PatientDTO>();
        if (search == null ||  search == "")
        {
            list = context.Patients.Select(p => new PatientDTO()
            {
                Pesel = p.Pesel,
                FirstName = p.FirstName,
                LastName = p.LastName,
                Age = p.Age,
                Sex = p.Sex,
                Admissions = p.Admissions.Select(a => new AdmissionDTO()
                {
                    Id = a.Id,
                    AdmissionDate = a.AdmissionDate,
                    DischargeDate = a.DischargeDate,

                    Ward = new WardDTO()
                    {
                        Id = a.Ward.Id,
                        Name = a.Ward.Name,
                        Description = a.Ward.Description
                    }
                }).ToList(),
                BedAssignments = p.BedAssignments.Select(b => new BedAssignmentDTO()
                {
                    Id = b.Id,
                    From = b.From,
                    To = b.To,
                    Bed = new BedDTO()
                    {
                        Id =  b.Bed.Id,
                        BedType = new BedTypeDTO()
                        {
                            Id = b.Bed.BedType.Id,
                            Name = b.Bed.BedType.Name,
                            Description = b.Bed.BedType.Description
                        },
                        Room = new RoomDTO()
                        {
                            Id = b.Bed.Room.Id,
                            HasTv = b.Bed.Room.HasTv,
                            Ward = new WardDTO()
                            {
                                Id = b.Bed.Room.Ward.Id,
                                Name = b.Bed.Room.Ward.Name,
                                Description = b.Bed.Room.Ward.Description
                            }
                        }
                    }
                }).ToList()
            }).ToList();
            return list;
        }
        
        
        list = context.Patients.Where(p => p.FirstName.Contains(search) || p.LastName.Contains(search)).Select(p => new PatientDTO()
        {
            Pesel = p.Pesel,
            FirstName = p.FirstName,
            LastName = p.LastName,
            Age = p.Age,
            Sex = p.Sex,
            Admissions = p.Admissions.Select(a => new AdmissionDTO()
            {
                Id = a.Id,
                AdmissionDate = a.AdmissionDate,
                DischargeDate = a.DischargeDate,

                Ward = new WardDTO()
                {
                    Id = a.Ward.Id,
                    Name = a.Ward.Name,
                    Description = a.Ward.Description
                }
            }).ToList(),
            BedAssignments = p.BedAssignments.Select(b => new BedAssignmentDTO()
            {
                Id = b.Id,
                From = b.From,
                To = b.To,
                Bed = new BedDTO()
                {
                    Id =  b.Bed.Id,
                    BedType = new BedTypeDTO()
                    {
                        Id = b.Bed.BedType.Id,
                        Name = b.Bed.BedType.Name,
                        Description = b.Bed.BedType.Description
                    },
                    Room = new RoomDTO()
                    {
                        Id = b.Bed.Room.Id,
                        HasTv = b.Bed.Room.HasTv,
                        Ward = new WardDTO()
                        {
                            Id = b.Bed.Room.Ward.Id,
                            Name = b.Bed.Room.Ward.Name,
                            Description = b.Bed.Room.Ward.Description
                        }
                    }
                }
            }).ToList()
        }).ToList();
        
        return list;
    }
}