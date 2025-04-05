using System.Linq.Expressions;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Helpers.Errors;
using CarStoreApp.Server.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarStoreApp.Server.Data.Repositories;

public class CarRepository(AppDBContext db, IMapper mapper) : ICarRepository
{
    public Task<Car> DeleteAsync(Car car)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<CarDto>> FindAsync(Expression<Func<Car, bool>> predicate)
    {

        return predicate == null
            ? await db.Cars.ProjectTo<CarDto>(mapper.ConfigurationProvider).ToListAsync()
            : await db.Cars.Where(predicate).ProjectTo<CarDto>(mapper.ConfigurationProvider).ToListAsync();

    }

    public async Task<CarDto> FindOneAsync(Expression<Func<Car, bool>> predicate)
    {
			return await db.Cars
        .Where(predicate) // Apply the predicate to filter the cars
        .ProjectTo<CarDto>(mapper.ConfigurationProvider) // Project to CarDto
        .FirstOrDefaultAsync(); // Get the first or default result

		}

    public async Task<Car> InsertAsync(Car car)
    {
        var _car = db.Cars.Add(car).Entity;
        await db.SaveChangesAsync();
        return _car;
    }

    public async Task UpdateAsync(UpdateCarDto updateCarDto)
    {
        var car = await db.Cars.FirstOrDefaultAsync(x => x.Id == updateCarDto.Id);
        if (car == null)
        {
            throw new NotFoundHttpException("Car not found");
        }

        mapper.Map(updateCarDto, car);
        await db.SaveChangesAsync();
    }
}

