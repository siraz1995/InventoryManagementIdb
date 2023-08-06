using AutoMapper;
using Core.Domain.Procurement;
using Core.Domain.Procurement.Purchase;
using Core.Domain.Sales;
using Core.Domain.DBContext;
//using Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<TblCustomer, CustomerEntity>().ForMember(item => item.StatusName, item => item.MapFrom(s => s.IsActive == true ? "Active" : "In Active"));
            
            //Use For Save DATA
            CreateMap<PurchaseDetail, InvoiceDetail>().ReverseMap();
            CreateMap<PurchaseHeader, InvoiceInput>().ReverseMap();
            //for get Purchase Order Header List
            CreateMap<PurchaseHeader, InvoiceHeader>().ReverseMap();


            //Use For Save Purchase Oreder Return  DATA
            CreateMap<PurchaseOrederReturnInfo, InvoiceDetail>().ReverseMap();
            CreateMap<PurchaseOrederReturnHeader, InvoiceInput>().ReverseMap();
            //for get Purchase Order Header List
            CreateMap<PurchaseOrederReturnHeader, InvoiceHeader>().ReverseMap();

            //Sales
            CreateMap<SalesHeader, SalesInput>().ReverseMap();
            CreateMap<SalesDetail, SalesInfoDetails>().ReverseMap();
            CreateMap<SalesHeader, SalesInfoHeader>().ReverseMap();

            //Sales Return
            CreateMap<SalesReturnHeader, SalesInput>().ReverseMap();
            CreateMap<SalesReturnDetail, SalesInfoDetails>().ReverseMap();
            CreateMap<SalesReturnHeader, SalesInfoHeader>().ReverseMap();
        }

    }
}