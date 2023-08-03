using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HRMSCore.Dtos.ApprovalCycleDtos;
using HRMSCore.Dtos.DataSourceDtos;
using HRMSCore.Dtos.FieldDtos;
using HRMSCore.Dtos.FormDtos;
using HRMSCore.Dtos.UserDtos;
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
      CreateMap<Form, GetFormDetails>();

      CreateMap<Form, GetForm>();



      CreateMap<AddFormField, FormField>();

      CreateMap<AddFieldsRow, FieldsRow>();

      CreateMap<AddFormStep, FormStep>();

      CreateMap<AddForm, Form>();



      CreateMap<User, GetUser>();
      CreateMap<GetUser, User>();

      CreateMap<AddUser, User>();
      CreateMap<UpdateUser, User>();



      CreateMap<AddApprovalCycleStep, ApprovalCycleStep>();
      CreateMap<AddApprovalCycle, ApprovalCycle>();

      CreateMap<ApprovalCycleStep, GetApprovalCycleStep>();
      CreateMap<ApprovalCycle, GetApprovalCycle>();
    }
  }
}