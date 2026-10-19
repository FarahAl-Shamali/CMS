using AutoMapper;
using ContentMS.Core.Constants;
using ContentMS.Core.DTOs;
using ContentMS.Core.Exceptions;
using ContentMS.Core.ViewModels;
using ContentMS.Data;
using ContentMS.Data.Models;
using ContentMS.Infrastructure.Services.Email;
using ContentMS.Infrastructure.Services.Files;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContentMS.Infrastructure.Services.Users
{
    public class UserService
    {
        private readonly CMSDbContext _db;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly UserManager<User> _userManager;

        public UserService(CMSDbContext db, IMapper mapper, UserManager<User> userManager, IFileService fileService, IEmailService emailService)
        {
            _db = db;
            _mapper = mapper;
            _userManager = userManager;
            _fileService = fileService;
            _emailService = emailService;
        }
        public async Task<List<UserViewModel>> GetAll()
        {
            var users =await _db.Users.Where(x=>!x.IsDelete).ToListAsync();
            return _mapper.Map<List<UserViewModel>>(users);
        }
        public async Task<string> Create(UserDto dto)
        {
            var EmailOrPhoneExist = _db.Users.Any(x=>(x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber)
            && !x.IsDelete
            );
            if (EmailOrPhoneExist)
            {
                throw new DuplicatedEmailOrPhoneException();
            }
            var user = _mapper.Map<User>(dto);
            user.UserName = dto.Email;
            if(dto.Image != null)
            {
                user.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImageFolder);
            }
            var result =await _userManager.CreateAsync(user);
            var password = GeneratePassword();
            if (!result.Succeeded)
            {
                throw new OperationFailedException();
            }
            _emailService.Send(user.Email, "New Account!", $"Username is {user.Email} and password is {password}");
            return user.Id;
  
        
        }
        public async Task<string> Update(UserDto dto)
        {
            var EmailOrPhoneExist = _db.Users.Any(x=>
            (x.Email == dto.Email || x.PhoneNumber == dto.PhoneNumber)
            && !x.IsDelete
            && x.Id != dto.Id
            );
            if (EmailOrPhoneExist)
            {
                throw new DuplicatedEmailOrPhoneException();
            }
            var user = await _db.Users.FindAsync(dto.Id);
            var updatedUser = _mapper.Map<UserDto, User>(dto, user);
            user.UserName = dto.Email;
            if(dto.Image != null)
            {
                updatedUser.ImageUrl = await _fileService.SaveFile(dto.Image, FolderNames.ImageFolder);
            }
            var result =await _userManager.CreateAsync(user);
            _db.Users.Update(updatedUser);
            await _db.SaveChangesAsync();
            return user.Id;      
        }





        public async Task<string> Delete(string Id)
        {
            var user = await _db.Users.SingleOrDefaultAsync(x=>x.Id == Id && !x.IsDelete);
            if(user == null)
            {
                throw new EntityNotFoundException();
            }
            user.IsDelete = true;
            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            return Id;
        }
        private string GeneratePassword()
        {
            return Guid.NewGuid().ToString().Substring(1, 8);
        }

    }
}
