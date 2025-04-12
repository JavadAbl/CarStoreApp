using CarStoreApp.Server.Data;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace CarStoreApp.Server.Controllers;


// [Authorize]
[ApiController]
[Route("api/[controller]/[action]")]
public class CarsController(ICarService carService, AppDBContext appDB) : ControllerBase
{
    // [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<CarDto>> Create([FromBody] CreateCarDto createCarDto)
    {
        var car = await carService.CreateCar(createCarDto);

        return Ok(car);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CarDto>>> GetAll()
    {
        var cars = await carService.FindCars();

        return Ok(cars);
    }

    [HttpGet("/api/cars/{id}")]
    public async Task<ActionResult<CarDto>> GetById(int id)
    {
        var car = await carService.FindCarById(id);

        await Task.Delay(4000);
        return Ok(car);
    }

    [HttpPut]
    public async Task<ActionResult> Update([FromBody] UpdateCarDto updateCarDto)
    {
        await carService.UpdateCar(updateCarDto);
        return Ok();
    }



    [HttpPost]
    public async Task<ActionResult> UploadPhotos([FromForm] List<IFormFile> files, [FromForm] int CarId)
    {

        // Validate the files
        if (files == null || files.Count == 0)
            throw new BadHttpRequestException("No files received.");

        var validationErrors = ValidateImageFiles(files);
        if (validationErrors.Count > 0)
            throw new BadHttpRequestException(string.Join(" | ", validationErrors));

        var carPhotoDtos = await carService.SaveCarPhotos(CarId, files);

        return StatusCode(StatusCodes.Status201Created, carPhotoDtos);
    }


    private List<string> ValidateImageFiles(List<IFormFile> files)
    {
        var allowedExtensions = new[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp" };
        var errors = new List<string>();

        foreach (var file in files)
        {
            if (!file.ContentType.StartsWith("image/"))
            {
                errors.Add($"File '{file.FileName}' is not a valid image type (MIME).");
                continue;
            }

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            if (!allowedExtensions.Contains(extension))
            {
                errors.Add($"File '{file.FileName}' has an unsupported image extension '{extension}'.");
            }
        }

        return errors;
    }
}
