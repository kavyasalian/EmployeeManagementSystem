var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();builder.Services.AddSwaggerGen();builder.Services.AddControllersWithViews()    .AddNewtonsoftJson(options =>    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);builder.Services.AddCors(options =>{    options.AddPolicy(name: "CorsPolicy",                      builder =>                      {                          builder.WithOrigins("http://localhost:4200/").                                              AllowAnyMethod().                                              AllowAnyHeader().                                              AllowCredentials();                      });});builder.Services.AddSpaStaticFiles(configuration =>{    configuration.RootPath = "ClientApp/dist/NGO";});var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()){

    app.UseCors(x => x.AllowAnyMethod().                       AllowAnyHeader().                       WithHeaders().                       AllowCredentials().                       SetIsOriginAllowed(origin =>                       true));    app.UseSwaggerUI();    app.UseSwagger();}app.UseHttpsRedirection();app.UseStaticFiles();app.UseRouting();app.UseEndpoints(endpoints =>{    endpoints.MapControllerRoute(        name: "default",        pattern: "{controller}/{action=Index}/{id?}");    endpoints.MapControllers();});

//app.MapFallbackToFile("index.html"); ;
app.UseSpa(spa =>{    spa.Options.SourcePath = "ClientApp";    if (app.Environment.IsDevelopment())    {        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");

        // NOTE: Disable above line and enable below line to trigger angular from dev server.
        //spa.UseAngularCliServer(npmScript: "start");
    }});app.UseHttpsRedirection();app.UseAuthorization();app.MapControllers();app.Run();