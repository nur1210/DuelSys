using AspNetCoreHero.ToastNotification;
using DAL;
using Logic.Interfaces;
using Logic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Index");
    });

builder.Services.AddNotyf
    (config =>
    {
        config.DurationInSeconds = 10;
        config.IsDismissable = true;
        config.Position = NotyfPosition.BottomRight;
    });


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<UserService>();


builder.Services.AddSingleton<IUserDB, UserDB>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapRazorPages();
});

app.MapRazorPages();

app.Run();
