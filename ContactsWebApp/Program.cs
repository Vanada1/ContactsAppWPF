using ContactsWebApp.Data;
using ElectronNET.API;
using ElectronNET.API.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseElectron(args);

builder.Services.AddElectron();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContactsAppDbContext>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ContactsAppDbContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

if (HybridSupport.IsElectronActive)
{
    CreateElectronWindow();
}

app.Run();

async void CreateElectronWindow()
{
    // Решение https://stackoverflow.com/questions/70544430/custom-window-with-min-max-close-buttons-in-electron-net-app-with-asp-net-or-b
    var options = new BrowserWindowOptions
    {

        // Frame = false,

        WebPreferences = new WebPreferences
        {
            //ContextIsolation = true,
            //DevTools = true,
            //WebSecurity = false,
            //EnableRemoteModule = true,
            //NodeIntegration = true,
        },
    };

    var window = await Electron.WindowManager.CreateWindowAsync(options);
    window.OnClosed += () => Electron.App.Quit();
}