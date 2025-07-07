using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MultiShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.AddressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                Country = createAddressCommand.Country,
                City = createAddressCommand.City,
                District = createAddressCommand.District,
                Detail = createAddressCommand.Detail,
                Detail2 = createAddressCommand.Detail2,
                UserId = createAddressCommand.UserId,
                Name = createAddressCommand.Name,
                Surname = createAddressCommand.Surname,
                Email = createAddressCommand.Email,
                Phone = createAddressCommand.Phone,
                Description = createAddressCommand.Description,
                ZipCode = createAddressCommand.ZipCode
            });
        }
    }
}
