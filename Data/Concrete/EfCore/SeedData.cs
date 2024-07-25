using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {

        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                                            new Tag {Text="Web Programlama"},
                                            new Tag {Text="Backend"},
                                            new Tag {Text="Frontend"},
                                            new Tag {Text="FullStack"},
                                            new Tag {Text="Php"}
                                         );

                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                                            new User {UserName="kurban"},
                                            new User {UserName="mustafasinan"}
                                         );
                                         
                    context.SaveChanges();
                }


            if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                                            new Entity.Post {
                                                        Title = "Asp.net Core",
                                                        Content = "Asp.net Core Dersleri",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-10),
                                                        Tags = context.Tags.Take(3).ToList(),
                                                        Image ="1.png",
                                                        UserId =1
                                                     },

                                            new Entity.Post {
                                                        Title = "Php",
                                                        Content = "Php Dersleri",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-20),
                                                        Tags = context.Tags.Take(2).ToList(),
                                                        Image ="2.png",
                                                        UserId =1
                                                     },

                                            new Entity.Post {
                                                        Title = "Django",
                                                        Content = "Django  Derleri",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-5),
                                                        Tags = context.Tags.Take(4).ToList(),
                                                        Image ="3.png",
                                                        UserId =2
                                                     }
                                         );
                                         
                    context.SaveChanges();
                }


            }
        }

    }

}