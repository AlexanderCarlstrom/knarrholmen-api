using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using api.Contexts;
using api.Contracts;
using api.Contracts.Requests;
using api.Contracts.Responses;
using api.DTOs;
using api.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace api.Services
{
    public interface IAuthService
    {
        Task<ApiResponse> RegisterUserAsync(RegisterRequest model);
        Task<UserResponse> LoginUserAsync(LoginRequest model);
        Task<ApiResponse> RefreshTokenAsync(string refreshToken);
        Task<UserResponse> LoginWithTokenAsync(ClaimsPrincipal userPrincipal);
        Task<ApiResponse> LogoutUserAsync(LogoutRequest model);
        Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailRequest model);
        Task<ApiResponse> ForgetPasswordAsync([EmailAddress] string email);
        Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest model);
    }

    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly BookingDbContext _bookingDbContext;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager,
            BookingDbContext bookingDbContext, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _bookingDbContext = bookingDbContext;
            _mapper = mapper;
        }


        /// <summary>
        /// Creates a new user with given credentials and personal info
        /// </summary>
        public async Task<ApiResponse> RegisterUserAsync(RegisterRequest model)
        {
            // check if user already exist
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null) return new ApiResponse(422, "User already exist");

            var newUser = new User
            {
                FirstName = model.Firstname,
                LastName = model.Lastname,
                UserName = model.Email,
                Email = model.Email,
            };

            var result = await _userManager.CreateAsync(newUser, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                // TODO
                // Send confirmation email

                return new ApiResponse(true, 201);
            }

            // return user registration errors
            var errors = result.Errors.Select(err => err.Description);
            return new ApiResponse(400, "Could not register user, please try again", errors);
        }

        /// <summary>
        /// Login with given email and password
        /// </summary>
        public async Task<UserResponse> LoginUserAsync(LoginRequest model)
        {
            // Check if user exist
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null) return new UserResponse(400, "Wrong email or password");

            // Check if password is correct
            var passwordCheck = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordCheck) return new UserResponse(400, "Wrong email or password");

            // Check if email has been confirmed
            // var confirmed = await _userManager.IsEmailConfirmedAsync(user);
            // if (!confirmed) return new UserResponse(403, "Email must been confirmed");
            await _signInManager.SignInAsync(user, model.Remember);

            // Get user roles
            user.Roles = await _userManager.GetRolesAsync(user);

            // map to user dto
            var userDto = _mapper.Map<UserDTO>(user);

            if (!model.Remember) return new UserResponse(200, userDto);

            // Create refresh token
            var token = new RefreshToken(DateTime.Now.AddDays(30));
            user.RefreshTokens.Add(token);
            _bookingDbContext.Update(user);
            await _bookingDbContext.SaveChangesAsync();

            return new UserResponse(200, userDto, token);
        }

        public async Task<ApiResponse> RefreshTokenAsync(string refreshToken)
        {
            var token = await _bookingDbContext.RefreshTokens.FindAsync(refreshToken);
            if (token == null) return new ApiResponse(401, "invalid refresh token");

            var user = await _userManager.FindByIdAsync(token.UserId);
            await _signInManager.SignInAsync(user, true);

            return new ApiResponse(true, 200);
        }

        public async Task<UserResponse> LoginWithTokenAsync(ClaimsPrincipal userPrincipal)
        {
            var user = await _userManager.GetUserAsync(userPrincipal);
            if (user == null) return new UserResponse(400, "Could not find user");
            return new UserResponse(200, _mapper.Map<UserDTO>(user));
        }

        public async Task<ApiResponse> LogoutUserAsync(LogoutRequest model)
        {
            await _signInManager.SignOutAsync();

            if (model.RefreshToken == null) return new ApiResponse(true, 200);

            var refreshToken = _bookingDbContext.RefreshTokens.First(token =>
                token.Token == model.RefreshToken && token.UserId == model.UserId);
            if (refreshToken == null) return new ApiResponse(false, 400, "Something went wrong");

            _bookingDbContext.RefreshTokens.Remove(refreshToken);
            await _bookingDbContext.SaveChangesAsync();

            return new ApiResponse(true, 200);
        }

        public Task<ApiResponse> ConfirmEmailAsync(ConfirmEmailRequest model)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse> ForgetPasswordAsync([EmailAddress] string email)
        {
            throw new System.NotImplementedException();
        }

        public Task<ApiResponse> ResetPasswordAsync(ResetPasswordRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}