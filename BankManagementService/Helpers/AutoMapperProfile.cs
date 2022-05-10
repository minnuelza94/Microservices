using AutoMapper;
using BankManagementMicroservice.Service.Model;
using BankMangementMicroservice.Service.Model;
using customerEntity = BankMangementMicroservice.Data.Entity.CustomerDetail;
using loanEntity = BankMangementMicroservice.Data.Entity.LoanDetail;

namespace BankManagementMicroservice.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<CustomerDetail, customerEntity>()
                .ReverseMap();
            CreateMap<customerEntity, RegisterModel>()
               .ReverseMap();
            CreateMap<LoginModel, customerEntity>(); ;
            CreateMap<LoanDetail, loanEntity>()
              .ReverseMap();
        }
    }
}
