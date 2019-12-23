using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeierSeguros.Domain.InsurerAssistances.Commands;
using BeierSeguros.Domain.Insurers.Commands;
using BeierSeguros.Domain.Insurers.Repositories;
using BeierSeguros.Domain.Insurers.ViewModels;
using BeierSeguros.Shared.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeierSeguros.Api.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class InsurersController : BaseApiController
    {
        private readonly IInsurerRepository _repository;

        private readonly IMapper _mapper;

        private readonly IMediator _mediator;

        public InsurersController(IInsurerRepository repository, IMapper mapper, IMediator mediator)
        {
            _repository = repository;
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _repository.GetByOrderedBy(x => x.Name).ToListAsync();
            var output = _mapper.Map<IEnumerable<InsurerViewModel>>(list);
            return Response(new Result(output));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateInsurerViewModel viewModel)
        {
            var command = _mapper.Map<CreateInsurerCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<InsurerViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var insurer = await _repository.GetById(id);

            if (insurer == null)
                return NotFound();

            var output = _mapper.Map<InsurerViewModel>(insurer);
            return Response(new Result(output));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] UpdateInsurerViewModel viewModel)
        {
            var command = _mapper.Map<UpdateInsurerCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<InsurerViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] DeleteInsurerViewModel viewModel)
        {
            var command = _mapper.Map<DeleteInsurerCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<InsurerViewModel>(result.Data);
            return Response(result, output);
        }


        [HttpPost("{insurerId}/assistances")]
        public async Task<IActionResult> Post(Guid insurerId, [FromBody] CreateInsurerAssistanceCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<InsurerViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpPut("{insurerId}/assistances/{assistanceId}")]
        public async Task<IActionResult> Put(Guid insurerId, Guid assistanceId, [FromBody] UpdateInsurerAssistanceCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<InsurerViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpDelete("{insurerId}/assistances/{assistanceId}")]
        public async Task<IActionResult> Delete(Guid insurerId, Guid assistanceId, [FromBody] DeleteInsurerAssistanceCommand command)
        {
            var result = await _mediator.Send(command, CancellationToken.None);
            return Response(result);
        }
    }
}