using AutoMapper;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
using CarStoreApp.Server.Interfaces.Repositories;
using CarStoreApp.Server.Interfaces.Services;

namespace CarStoreApp.Server.Services;

public class CarService(ICarRepository carRep, IMapper mapper, IHttpContextAccessor httpContextAccessor) : ICarService
{

    public async Task<CarDto> CreateCar(CreateCarDto createCarDto)
    {
        // Validate the input DTO if necessary
        var newCar = IBaseService.DtoToEntity<CreateCarDto, Car>(mapper, createCarDto);
        var insertedCar = await carRep.InsertAsync(newCar);

        // Save changes to the database
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

    public async Task<IEnumerable<CarPhotoDto>> SaveCarPhotos(int carId, IList<IFormFile> photos)
    {

        var carPhotoDtos = new List<CarPhotoDto>();

        foreach (var file in photos)
        {
            // Validate the file type and size if necessary
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "CarsPhotos", fileName);

            // Ensure the directory exists
            var directory = Path.GetDirectoryName(filePath);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            // Create the URL for the saved file
            var relativePath = Path.Combine("CarsPhotos", fileName);
            var request = httpContextAccessor.HttpContext.Request;
            var baseUrl = $"{request.Scheme}://{request.Host}";
            var publicUrl = Path.Combine(baseUrl, relativePath).Replace("\\", "/");

            // Save the photo information to the database
            var carPhotoDto = await carRep.InsertPhotoAsync(carId, publicUrl, fileName);
            carPhotoDtos.Add(carPhotoDto);
        }

        await carRep.SaveChangesAsync();
        return carPhotoDtos;
    }
}
