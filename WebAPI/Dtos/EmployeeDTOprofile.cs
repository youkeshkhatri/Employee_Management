using AutoMapper;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Dtos
{
    public class EmployeeDTOprofile : Profile
    {
        public EmployeeDTOprofile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
