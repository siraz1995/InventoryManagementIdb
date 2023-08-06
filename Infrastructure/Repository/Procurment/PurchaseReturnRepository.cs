using AutoMapper;
using Core.Application.Interface.Procurment;
using Core.Domain.Procurement;
using Core.Domain.Procurement.Purchase;
using Infrastructure.Data;
using Core.Domain.DBContext;
//using Infrastructure.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Procurment
{
    public class PurchaseReturnRepository : IPurchaseReturn
    {
        private readonly IMapper _mapper;
        private readonly InventorymanagementContext _DBContext;
        private readonly IDataAccess _db;
        public PurchaseReturnRepository(IMapper mapper, InventorymanagementContext dBContext, IDataAccess db)
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
                PurchaseOrederReturnHeader _header = this._mapper.Map<InvoiceInput, PurchaseOrederReturnHeader>(invoiceHeader);
                _header.InvoiceDate = DateTime.Now;
                var header = await this._DBContext.PurchaseOrederReturnHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceHeader.InvoiceNo);

                if (header != null)
                {
                    header.VendorCode       = invoiceHeader.VendorCode;
                    header.ShopCode         = invoiceHeader.ShopCode;
                    header.Total            = invoiceHeader.Total;
                    header.Remarks          = invoiceHeader.Remarks;
                    header.Tax              = invoiceHeader.Tax;
                    header.NetTotal         = invoiceHeader.NetTotal;

                    var _detdata = await this._DBContext.PurchaseOrederReturnInfos.Where(item => item.InvoiceNo == invoiceHeader.InvoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.PurchaseOrederReturnInfos.RemoveRange(_detdata);
                    }
                }
                else
                {
                    await this._DBContext.PurchaseOrederReturnHeaders.AddAsync(_header);
                }
                Results = invoiceHeader.InvoiceNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Results;
        }

        private async Task<bool> SaveDetail(InvoiceDetail invoiceDetail, string InvoiceNo)
        {
            try
            {
                PurchaseOrederReturnInfo _detail = this._mapper.Map<InvoiceDetail, PurchaseOrederReturnInfo>(invoiceDetail);
                _detail.InvoiceNo = InvoiceNo;
                await this._DBContext.PurchaseOrederReturnInfos.AddAsync(_detail);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region "Get Purchase Order List"
        public async Task<List<InvoiceHeader>> GetPurchaseOrderReturnHeaderList()
        {
            var _data = await this._DBContext.PurchaseOrederReturnHeaders.ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<PurchaseOrederReturnHeader>, List<InvoiceHeader>>(_data);
            }
            return new List<InvoiceHeader>();
        }

        public async Task<InvoiceHeader> GetPurchaseOrderReturnHeaderByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.PurchaseOrederReturnHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
            if (_data != null)
            {
                return this._mapper.Map<PurchaseOrederReturnHeader, InvoiceHeader>(_data);
            }
            return new InvoiceHeader();
        }

        public async Task<List<InvoiceDetail>> GetPurchaseOrderReturnDetailsByInvoice(string invoiceNo)
        {
            var _data = await this._DBContext.PurchaseOrederReturnInfos.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
            if (_data != null && _data.Count > 0)
            {
                return this._mapper.Map<List<PurchaseOrederReturnInfo>, List<InvoiceDetail>>(_data);
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
                    var _data = await this._DBContext.PurchaseOrederReturnHeaders.FirstOrDefaultAsync(item => item.InvoiceNo == invoiceNo);
                    if (_data != null)
                    {
                        this._DBContext.PurchaseOrederReturnHeaders.Remove(_data);
                    }

                    var _detdata = await this._DBContext.PurchaseOrederReturnInfos.Where(item => item.InvoiceNo == invoiceNo).ToListAsync();
                    if (_detdata != null && _detdata.Count > 0)
                    {
                        this._DBContext.PurchaseOrederReturnInfos.RemoveRange(_detdata);
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

        public async Task<PurchaseOrderReport> GetPurchaseOrderReturnHeaderForReport(string invoiceNo)
        {
            var query = $@"Select 
                            PRH.InvoiceNo,PRH.InvoiceDate,
                            SUP.Name SupplierName,SUP.Address SupplierAddress,SUP.Email SupplierEmail,
                            SUP.Phone SupplierPhone,
                            ST.Name StoreName,ST.Address StoreAddress,ST.Phone StorePhone,
                            PRH.Remarks,PRH.Total,PRH.Tax,PRH.NetTotal
                            From [Inventorymanagement].[dbo].[PurchaseOrederReturnHeader] PRH
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Supplier] SUP ON PRH.VendorCode=SUP.Code 
                            INNER JOIN [InventorymanagementSyatem].[dbo].[Store] ST ON PRH.ShopCode=ST.Code Where invoiceNo=@InvoiceNo";
            var result = await _db.Query<PurchaseOrderReport, dynamic>(query, new { InvoiceNo = invoiceNo });
            return result.FirstOrDefault();
        }

        public async Task<List<PurchaseOrderReport>> GetPurchaseOrderReturnDetailsForReport(string invoiceNo)
        {
            var query = $@"Select
                                PRD.InvoiceNo,
                                P.Name ProductName,
                                B.Name BrandName,
                                C.Name CategoryName,
                                U.Name UnitTypeName,
                                PRD.Discription,
                                PRD.Qty Quantity,
                                PRD.SalesPrice,
                                PRD.Total TotalPrice
                                From  [Inventorymanagement].[dbo].[PurchaseOrederReturnInfo] PRD
                                INNER JOIN [InventorymanagementSyatem].[dbo].[Product] P ON PRD.ProductCode=P.Code
                                INNER JOIN [InventorymanagementSyatem].[dbo].[Brand] B ON P.BrandCode=B.Code
                                INNER JOIN [InventorymanagementSyatem].[dbo].[Category] C ON P.CategoryCode=C.Code
                                INNER JOIN [InventorymanagementSyatem].[dbo].[UnitType] U ON PRD.UnitTypeCode=U.Code Where invoiceNo=@InvoiceNo";
            var result = await _db.Query<PurchaseOrderReport, dynamic>(query, new { InvoiceNo = invoiceNo });
            return result.ToList();
        }
    }
}
