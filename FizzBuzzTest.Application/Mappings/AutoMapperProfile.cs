using AutoMapper;
using FizzBuzzTest.Application.Dtos;
using FizzBuzzTest.Domain.Model;

namespace FizzBuzzTest.Application.Mappings
{
	public class AutoMapperProfile : Profile
	{
		public AutoMapperProfile()
		{
			CreateMap<FizzBuzzDto, FizzBuzz>().ReverseMap();
		}
	}
}
