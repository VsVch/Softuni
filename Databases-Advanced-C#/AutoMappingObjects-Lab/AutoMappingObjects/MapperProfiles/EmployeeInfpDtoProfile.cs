using AutoMapper;
using AutoMappingObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AutoMappingObjects.MapperProfiles
{
   public class EmployeeInfpDtoProfile : Profile
    {
        public EmployeeInfpDtoProfile()
        {
            this.CreateMap<Employee, EmployeInfoDto>()
                      .ForMember(x => x.FullName, options =>
                      {
                          options.MapFrom(x => string.Join(" ", x.FirstName, x.LastName));
                      })
                      .ForMember(x => x.ProjectsName, options =>
                      {
                          options.MapFrom(x => string.Join(", ", x.EmployeesProjects.Select(x => x.Project.Name)));
                      })
                      .ReverseMap();
            
        }
    }
}
