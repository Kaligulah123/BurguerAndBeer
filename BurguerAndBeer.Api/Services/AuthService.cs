using BurguerAndBeer.Api.Data;
using BurguerAndBeer.Api.Data.Entities;
using BurguerAndBeer.Shared.Dtos;
using Microsoft.EntityFrameworkCore;

namespace BurguerAndBeer.Api.Services
{
    public class AuthService(DataContext context, TokenService tokenService, PasswordService passwordService)
    {
        private readonly DataContext _context = context;
        private readonly TokenService _tokenService = tokenService;
        private readonly PasswordService _passwordService = passwordService;

        public async Task<ResultWithDataDto<AuthResponseDto>> SignupAsync(SignupRequestDto dto)
        {
            if(await _context.Users.AsNoTracking().AnyAsync(u => u.Email == dto.Email))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Email already exists");
            }

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Address = dto.Address,
            };

            (user.Salt, user.Hash) = _passwordService.GenerateSaltAndHash(dto.Password);

            try
            {
                await _context.Users.AddAsync(user);
                await _context.SaveChangesAsync();

                return GenerateAuthResponse(user);
            }
            catch (Exception ex)
            {
                return ResultWithDataDto<AuthResponseDto>.Failure(ex.Message);
            }
        }

        private ResultWithDataDto<AuthResponseDto> GenerateAuthResponse(User user)
        {
            var loggedInUser = new LoggedInUser(user.Id, user.Name, user.Email, user.Address);
            var token = _tokenService.GenerateJwt(loggedInUser);

            var authResponse = new AuthResponseDto(loggedInUser, token);

            return ResultWithDataDto<AuthResponseDto>.Success(authResponse);
        }

        public async Task<ResultWithDataDto<AuthResponseDto>> SigninAsync(SigninRequestDto dto)
        {
            var dbUser = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (dbUser is null)
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("User does not exist");
            }

            if(!_passwordService.AreEqual(dto.Password, dbUser.Salt, dbUser.Hash))
            {
                return ResultWithDataDto<AuthResponseDto>.Failure("Incorrect password");
            }

            return GenerateAuthResponse(dbUser);
        }

        public async Task<ResultDto> ChangePasswordAsync(ChangePasswordDto dto, Guid userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user is null)
                return ResultDto.Failure("User does not exist");

            if(!_passwordService.AreEqual(dto.OldPassword, user.Salt, user.Hash))
            {
                return ResultDto.Failure("Incorrect password");
            }

            (user.Salt, user.Hash) = _passwordService.GenerateSaltAndHash(dto.NewPassword);

            await _context.SaveChangesAsync();
            return ResultDto.Success();
        }
    }
}
