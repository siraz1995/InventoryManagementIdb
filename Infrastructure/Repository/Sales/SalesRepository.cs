using AutoMapper;
using Core.Application.Interface.Sales;
using Core.Domain.Procurement;
using Core.Domain.Procurement.Purchase;
using Core.Domain.Sales;
using Infrastructure.Data;
using Core.Domain.DBContext;
//using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Application.Interface.Procurment;

namespace Infrastructure.Repository.Sales
{
    public class SalesRepository : ISales
    {
        private readonly IMapper _mapper;
        private readonly InventorymanagementContext _DBContext;
        private readonly IDataAccess _db;
        public SalesRepository(IMapper mapper, InventorymanagementContext dBContext, IDataAccess db)
        {
            _DBContext = dBContext;
            _mapper = mapper;
            _db = db;
        }
        #region "Save"
        public async Task<ResponseType> Save(SalesInput invoiceEntity)
        {
            string Result = string.Empty;
            int processcount = 0;
            var response = new ResponseType();


            if (invoiceEntity != null)
            {
                using (var dbtransaction = await this._DBContext.Database.BeginTransactionAsync())
                {

                    if (invoiceEntity != null)
                        Result = await this.SaveHeader(invoiceEntity);

                    if (!string.IsNullOrEmpty(Result) && (invoiceEntity.details != null && invoiceEntity.details.Count > 0))
                    {
                        invoiceEntity.details.ForEach(item =>
                        {
                            bool saveresult = this.SaveDetail(item, invoiceEntity.InvoiceNo).Result;
                            if (saveresult)
                            {
                                processcount++;
                            }
                        });

                        if (invoiceEntity.details.Count == processcount)
                        {
                            await this._DBContext.SaveChangesAsync();
                            await dbtransaction.CommitAsync();
                            response.Result = "pass";
                            response.KyValue = Result;
                        }
                        else
                        {
                            await dbtransaction.RollbackAsync();
                            response.Result = "faill";
                            response.Result = string.Empty;
                        }
                    }
                    else
                    {
                        response.Result = "faill";
                        response.Result = string.Empty;
                    }

                    // await this._DBContext.SaveChangesAsync();
                    //         await dbtransaction.CommitAsync();
                    //         response.Result = "pass";
                    //         response.KyValue = Result;

                };
            }
            else
            {
                return new ResponseType();
            }
            return response;
        }

        private async Task<string> SaveHeader(SalesInput invoiceHeader)
        {
            string Results = string.Empty;

            try
            {
                SalesHeader _header = this._mapper.Map<SalesInput, SalesHeader>(invoiceHeader);
                _header.InvoiceDate = DateTime.Now;
                var header = await this._DBContext.SalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceHeader.InvoiceNo);

                if (header != null)
                {
                    header.ShopCode             = invoiceHeader.ShopCode;
                    header.CustomerName         = invoiceHeader.CustomerName;
                    header.MobileNo             = invoiceHeader.MobileNo;
                    header.Address              = invoiceHeader.Address;
                    header.Total                = invoiceHeader.Total;
                    header.Vat                  = invoiceHeader.Vat;
                    header.NetTotal             = invoiceHeader.NetTotal;

                    var _detdata = await this._DBContext.SalesDetails.Where(item => item.InvoiceNo == invoiceHeader.InvoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.SalesDetails.RemoveRange(_detdata);
                    }
                }
                else
                {
                    await this._DBContext.SalesHeaders.AddAsync(_header);
                }
                Results = invoiceHeader.InvoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Results;
        }
        private async Task<bool> SaveDetail(SalesInfoDetails invoiceDetail, string InvoiceNo)
        {
            try
            {
                SalesDetail _detail = this._mapper.Map<SalesInfoDetails, SalesDetail>(invoiceDetail);
                _detail.InvoiceNo = InvoiceNo;
                await this._DBContext.SalesDetails.AddAsync(_detail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        public async Task<List<Core.Domain.Sales.SalesInfoHeader>> GetSalesHeaderList()
        {
            var _data = await _DBContext.SalesHeaders.ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<SalesHeader>, List<SalesInfoHeader>>(_data);
            }
            return new List<SalesInfoHeader>();
        }

        public async Task<SalesInfoHeader> GeSalesHeaderByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.SalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
            if (_data != null)
            {
                return this._mapper.Map<SalesHeader, SalesInfoHeader>(_data);
            }
            return new SalesInfoHeader();
        }

        public async Task<List<SalesInfoDetails>> GetSalesDetailsByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.SalesDetails.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<SalesDetail>, List<SalesInfoDetails>>(_data);
            }
            return new List<SalesInfoDetails>();
        }

        public async Task<ResponseType> Remove(string invoiceNo)
        {
            try
            {
                using (var dbtransaction = await this._DBContext.Database.BeginTransactionAsync())
                {
                    var _data = await this._DBContext.SalesHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
                    if (_data != null)
                    {
                        this._DBContext.SalesHeaders.Remove(_data);
                    }

                    var _detdata = await this._DBContext.SalesDetails.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.SalesDetails.RemoveRange(_detdata);
                    }
                    await this._DBContext.SaveChangesAsync();
                    await dbtransaction.CommitAsync();
                }
                return new ResponseType() { Result = "pass", KyValue = invoiceNo };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<SaleItemReport> GetSaleItemHeaderForReport(string invoiceNo)
        {
            var query = $@" Select 
	                            SH.InvoiceNo,SH.InvoiceDate,ST.Name StoreName,ST.Address StoreAddress,ST.Phone StorePhoneNo,
	                            SH.CustomerName,SH.MobileNo,SH.Address CustomerAddress,SH.Total,SH.Vat,SH.NetTotal
	                            From [Inventorymanagement].[dbo].SalesHeader SH
	                            INNER JOIN [InventorymanagementSyatem].[dbo].[Store] ST ON SH.ShopCode=ST.Code Where invoiceNo=@InvoiceNo";
            var result = await _db.Query<SaleItemReport, dynamic>(query, new { InvoiceNo = invoiceNo });
            return result.FirstOrDefault();
        }

        public async Task<List<SaleItemReport>> GetSaleItemDetailsForReport(string invoiceNo)
        {
            var query = $@" Select 
	                            SD.InvoiceNo,P.Name ProductName,B.Name BrandName,C.Name CategoryName,U.Name UnitTypeName,SD.Discription,SD.Quantity,SD.SalesPrice,SD.Total TotalPrice
	                            From [Inventorymanagement].[dbo].SalesDetail SD
	                            INNER JOIN [InventorymanagementSyatem].[dbo].[Product] P ON SD.ProductCode=P.Code
	                            INNER JOIN [InventorymanagementSyatem].[dbo].[Brand] B ON P.BrandCode=B.Code
	                            INNER JOIN [InventorymanagementSyatem].[dbo].[Category] C ON P.CategoryCode=C.Code
	                            INNER JOIN [InventorymanagementSyatem].[dbo].[UnitType] U ON SD.UnitTypeCode=U.Code Where invoiceNo=@InvoiceNo";
            var result = await _db.Query<SaleItemReport, dynamic>(query, new { InvoiceNo = invoiceNo });
            return result.ToList();
        }

    }
}
