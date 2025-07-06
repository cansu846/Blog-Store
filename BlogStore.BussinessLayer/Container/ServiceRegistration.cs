using BlogStore.BussinessLayer.Abstract;
using BlogStore.BussinessLayer.AnalizeCommentService;
using BlogStore.BussinessLayer.Concrete;
using BlogStore.BussinessLayer.MailService;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.EntityFramework;
using BlogStore.EnitityLayer.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogStore.BussinessLayer.Container
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBussinessService(this IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDal, EfCommentDal>();
            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDal, EfArticleDal>();

            services.AddScoped<ITagService, TagManager>();
            services.AddScoped<ITagDal, EfTagDal>();

            services.AddScoped<IAboutService, AboutManager>();
            services.AddScoped<IAboutDal, EfAboutDal>();



            services.AddTransient<IEmailSender, MailKitEmailSender>();


            services.AddIdentity<AppUser, IdentityRole>()
                .AddEntityFrameworkStores<BlogContext>()
                 .AddDefaultTokenProviders();

            services.AddDbContext<BlogContext>();

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Login/UserLogin/";   //yönlendirilecek login sayfas?
                options.AccessDeniedPath = "/Login/AccessDenied"; // yetkisiz eri?im için (opsiyonel)
            });

            return services;
        }
    }
}
