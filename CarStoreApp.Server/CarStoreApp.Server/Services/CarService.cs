using AutoMapper;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Interfaces.Repositories;
using CarStoreApp.Server.Interfaces.Services;

namespace CarStoreApp.Server.Services;

public class CarService(ICarRepository carRep, IMapper mapper) : ICarService
{

    public async Task<CarDto> CreateCar(CreateCarDto createCarDto)
    {
        var newCar = IBaseService.DtoToEntity<CreateCarDto, Car>(mapper, createCarDto);
        var insertedCar = await carRep.InsertAsync(newCar);

        var insertedCarDto = IBaseService.EntityToDto<Car, CarDto>(mapper, insertedCar);
        return insertedCarDto;
    }


    public async Task UpdateCar(UpdateCarDto updateCarDto)
    {
        await carRep.UpdateAsync(updateCarDto);
    }

    public async Task<IEnumerable<CarDto>> FindCars()
    {
        return await carRep.FindAsync(null);
    }

    public async Task<CarDto> FindCarById(int id)
    {
        return await carRep.FindOneAsync(car => car.Id == id);

    }


    public Task<bool> CarExists(int id)
    {
        throw new NotImplementedException();
    }
}
