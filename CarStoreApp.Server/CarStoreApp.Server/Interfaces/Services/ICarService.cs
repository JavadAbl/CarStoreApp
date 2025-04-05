using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces.Services;

public interface ICarService :IBaseService
{
    Task<CarDto> CreateCar(CreateCarDto createCarDto);

    Task UpdateCar(UpdateCarDto updateCarDto);

    Task<IEnumerable<CarDto>> FindCars();
	
	 Task<CarDto> FindCarById(int id);

    Task<bool> CarExists(int id);

}