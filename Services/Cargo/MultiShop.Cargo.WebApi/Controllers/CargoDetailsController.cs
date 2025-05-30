﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(id);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new()
            {
                Barcode=createCargoDetailDto.Barcode,
                CargoCompanyId=createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayı Başarıyla Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Detayı Başarıyla Güncellendi");
        }
    }
}
