using System.Reflection;
using FluentValidation;
using HotelProject.DataAccessLayer.Concrete;
using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Mapping;
using HotelProject.WebUI.Models.Staff;
using HotelProject.WebUI.ValidationRules.StaffValidationRules;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();



builder.Services.AddHttpClient();   

builder.Services.AddDbContext<HotelContext>();  

builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<HotelContext>();  

builder.Services.AddAutoMapper(typeof(AutoMapperConfig));   





builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});
builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(10); 
    options.LoginPath = "/Login/Index"; 
});



builder.Services.AddScoped<IValidator<AddStaffViewModel>, StaffCreateValidator>();   



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404", "?code={0}");

app.UseHttpsRedirection();  

app.UseStaticFiles();

app.UseAuthentication();  

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
