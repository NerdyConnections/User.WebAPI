﻿using AutoMapper;
using User.Domain.DTO;
using User.Domain.Models;

namespace User.WebAPI.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {

            //mapping dtos with domain object and vice versa
            CreateMap<UserModel, UserModelDTO>().ReverseMap();

            CreateMap<Department, DepartmentDTO>().ReverseMap();
        }
    }
}
