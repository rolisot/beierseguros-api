using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeierSeguros.Domain.Cities.Commands;
using BeierSeguros.Domain.Cities.Repositories;
using BeierSeguros.Domain.Cities.ViewModels;
using BeierSeguros.Shared.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CitiesController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly ICityRepository _repository;

        private readonly IMapper _mapper;

        public CitiesController(IMediator mediator, ICityRepository repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetByOrderedBy(x => x.Name).ToListAsync();
            var output = _mapper.Map<IEnumerable<CityViewModel>>(list);
            return Response(new Result(output));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCityViewModel viewModel)
        {
            var command = _mapper.Map<CreateCityCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CityViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var city = await _repository.GetById(id);

            if (city == null)
                return NotFound();

            var output = _mapper.Map<CityViewModel>(city);
            return Response(new Result(output));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateCityViewModel viewModel)
        {
            var command = _mapper.Map<UpdateCityCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<CityViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteCityViewModel viewModel)
        {
            var command = _mapper.Map<DeleteCityCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            return Response(result);
        }
    }
}