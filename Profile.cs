using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.FieldDtos;
using HRMSCore.Dtos.FormDtos;
using HRMSCore.Models;

namespace HRMSCore
{
  public class AutoMapperProfile : Profile
  {
    public AutoMapperProfile()
    {
      CreateMap<DataSource, GetDataSource>();
      CreateMap<GetDataSource, DataSource>();

      CreateMap<AddDataSource, DataSource>();
      CreateMap<UpdateDataSource, DataSource>();


      CreateMap<Field, GetField>();
      CreateMap<GetField, Field>();

      CreateMap<AddField, Field>();
      CreateMap<UpdateField, Field>();



      CreateMap<FormField, GetFormField>();
      CreateMap<FieldsRow, GetFieldsRow>();
      CreateMap<FormStep, GetFormStep>();
      CreateMap<Form, GetForm>();



      CreateMap<AddFormField, FormField>();

      CreateMap<AddFieldsRow, FieldsRow>();
      // .ForMember(dest => dest.Fields, opt => opt.Ignore())
      // .ForMember(dest => dest.Order, opt => opt.Ignore());

      CreateMap<AddFormStep, FormStep>();
      // .ForMember(dest => dest.Order, opt => opt.Ignore());

      CreateMap<AddForm, Form>();


    }
  }
}