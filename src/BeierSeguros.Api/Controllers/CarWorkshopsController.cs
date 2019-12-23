using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeierSeguros.Domain.CarWokshops.Repositories;
using BeierSeguros.Domain.CarWorkshops.Commands;
using BeierSeguros.Domain.CarWorkshops.ViewModels;
using BeierSeguros.Domain.CarWorkshopsInsurers.Command;
using BeierSeguros.Shared.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CarWorkshopsController : BaseApiController
    {
        private readonly ICarWorkshopRepository _repository;

        private readonly IMediator _mediator;

        private readonly IMapper _mapper;

        public CarWorkshopsController(ICarWorkshopRepository repository, IMediator mediator, IMapper mapper)
        {
            _repository = repository;
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetByOrderedBy(x => x.Name).Include(x => x.City).ToListAsync();
            var output = _mapper.Map<IEnumerable<CarWorkshopViewModel>>(list);
            return Response(new Result(output));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCarWorkshopViewModel viewModel)
        {
            var command = _mapper.Map<CreateCarWorkshopCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CarWorkshopViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _repository.GetByIdIncludeInsurers(id);

            if (entity == null)
                return NotFound();

            var output = _mapper.Map<CarWorkshopViewModel>(entity);
            return Response(new Result(output));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCarWorkshopViewModel viewModel)
        {
            var command = _mapper.Map<UpdateCarWorkshopCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CarWorkshopViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteCarWorkshopViewModel viewModel)
        {
            var command = _mapper.Map<DeleteCarWorkshopCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CarWorkshopViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpPost("{id}/insurers")]
        public async Task<IActionResult> Post(Guid id, [FromBody] CreateCarWorkshopInsurerCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CarWorkshopViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpDelete("{id}/insurers/{carworkshopInsurerId}")]
        public async Task<IActionResult> Delete(Guid id, Guid carworkshopInsurerId, [FromBody] DeleteCarWorkshopInsurerCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CarWorkshopViewModel>(result.Data);
            return Response(result, output);
        }
    }
}