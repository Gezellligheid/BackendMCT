using System;
using AutoMapper;

namespace oef01.Models
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Vaccinatie, VaccinatieDTO>();
        }
    }
}
