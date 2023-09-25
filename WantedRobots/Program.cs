using WantedRobots.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IRobotData, RobotData>();
builder.Services.AddSingleton<IAgentData, AgentData>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//C'est ici qu'on defini les action et controlleur de base, on ny touche pas bcp 
//Exemple concret de named argument 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

// les pattern seront toujours la meme, on call un controlleur -- on utilise l'action -- on passe pt des parametre 

app.Run();