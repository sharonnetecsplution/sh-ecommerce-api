using Lojinha.Application.Helpers;
using Lojinha.Application.Helpers.Interfaces;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Services;
using Lojinha.Domain.Interfaces;
using Lojinha.Infra.Data.Context;
using Lojinha.Infra.Data.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.JSInterop.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha.Infra.Ioc
{
    public static class DependecyInjection
    {

        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ApplicationDbContext>(options => {
                options.UseNpgsql(configuration.GetConnectionString("ConexaoPadrao"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                    });
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            service.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();
            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");



            service.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
           .AddJwtBearer(x =>
           {
               x.RequireHttpsMetadata = false;
               x.SaveToken = true;
               x.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuerSigningKey = true,
                   IssuerSigningKey = new SymmetricSecurityKey(key),
                   ValidateIssuer = false,
                   ValidateAudience = false
               };
           });

            service.AddAuthorization(opt =>
            {
                var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme);

                defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                opt.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
            });
            service.AddTransient<IFeatureStockRepository, FeatureStockRepository>();
            service.AddTransient<IFeatureStockService, FeatureStockService>();
            service.AddTransient<IStoreRepository, StoreRepository>();
            service.AddTransient<IStoreService, StoreService>();
            service.AddTransient<ICompanyService, CompanyService>();
            service.AddTransient<ICompanyRepository, CompanyRepository>();
            service.AddTransient<IClothingRepository,ClothingRepository>();
            service.AddTransient<IClothingService, ClothingService>();
            service.AddTransient<IAccessoryRepository, AccessoryRepository>();
            service.AddTransient<IAccessoryService, AccessoryService>();
            service.AddTransient<IShoesRepository, ShoesRepository>();
            service.AddTransient<IShoesService,ShoesService>();
            service.AddScoped<ISeedUserClaimsInitial, SeedUserClaimsInitial>();
            service.AddScoped<IBlobStorageHelper, BlobStorageHelper>();
            service.AddTransient<IProductRepository, ProductRepository>();
            service.AddTransient<IProductService, ProductService>();
            service.AddTransient<ICartItemRepository, CartItemRepository>();
            service.AddTransient<ICartItemService, CartItemService>();
            service.AddTransient<ICartRepository, CartRepository>();
            service.AddTransient<ICartService, CartService>();
            service.AddTransient<ICategoryRepository, CategoryRepository>();
            service.AddTransient<ICategoryService, CategoryService>();
            service.AddTransient<IColorRepository, ColorRepository>();
            service.AddTransient<IColorService, ColorService>();
            service.AddTransient<IDeliveryRepository, DeliveryRepository>();
            service.AddTransient<IDeliveryService, DeliveryService>();
            service.AddTransient<IImageRepository, ImageRepository>();
            service.AddTransient<IImageService, ImageProductService>();
            service.AddTransient<ISegmentRepository, SegmentRepository>();
            service.AddTransient<ISegmentService, SegmentService>();
            service.AddTransient<ISizeRepository, SizeRepository>();
            service.AddTransient<ISizeService, SizeService>();
            service.AddTransient<IStockRepository, StockRepository>();
            service.AddTransient<IStockService, ClothingStoreService>();
            service.AddTransient<ITransactionRepository, TransactionRepository>();
            service.AddTransient<ITransactionService, TransactionService>();
            service.AddTransient<IAddressRepository, AddressRepository>();
            service.AddTransient<IAddressService, AddressService>();
            service.AddTransient<ICategory_productRepository, Category_productRepository>();
            service.AddTransient<ICategory_productService, Category_productService>();

            return service;

        }
    }
}
