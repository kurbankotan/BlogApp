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
                                            new Tag {Text="Web Programlama", Url="web-programlama", Color = TagColors.warning},
                                            new Tag {Text="Backend", Url="backend", Color = TagColors.danger},
                                            new Tag {Text="Frontend", Url="Frontend", Color = TagColors.success},
                                            new Tag {Text="FullStack", Url="FullStack", Color = TagColors.secondory},
                                            new Tag {Text="Php", Url="Php", Color = TagColors.primary}
                                         );

                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                                            new User {UserName="vefakotan", Name = "Vefa KOTAN", Email = "vefa@kotan.com", Password = "123456", Image="p1.jpeg"},
                                            new User {UserName="mustafasinan", Name = "Mustafa KOTAN", Email = "mustafa@kotan.com", Password = "123456", Image="p2.jpeg"}
                                         );
                                         
                    context.SaveChanges();
                }


            if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                                            new Entity.Post {
                                                        Title = "Asp.net Core",
                                                        Description = "Asp.net Core Dersleri",
                                                        Content = "ASP.NET Core, modern web uygulamaları ve API'ler geliştirmek için Microsoft tarafından geliştirilen açık kaynaklı ve platformlar arası bir çerçevedir. Bu kurs, katılımcılara ASP.NET Core'un temellerini, MVC yapılarını, RESTful servislerin nasıl oluşturulacağını ve Entity Framework Core ile veritabanı işlemlerini nasıl gerçekleştireceklerini öğretmeyi amaçlamaktadır. Kurs boyunca, gerçek dünya senaryolarına dayanan uygulamalı projeler üzerinde çalışacaksınız ve ASP.NET Core ile güvenli, ölçeklenebilir web çözümleri oluşturmayı öğreneceksiniz.",
                                                        Url = "aspnet-core",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-10),
                                                        Tags = context.Tags.Take(3).ToList(),
                                                        Image ="1.png",
                                                        UserId =1,
                                                        Comments = new List<Comment> {
                                                                                          new Comment { Text="İyi bir kurs", PublishedOn = DateTime.Now.AddDays(-20), UserId = 1 },
                                                                                          new Comment { Text="Çok faydalı bir kurs", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2 } 
                                                                                    }
                                                     },

                                            new Entity.Post {
                                                        Title = "Php",
                                                        Description = "Php Dersleri",
                                                        Content = "PHP, web geliştirme dünyasında geniş bir kullanım alanına sahip olan dinamik ve esnek bir dildir. Bu kurs, PHP'ye giriş yaparak başlayacak ve temel programlama kavramları, form veri işleme, oturum yönetimi ve MySQL ile veritabanı etkileşimleri gibi daha ileri konuları kapsayacak. Katılımcılar, gerçek zamanlı projeler üzerinde çalışarak teorik bilgilerini pekiştirecek ve PHP ile dinamik web siteleri ve uygulamalar geliştirme becerilerini geliştirecekler. Kurs, hem yeni başlayanlar için ideal bir başlangıç noktası sunarken, mevcut PHP geliştiricileri için de bilgi ve becerilerini genişletme fırsatı sağlar.",
                                                        Url = "php",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-20),
                                                        Tags = context.Tags.Take(1).ToList(),
                                                        Image ="2.png",
                                                        UserId =1
                                                     },

                                            new Entity.Post {
                                                        Title = "Django",
                                                        Description = "Django Dersleri",
                                                        Content = "Django, Python tabanlı güçlü bir web çerçevesidir ve bu kurs, temelden ileri seviyeye kadar Django'nun temel prensiplerini kapsamlı bir şekilde ele alacak. Katılımcılar, modeller, görünümler ve şablonlar kullanarak veri odaklı web uygulamaları oluşturmayı öğrenecekler. Ayrıca, form işlemleri, kullanıcı doğrulama, dosya yükleme ve RESTful API'ler gibi ileri düzey konular üzerinde de durulacak. Gerçek dünya projeleri üzerinde çalışarak, katılımcılar Django ile tam özellikli web siteleri geliştirme yeteneklerini geliştirecekler. Bu kurs, web geliştirme becerilerini genişletmek isteyen herkes için mükemmel bir fırsat sunmaktadır.",
                                                        Url = "django",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-30),
                                                        Tags = context.Tags.Take(2).ToList(),
                                                        Image ="3.png",
                                                        UserId =2
                                                     },
                                            new Entity.Post {
                                                        Title = "React Desleri",
                                                        Description = "React Dersleri",
                                                        Content = "React, kullanıcı arayüzleri geliştirmek için kullanılan açık kaynaklı bir JavaScript kütüphanesidir. Facebook tarafından sürdürülen bu kütüphane, büyük ölçekli uygulamaların verimli bir şekilde yönetilmesine olanak tanır. Component tabanlı yapısı sayesinde, küçük ve bağımsız parçalar halinde kod yazmanıza olanak tanır, bu da uygulamanın sürdürülebilirliğini ve yeniden kullanılabilirliğini artırır. Ayrıca, sanal DOM özelliği sayesinde, uygulamanızın performansını maksimize ederken, kullanıcı deneyimini de iyileştirir. React, esnek yapısıyla web ve mobil platformlar için dinamik ve interaktif kullanıcı arayüzleri oluşturmanızı sağlar.",
                                                        Url = "react-dersleri",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-40),
                                                        Tags = context.Tags.Take(3).ToList(),
                                                        Image ="4.png",
                                                        UserId =2
                                                     },
                                     new Entity.Post {
                                                        Title = "Angular",
                                                        Description = "Angular Dersleri",
                                                        Content = "Angular, dinamik web uygulamaları geliştirmek için kullanılan güçlü bir açık kaynaklı çerçevedir. Google tarafından desteklenen bu platform, MVC (Model-View-Controller) mimarisini benimseyerek uygulama geliştirme sürecini kolaylaştırır. TypeScript tabanlı olması, kodlama sırasında daha katı bir yapı ve gelişmiş nesne yönelimli programlama özellikleri sunar. Angular'ın modüler yapısı, büyük ölçekli projelerde bile yönetimi ve bakımı basitleştirir. Ayrıca, çapraz platform desteği ile web, mobil web, native mobile ve native desktop uygulamaları oluşturabilirsiniz. Angular, gelişmiş SPA (Single Page Applications) uygulamaları oluşturmak isteyen geliştiriciler için ideal bir çözümdür.",
                                                        Url = "angular",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-50),
                                                        Tags = context.Tags.Take(5).ToList(),
                                                        Image ="5.png",
                                                        UserId =2
                                                     },
                                    new Entity.Post {
                                                        Title = "Web Tasarım",
                                                        Description = "Web Tasarım Dersleri",
                                                        Content = "Web tasarımı, kullanıcıların çevrimiçi deneyimlerini şekillendiren yaratıcı bir süreçtir. Estetik ve fonksiyonelliği birleştiren bu disiplin, kullanıcı dostu arayüzler tasarlamak için görsel unsurlar ve kullanıcı etkileşimi tekniklerini kullanır. Modern web tasarımı, responsive (duyarlı) tasarım prensiplerini benimseyerek farklı cihaz ve ekran boyutlarına uyum sağlar. Bu süreç, marka kimliğini yansıtan, ziyaretçileri etkilemeyi ve tutmayı hedefleyen çekici ve etkileşimli siteler oluşturmayı amaçlar. Etkili bir web tasarımı, doğru renk paletleri, tipografi ve düzen kullanımı ile ziyaretçilerin site üzerinde kolayca gezinmelerini ve aradıkları bilgilere hızla ulaşmalarını sağlar.",
                                                        Url = "web-tasarim",
                                                        IsActive = true,
                                                        PublishedOn = DateTime.Now.AddDays(-60),
                                                        Tags = context.Tags.Take(2).ToList(),
                                                        Image ="6.png",
                                                        UserId =2
                                                     }
                                         );
                                         
                    context.SaveChanges();
                }


            }
        }

    }

}