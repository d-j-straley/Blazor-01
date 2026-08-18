using Blazor_01.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents();

// I could also add my own services here, for example, and use
// builder.Services.AddSingleton<IMyService, MyServiceImplementation>();
// builder.Services.AddScoped<IMyService, MyServiceImplementation>();
// builder.Services.AddTransient<IMyService, MyServiceImplementation>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>();

/* The following will start the web host and run as if it were the runtime, until shutdown */

app.Run(); 
