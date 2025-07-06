using BlogStore.BussinessLayer.Abstract;
using BlogStore.BussinessLayer.AnalizeCommentService;
using BlogStore.BussinessLayer.Concrete;
using BlogStore.BussinessLayer.Container;
using BlogStore.BussinessLayer.MailService;
using BlogStore.DataAccessLayer.Abstract;
using BlogStore.DataAccessLayer.Context;
using BlogStore.DataAccessLayer.EntityFramework;
using BlogStore.EnitityLayer.Entities;
using BlogStore.WebUI.Controllers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddBussinessService();

builder.Services.AddHttpClient<HuggingFaceModerationService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "articleDetailWithSlug",
    pattern: "Article/ArticleDetail/{slug}",
    defaults: new { controller = "Article", action = "ArticleDetail" });


app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

app.MapDefaultControllerRoute(); // opsiyonel




app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
