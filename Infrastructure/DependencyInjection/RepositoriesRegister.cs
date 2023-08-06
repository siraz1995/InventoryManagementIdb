using Core.Applicatio;
using Core.Application.Interface.Authentication;
using Core.Application.Interface.Item_Stock;
using Core.Application.Interface.Procurment;
using Core.Application.Interface.Product;
using Core.Application.Interface.Sales;
using Infrastructure.Data;
using Infrastructure.Repository;
using Infrastructure.Repository.Authentication;
using Infrastructure.Repository.ItemStock;
using Infrastructure.Repository.Procurment;
using Infrastructure.Repository.Product;
using Infrastructure.Repository.Sales;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyInjection
{
    public static class RepositoriesRegister
    {
        public static void AddRepositoryServices(this IServiceCollection services) =>
            services
            .AddSingleton<DataAccess>()
            .AddTransient<IBrand, BrandRepository>()
            .AddTransient<ICategory, CategoryRepository>()
            .AddTransient<IUnitType, UnitTypeRepository>()
            .AddTransient<IStore, StoreRepository>()
            .AddTransient<ISupplier, SupplierRepository>()
            .AddTransient<IPurchaseOrder, PurchaseOrderRepository>()
            .AddTransient<Iinvoice, PurchaseRepository>()
            .AddTransient<IProductRepository,ProductRepository>()
            .AddTransient<IPurchaseReturn,PurchaseReturnRepository>()
            .AddTransient<IStockRepository,StockRepository>()
            .AddTransient<ISales,SalesRepository>()
            .AddTransient<ISalesReturn,SalesReturnRepository>()
            .AddTransient<IPurchasePayment, PurchasePaymentRepository>()
            .AddTransient<IAuthentication, AuthenticationRepository>()
            .AddTransient<IDashboard, DashboardRepository>()
            ;
    }
}
