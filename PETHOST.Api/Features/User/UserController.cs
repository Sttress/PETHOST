using MediatR;
using Microsoft.AspNetCore.Mvc;
using PETHOST.Api.Common;

namespace PETHOST.Api.Features.User
{
    public class UserController : BaseController
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator) 
        { 
            _mediator = mediator;
        }

        //[HttpPost]
        //[ProducesResponseType(typeof(ApiResponseWithData))]
        //public async Task<IActionResult> CreateUser()
        //{

        //}
    }
}
