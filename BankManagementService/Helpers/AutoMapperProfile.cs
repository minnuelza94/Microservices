using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Service.Model;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;

namespace BankManagementMicroservice.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerDetail, customerEntity>()
                .ReverseMap();

          

            CreateMap<LoginModel, customerEntity>(); ;
        }
    }
}
