using AutoMapper;
using FluentValidation;
using MediatR;
using PETHOST.Domain.Repositories;


namespace PETHOST.Application.User.CreateUser
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, CreateUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var validator = new CreateUserCommandValidator();
            var validationResult = await validator.ValidateAsync(command, cancellationToken);

            if (!validationResult.IsValid)
                throw new ValidationException(validationResult.Errors);

            var existingUser = await _userRepository.GetByEmailAsync(command.Email, cancellationToken);
            if (existingUser != null)
                throw new DomainException(BusinessRuleMessages.UserEmailExists(command.Email).Detail);

            var user = _mapper.Map<User>(command);
            user.Password = _passwordHasher.HashPassword(command.Password);

            var createdUser = await _userRepository.CreateAsync(user, cancellationToken);
            var result = _mapper.Map<CreateUserResponse>(createdUser);
            return result;
        }
    }
}
