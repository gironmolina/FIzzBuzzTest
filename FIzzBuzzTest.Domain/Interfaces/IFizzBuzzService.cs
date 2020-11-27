﻿using System.Threading.Tasks;
using FizzBuzzTest.Domain.Model;

namespace FizzBuzzTest.Domain.Interfaces
{
	public interface IFizzBuzzService
	{
		Task<FizzBuzz> GetFizzBuzzResult(int startNumber, int limitNumber);
	}
}
