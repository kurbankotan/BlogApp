using BlogApp.Data.Concrete.EfCore;   // BlogContext dosyasının ait olduğu klasör  BlogApp/Data/Concrete/EfCore/BlogContext.cs
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Controllers'ın Views ile ilişkilendirilmesi için
builder.Services.AddControllersWithViews();

//SQL BAĞLANTISI İÇİN ÖNCEDEN HABER EDELİM
builder.Services.AddDbContext<BlogContext>(options=>{

    var config =builder.Configuration;
    var connectionString = config.GetConnectionString("sql_connection");      //ConnectionStrings'de bağlantı adını sql_connection yazdığımız için bu başka bir isim de olur
    options.UseSqlite(connectionString);

});



// Build en sonda olmalı oyüzden diğer bildirilecek herşey bundan yukarıda olmalı
var app = builder.Build();


//
SeedData.TestVerileriniDoldur(app);


// Default Routing İçin
app.MapDefaultControllerRoute();

app.Run();
