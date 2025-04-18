﻿using System.Linq.Expressions;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;

namespace CarStoreApp.Server.Interfaces.Repositories;

public interface ICarRepository
{
    Task<bool> SaveChangesAsync();

    Task<CarDto> FindOneAsync(Expression<Func<Car, bool>> predicate);

    Task<IEnumerable<CarDto>> FindAsync(Expression<Func<Car, bool>> predicate);

    Task<Car> InsertAsync(Car car);

    Task UpdateAsync(UpdateCarDto updateCarDto);

    Task<Car> DeleteAsync(Car car);

    Task<CarPhotoDto> InsertPhotoAsync(int CarId, string Url,string Name);
}

