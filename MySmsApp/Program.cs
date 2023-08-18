using CoreService.UserService.Crud;
using CoreService.UserService.ResponseMaker;
using CoreService.UserService.SmsReplier;
using DataService.Entities;
using DataService.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MySmsApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContext<TwilioAppContext>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddScoped<IUserService,UserService>();
builder.Services.AddScoped<ISmsReplyService,SmsReplyService>();
builder.Services.AddControllers();
builder.Services.AddSession();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseSession();
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});
app.UseStaticFiles();

app.Run();
