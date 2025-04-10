using CarStoreApp.Server.Data;
using CarStoreApp.Server.DTOs;
using CarStoreApp.Server.Entities;
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

}
