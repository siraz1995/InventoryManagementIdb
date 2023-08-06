using AutoMapper;
using Core.Application.Interface.Procurment;
using Core.Domain.Procurement.Purchase;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Domain.Procurement;
using Core.Domain.DBContext;
//using Infrastructure.DBContext;

namespace Infrastructure.Repository.Procurment
{
    public class PurchaseRepository: Iinvoice
    {
        private readonly IMapper _mapper;
        private readonly InventorymanagementContext _DBContext;
        private readonly IDataAccess _db;
        public PurchaseRepository(IMapper mapper, InventorymanagementContext dBContext, IDataAccess db)
        {
            _DBContext = dBContext;
            _mapper = mapper;
            _db = db;
        }

        #region "Save"
        public async Task<ResponseType> Save(InvoiceInput invoiceEntity)
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

        private async Task<string> SaveHeader(InvoiceInput invoiceHeader)
        {
            string Results = string.Empty;

            try
            {
                PurchaseHeader _header = this._mapper.Map<InvoiceInput, PurchaseHeader>(invoiceHeader);
                _header.InvoiceDate = DateTime.Now;
                var header = await this._DBContext.PurchaseHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceHeader.InvoiceNo);

                if (header != null)
                {
                    header.VendorCode           = invoiceHeader.VendorCode;
                    header.ShopCode             = invoiceHeader.ShopCode;
                    header.Total                = invoiceHeader.Total;
                    header.Remarks              = invoiceHeader.Remarks;
                    header.Tax                  = invoiceHeader.Tax;
                    header.NetTotal             = invoiceHeader.NetTotal;

                    var _detdata = await this._DBContext.PurchaseDetails.Where(item => item.InvoiceNo == invoiceHeader.InvoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.PurchaseDetails.RemoveRange(_detdata);
                    }
                }
                else
                {
                    await this._DBContext.PurchaseHeaders.AddAsync(_header);
                }
                Results = invoiceHeader.InvoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Results;
        }
        private async Task<bool> SaveDetail(InvoiceDetail invoiceDetail,string InvoiceNo)
        {
            try
            {
                PurchaseDetail _detail = this._mapper.Map<InvoiceDetail, PurchaseDetail>(invoiceDetail);
                _detail.InvoiceNo = InvoiceNo;
                await this._DBContext.PurchaseDetails.AddAsync(_detail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region "Get Purchase Order List"
        public async Task<List<InvoiceHeader>> GetPurchaseOrderHeaderList()
        {
            var _data = await this._DBContext.PurchaseHeaders.ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<PurchaseHeader>, List<InvoiceHeader>>(_data);
            }
            return new List<InvoiceHeader>();
        }

        public async Task<InvoiceHeader> GetPurchaseOrderHeaderByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.PurchaseHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
            if (_data != null)
            {
                return this._mapper.Map<PurchaseHeader, InvoiceHeader>(_data);
            }
            return new InvoiceHeader();
        }

        public async Task<List<InvoiceDetail>> GetPurchaseOrderDetailsByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.PurchaseDetails.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<PurchaseDetail>, List<InvoiceDetail>>(_data);
            }
            return new List<InvoiceDetail>();
        }

        #endregion

        public async Task<ResponseType> Remove(string invoiceNo)
        {
            try
            {
                using (var dbtransaction = await this._DBContext.Database.BeginTransactionAsync())
                {
                    var _data = await this._DBContext.PurchaseHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
                    if (_data != null)
                    {
                        this._DBContext.PurchaseHeaders.Remove(_data);
                    }

                    var _detdata = await this._DBContext.PurchaseDetails.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.PurchaseDetails.RemoveRange(_detdata);
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

        public async Task<PurchaseOrderReport> GetPurchaseOrderHeaderForReport(string invoiceNo)
        {
            var query = $@"Select 
                            PH.InvoiceNo,PH.InvoiceDate,
                            SUP.Name SupplierName,SUP.Address SupplierAddress,SUP.Email SupplierEmail,
                            SUP.Phone SupplierPhone,
                            ST.Name StoreName,ST.Address StoreAddress,ST.Phone StorePhone,
                            PH.Remarks,PH.Total,PH.Tax,PH.NetTotal,PH.IsPaid
                            From [Inventorymanagement].[dbo].[PurchaseHeader] PH
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Supplier] SUP ON PH.VendorCode=SUP.Code 
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Store] ST ON PH.ShopCode=ST.Code Where invoiceNo=@InvoiceNo";            
            var result = await _db.Query<PurchaseOrderReport, dynamic>(query, new { InvoiceNo= invoiceNo });
            return result.FirstOrDefault();
        }
        public async Task<List<PurchaseOrderReport>> GetPurchaseOrderDetailsForReport(string invoiceNo)
        {
            var query = $@"Select
                            PD.InvoiceNo,
                            P.Name ProductName,
                            B.Name BrandName,
                            C.Name CategoryName,
                            U.Name UnitTypeName,
                            PD.Discription,
                            PD.Qty Quantity,
                            PD.SalesPrice,
                            PD.Total TotalPrice
                            From  [Inventorymanagement].[dbo].[PurchaseDetail] PD
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Product] P ON PD.ProductCode=P.Code
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Brand] B ON P.BrandCode=B.Code
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Category] C ON P.CategoryCode=C.Code
                            INNER JOIN [InventorymanagementSyatem].[dbo].[UnitType] U ON PD.UnitTypeCode=U.Code Where invoiceNo=@InvoiceNo";            
            var result = await _db.Query<PurchaseOrderReport, dynamic>(query, new { InvoiceNo= invoiceNo });
            return result.ToList();
        }
    }
}
