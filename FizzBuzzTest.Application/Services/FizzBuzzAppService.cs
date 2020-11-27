using System.Threading.Tasks;
using AutoMapper;
using FizzBuzzTest.Application.Dtos;
using FizzBuzzTest.Application.Interfaces;
using FizzBuzzTest.Domain.Interfaces;

namespace FizzBuzzTest.Application.Services
{
	public class FizzBuzzAppService : IFizzBuzzAppService
	{
		private readonly IMapper mapper;
		private readonly IFizzBuzzService fizzBuzzService;

		public FizzBuzzAppService(
			IMapper mapper, 
			IFizzBuzzService fizzBuzzService)
		{
			this.mapper = mapper;
			this.fizzBuzzService = fizzBuzzService;
		}

		public async Task<FizzBuzzDto> GetFizzBuzzResult(int startNumber, int limitNumber)
		{
			var fizzBuzzEntity = await this.fizzBuzzService.GetFizzBuzzResult(startNumber, limitNumber);
			var fizzBuzzDto = mapper.Map<FizzBuzzDto>(fizzBuzzEntity);
			return fizzBuzzDto;
		}
	}
}
