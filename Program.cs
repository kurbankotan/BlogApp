using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;   // BlogContext dosyasının ait olduğu klasör  BlogApp/Data/Concrete/EfCore/BlogContext.cs
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Internal.Patterns;

var builder = WebApplication.CreateBuilder(args);

//Controllers'ın Views ile ilişkilendirilmesi için
builder.Services.AddControllersWithViews();

//SQL BAĞLANTISI İÇİN ÖNCEDEN HABER EDELİM
// builder.Services.AddDbContext<BlogContext>(options=>{

//     var config =builder.Configuration;
//     var connectionString = config.GetConnectionString("sql_connection");      //ConnectionStrings'de bağlantı adını sql_connection yazdığımız için bu başka bir isim de olur
//     options.UseSqlite(connectionString);

// });

//Yukarıdaki kodu tek satırda da yazabiliriz aşağıdaki gibi

builder.Services.AddDbContext<BlogContext>(options=>{ options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);});

//Authentication İçin
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>{
    options.LoginPath = "/Users/Login";   // posts altındaki create'e giderken eğer kullanıcı login olmamışsa login sayfasına yönlendirir
});

//Her http request'inde bize aynı nesneyi göndertmek için yazılır (Dependency injection)
builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();


// Build en sonda olmalı oyüzden diğer bildirilecek herşey bundan yukarıda olmalı
var app = builder.Build();


//wwwroot klasörü altındaki statik dosyalar http taleplerini karşılamak için aşağıdaki kod yazılır
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

//
SeedData.TestVerileriniDoldur(app);

// localhost://posts/react-dersleri
// localhost://posts/php-dersleri

// Default Routing İçin
app.MapControllerRoute(
    name: "post_details",
    pattern:"posts/details/{url}",
    defaults: new {controller="Posts", action="Details"}
);

app.MapControllerRoute(
    name: "post_by_tag",
    pattern:"posts/tag/{tag}",
    defaults: new {controller="Posts", action="Index"}
);

app.MapControllerRoute(
    name: "user_profile",
    pattern:"profile/{username}",
    defaults: new {controller="Users", action="Profile"}
);


app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Posts}/{action=Index}/{id?}"

);

app.Run();
