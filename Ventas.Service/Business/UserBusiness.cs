using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Ventas.Interface.Service;
using Ventas.Common.Utility;
using Ventas.Common.Dto;
using Ventas.Common.Helper;
using Ventas.Interface.Business;
using Ventas.Interface.Repository;
using Ventas.Common.Enumerator;
using AutoMapper;
using Ventas.Model.Model;
using NLog;

namespace Ventas.Service.Business
{
    public class UserBusiness : IUserBusiness
    {

        private readonly ITokenHelper tokenHelper;
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public UserBusiness(IMapper mapper, ITokenHelper tokenHelper, IUserRepository userRepository)
        {
            this.tokenHelper = tokenHelper;
            this.mapper = mapper;
            this.userRepository = userRepository;
        }

        public ResultDto<UserDto> Authenticate(string userName, string password)
        {
            ResultDto<UserDto> resultDto = new ResultDto<UserDto>();
            try
            {
                List<User> users = this.userRepository.SearchByNameAndPassword(userName, password);

                if (users != null && users.Count > 0)
                {
                    resultDto.BusinessDto = this.mapper.Map<List<User>, List<UserDto>>(users);
                    resultDto.BusinessDto.First().Token = this.tokenHelper.GetToken(7, resultDto.BusinessDto.FirstOrDefault().UserName);
                    resultDto.BusinessDto = ExtensionMethods.WithoutPasswords(resultDto.BusinessDto).ToList();
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "Usuario o contraseña inválido",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "Usuario o contraseña inválido",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de usuario genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<UserDto> SaveUser(UserDto userDto)
        {
            ResultDto<UserDto> resultDto = new ResultDto<UserDto>();
            try
            {
                User userSave = this.mapper.Map<UserDto, User>(userDto);
                User userSaveResult = this.userRepository.SaveUser(userSave);

                if (userSaveResult != null)
                {
                    UserDto userDtoSaveResult = this.mapper.Map<User, UserDto>(userSaveResult);
                    resultDto.BusinessDto = new List<UserDto>();
                    resultDto.BusinessDto.Add(userDtoSaveResult);                    
                    resultDto.BusinessDto = ExtensionMethods.WithoutPasswords(resultDto.BusinessDto).ToList();
                }
                else
                {
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "Usuario o contraseña inválido",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de usuario genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }
    }
}