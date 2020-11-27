using System.Threading.Tasks;
using FizzBuzzTest.Application.Dtos;

namespace FizzBuzzTest.Application.Interfaces
{
	public interface IFizzBuzzAppService
	{
		Task<FizzBuzzDto> GetFizzBuzzResult(int startNumber, int limitNumber);
	}
}
