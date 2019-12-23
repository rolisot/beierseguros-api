using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using BeierSeguros.Api.Authentication;
using BeierSeguros.Domain.Users.Commands;
using BeierSeguros.Domain.Users.Repositories;
using BeierSeguros.Domain.Users.ViewModels;
using BeierSeguros.Shared.Contracts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BeierSeguros.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseApiController
    {
        private readonly IMediator _mediator;

        private readonly IUserRepository _repository;

        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IUserRepository repository, IMapper mapper)
        {
            _mediator = mediator;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody]AuthenticateUserViewModel viewModel)
        {
            var user = await _repository.Authenticate(viewModel.Email, viewModel.Password);

            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            var token = TokenServiceAuthentication.GenerateToken(user);

            return new
            {
                user = _mapper.Map<UserViewModel>(user),
                token = token
            };
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserViewModel viewModel)
        {
            var command = _mapper.Map<CreateUserCommand>(viewModel);
            var result = await _mediator.Send(command, CancellationToken.None);
            var output = _mapper.Map<UserViewModel>(result.Data);
            return Response(result, output);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> Get(Guid id)
        {
            var entity = await _repository.GetById(id);

            if (entity == null)
                return NotFound();

            var output = _mapper.Map<UserViewModel>(entity);
            return Response(new Result(output));
        }

        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put([FromBody] UpdateCityViewModel viewModel)
        // {
        //     var command = _mapper.Map<UpdateCityCommand>(viewModel);
        //     var result = await _mediator.Send(command, CancellationToken.None);
        //     var output = _mapper.Map<CityViewModel>(result.Data);
        //     return Response(result, output);
        // }

        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete([FromBody] DeleteCityViewModel viewModel)
        // {
        //     var command = _mapper.Map<DeleteCityCommand>(viewModel);
        //     var result = await _mediator.Send(command, CancellationToken.None);
        //     return Response(result);
        // }
    }
}