using AutoMapper;
using NLog;
using Ventas.Common.Dto;
using Ventas.Common.Enumerator;
using Ventas.Common.Helper;
using Ventas.Common.Utility;
using Ventas.Interface.Business;
using Ventas.Interface.Repository;
using Ventas.Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ventas.Service.Business
{
    public class ProductoBusiness : IProductoBusiness
    {
        private readonly IMapper mapper;
        private readonly IProductoRepository rearDerailleurTypeRepository;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public ProductoBusiness(IMapper mapper, IProductoRepository rearDerailleurTypeRepository)
        {
            this.mapper = mapper;
            this.rearDerailleurTypeRepository = rearDerailleurTypeRepository;
        }

        public ResultDto<ProductoDto> UpdateProducto(ProductoDto rearDerailleurTypeDto)
        {

            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                Producto rearDerailleurTypeUpdate = this.mapper.Map<ProductoDto, Producto>(rearDerailleurTypeDto);
                int updateOk = this.rearDerailleurTypeRepository.UpdateProducto(rearDerailleurTypeUpdate);

                if (updateOk == 1)
                {
                    resultDto.BusinessDto = new List<ProductoDto>();
                    resultDto.BusinessDto.Add(rearDerailleurTypeDto);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del rearDerailleurType",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<ProductoDto> GetProductoByIdActive(long id)
        {
            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                Producto rearDerailleurType = this.rearDerailleurTypeRepository.GetProductoById(id);
                if (rearDerailleurType != null)
                {
                    ProductoDto rearDerailleurTypeDtoSave = this.mapper.Map<Producto, ProductoDto>(rearDerailleurType);
                    resultDto.BusinessDto = new List<ProductoDto>();
                    resultDto.BusinessDto.Add(rearDerailleurTypeDtoSave);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<ProductoDto> DeleteProducto(long id)
        {
            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                Producto rearDerailleurTypeUpdate = new Producto();
                rearDerailleurTypeUpdate.Id = id;
                int updateOk = this.rearDerailleurTypeRepository.DeleteProducto(rearDerailleurTypeUpdate);

                if (updateOk == 1)
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del rearDerailleurType",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }


        public ResultDto<ProductoDto> SaveProducto(ProductoDto rearDerailleurTypeDto)
        {
            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                Producto rearDerailleurTypeSave = this.mapper.Map<ProductoDto, Producto>(rearDerailleurTypeDto);
                Producto rearDerailleurTypeSaveResult = this.rearDerailleurTypeRepository.SaveProducto(rearDerailleurTypeSave);
                if (rearDerailleurTypeSaveResult != null)
                {
                    ProductoDto rearDerailleurTypeDtoSave = this.mapper.Map<Producto, ProductoDto>(rearDerailleurTypeSaveResult);
                    resultDto.BusinessDto = new List<ProductoDto>();
                    resultDto.BusinessDto.Add(rearDerailleurTypeDtoSave);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del rearDerailleurType",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<ProductoDto> GetAllByStatus()
        {
            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                List<Producto> rearDerailleurType = this.rearDerailleurTypeRepository.GetAllByStatus();
                if (rearDerailleurType != null && rearDerailleurType.Count > 0)
                {
                    List<ProductoDto> rearDerailleurTypeDtoSave = this.mapper.Map<List<Producto>, List<ProductoDto>>(rearDerailleurType);
                    resultDto.BusinessDto = rearDerailleurTypeDtoSave;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<ProductoDto> GetAll()
        {
            ResultDto<ProductoDto> resultDto = new ResultDto<ProductoDto>();
            try
            {
                List<Producto> rearDerailleurType = this.rearDerailleurTypeRepository.GetAll();
                if (rearDerailleurType != null && rearDerailleurType.Count > 0)
                {
                    List<ProductoDto> rearDerailleurTypeDtoSave = this.mapper.Map<List<Producto>, List<ProductoDto>>(rearDerailleurType);
                    resultDto.BusinessDto = rearDerailleurTypeDtoSave;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de rearDerailleurType se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de rearDerailleurType genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }        
    }
}
