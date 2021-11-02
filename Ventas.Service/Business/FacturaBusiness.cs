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
    public class FacturaBusiness : IFacturaBusiness
    {
        private readonly IMapper mapper;
        private readonly IFacturaRepository facturaRepository;
        private Logger logger = LogManager.GetCurrentClassLogger();
        public FacturaBusiness(IMapper mapper, IFacturaRepository facturaRepository)
        {
            this.mapper = mapper;
            this.facturaRepository = facturaRepository;
        }

        public ResultDto<FacturaDto> UpdateFactura(FacturaDto facturaDto)
        {

            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                Factura facturaUpdate = this.mapper.Map<FacturaDto, Factura>(facturaDto);
                int updateOk = this.facturaRepository.UpdateFactura(facturaUpdate);

                if (updateOk == 1)
                {
                    resultDto.BusinessDto = new List<FacturaDto>();
                    resultDto.BusinessDto.Add(facturaDto);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del factura",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<FacturaDto> GetFacturaByIdActive(long id)
        {
            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                Factura factura = this.facturaRepository.GetFacturaById(id);
                if (factura != null)
                {
                    FacturaDto facturaDtoSave = this.mapper.Map<Factura, FacturaDto>(factura);
                    resultDto.BusinessDto = new List<FacturaDto>();
                    resultDto.BusinessDto.Add(facturaDtoSave);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<FacturaDto> DeleteFactura(long id)
        {
            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                Factura facturaUpdate = new Factura();
                facturaUpdate.Id = id;
                int updateOk = this.facturaRepository.DeleteFactura(facturaUpdate);

                if (updateOk == 1)
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del factura",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }


        public ResultDto<FacturaDto> SaveFactura(FacturaDto facturaDto)
        {
            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                Factura facturaSave = this.mapper.Map<FacturaDto, Factura>(facturaDto);
                Factura facturaSaveResult = this.facturaRepository.SaveFactura(facturaSave);
                if (facturaSaveResult != null)
                {
                    FacturaDto facturaDtoSave = this.mapper.Map<Factura, FacturaDto>(facturaSaveResult);
                    resultDto.BusinessDto = new List<FacturaDto>();
                    resultDto.BusinessDto.Add(facturaDtoSave);
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La actualización del factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "No se realizo la actualización del factura",
                        Response = Response.FAIL.GetDescription()
                    };
                }
            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La actualización del factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<FacturaDto> GetAllByStatus()
        {
            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                List<Factura> factura = this.facturaRepository.GetAllByStatus();
                if (factura != null && factura.Count > 0)
                {
                    List<FacturaDto> facturaDtoSave = this.mapper.Map<List<Factura>, List<FacturaDto>>(factura);
                    resultDto.BusinessDto = facturaDtoSave;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }

        public ResultDto<FacturaDto> GetAll()
        {
            ResultDto<FacturaDto> resultDto = new ResultDto<FacturaDto>();
            try
            {
                List<Factura> factura = this.facturaRepository.GetAll();
                if (factura != null && factura.Count > 0)
                {
                    List<FacturaDto> facturaDtoSave = this.mapper.Map<List<Factura>, List<FacturaDto>>(factura);
                    resultDto.BusinessDto = facturaDtoSave;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.OK.GetDescription()
                    };
                }
                else
                {
                    resultDto.BusinessDto = null;
                    resultDto.ResponseDto = new ResponseDto()
                    {
                        Message = "La consulta de factura se realizo de forma exitosa",
                        Response = Response.FAIL.GetDescription()
                    };
                }


            }
            catch (Exception ex)
            {

                resultDto.BusinessDto = null;
                resultDto.ResponseDto = new ResponseDto()
                {
                    Message = "La consulta de factura genero un error",
                    Response = Response.FAIL.GetDescription()
                };
                logger.Error(ex.ToString());
            }

            return resultDto;
        }        
    }
}
