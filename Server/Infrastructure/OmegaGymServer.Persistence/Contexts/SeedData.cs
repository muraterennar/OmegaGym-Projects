using Bogus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OmegaGymServer.Application.Helper.Securtiy;
using OmegaGymServer.Domain.Entities;

namespace OmegaGymServer.Persistence.Contexts;

internal class SeedData
{

    private static List<OperationClaim> SeedOperationClaim()
    {
        List<OperationClaim> result = new()
        {
            new OperationClaim(){RoleName="admin"},
            new OperationClaim(){RoleName="user"},
            new OperationClaim(){RoleName="moderator"}
        };

        return result;
    }

    private static List<User> SeedUser(Guid adminId)
    {
        string password = "*****";
        byte[] passwordHash, passwordSalt;

        PasswordEncrypter.Encrpt(password, out passwordHash, out passwordSalt);

        List<User> result = new()
        {
            new User(){FirstName="Mehmet", LastName="Baltacı", UserName="mehmetbaltacı", Gender="erkek",Email="34omegagym@gmail.com",OperationClaimId = adminId, PasswordHash=passwordHash, PasswordSalt=passwordSalt},
            new User(){FirstName="Serdar", LastName="Sarıkurt", UserName="serdarsarikurt", Gender="erkek",Email="34omegagym@gmail.com",OperationClaimId = adminId, PasswordHash=passwordHash, PasswordSalt=passwordSalt},
            new User(){FirstName="Gökhan", LastName="Sarıkurt", UserName="gokhansarikurt", Gender="erkek",Email="34omegagym@gmail.com",OperationClaimId = adminId, PasswordHash=passwordHash, PasswordSalt=passwordSalt}
        };

        return result;
    }

    private static List<SubscriptionCategory> SeedSubscriptionCategory()
    {
        List<SubscriptionCategory> result = new()
        {
            new SubscriptionCategory(){SubscriptionCategoryName="Fitness"},
            new SubscriptionCategory(){SubscriptionCategoryName="Boks"},
            new SubscriptionCategory(){SubscriptionCategoryName="Pilates"},
            new SubscriptionCategory(){SubscriptionCategoryName="Yüzme"},
            new SubscriptionCategory(){SubscriptionCategoryName="Halk Oyunları"},
        };

        return result;
    }

    private static List<Subscription> SeedSubscription(Guid fitnessId, Guid boksId, Guid pilatesId, Guid yuzmeId, Guid halkOyunlariId)
    {
        List<Subscription> results = new()
        {
            //Fitness
            new Subscription(){SubscriptionCategoryId= fitnessId, SubscriptionTitle = "Aylık Üyelik", SubscriptionDescription ="Sadece Fitness: Aylık Yoğun Antrenman",SubscriptionPrice = 470, SubscriptionArticlelOne="Çeşitli Ekipmanlar", SubscriptionArticlelTwo="Kişiselleştirilmiş Antrenman Planı", SubscriptionArticlelThree = "Esnek Saatler"},
            new Subscription(){SubscriptionCategoryId= fitnessId, SubscriptionTitle = "3 Aylık Üyelik", SubscriptionDescription ="Forma Adım Adım: 3 Aylık Fitness Üyeliği",SubscriptionPrice = 1250, SubscriptionArticlelOne="Kapsamlı Ekipman Seçimi", SubscriptionArticlelTwo="Uzman Rehberlik", SubscriptionArticlelThree = "Hedefe Yönelik Antrenman Programı"},
            new Subscription(){SubscriptionCategoryId= fitnessId, SubscriptionTitle = "6 Aylık Üyelik", SubscriptionDescription ="Güçlenmek İçin 6 Aylık Fitness Üyeliği",SubscriptionPrice = 2400, SubscriptionArticlelOne="Geniş Ekipman Seçimi", SubscriptionArticlelTwo="Esnek Çalışma Saatleri", SubscriptionArticlelThree = "Kişisel Antrenman Programı"},
            new Subscription(){SubscriptionCategoryId= fitnessId, SubscriptionTitle = "12 Aylık Üyelik", SubscriptionDescription ="Uzun Vadeli Hedefler İçin 12 Aylık Üyelik",SubscriptionPrice = 4300, SubscriptionArticlelOne="Zengin Ekipman Seçimi", SubscriptionArticlelTwo="Esnek Çalışma Saatleri", SubscriptionArticlelThree = "Özel Antrenman Planı"},
            new Subscription(){SubscriptionCategoryId= fitnessId, SubscriptionTitle = "16 Ders Özel PT Paket", SubscriptionDescription ="Özel PT Paketi: Kişisel Antrenmanlar, Formda Kalın!",SubscriptionPrice = 2500, SubscriptionArticlelOne="Kişiye Özel Programlar", SubscriptionArticlelTwo="Profesyonel Antrenörler", SubscriptionArticlelThree = "Esnek Ve Rahat Ortam"},

            //Boks
            new Subscription(){SubscriptionCategoryId = boksId, SubscriptionTitle = "8 Ders Grup Dersi", SubscriptionDescription = "Hedeflerine Ulaşmak İçin Boks", SubscriptionPrice=650, SubscriptionArticlelOne="Kişisel Antrenman", SubscriptionArticlelTwo ="Uzman Rehberlik", SubscriptionArticlelThree = "Güçlenme Fırsatı"},
            new Subscription(){SubscriptionCategoryId = boksId, SubscriptionTitle = "8 Seans Özel Ders", SubscriptionDescription = "Profesyonel ve doğru teknikleri öğrenerek özgüveninizi artırın", SubscriptionPrice=1750, SubscriptionArticlelOne="Güçlü Ve Dayanıklı Vücut", SubscriptionArticlelTwo ="Profesyonel Teknik Eğitmenler", SubscriptionArticlelThree = "Stres Atın, Özgüven Kazanın"},

            //Pilates
            new Subscription(){SubscriptionCategoryId = pilatesId, SubscriptionTitle = "8 Seans Özel Ders", SubscriptionDescription = "Birebir Plates Dersleriyle Hedefe Ulaş", SubscriptionPrice = 1200, SubscriptionArticlelOne = "Kişisel Antrenman: 8 Seans Özel Plates", SubscriptionArticlelTwo = "Uzman Rehberlik: Özel Dersle Hedefe", SubscriptionArticlelThree = "Vücut Esnekliği: 8 Seans Etkili Plates"},

            //Yüzme
            new Subscription(){SubscriptionCategoryId = yuzmeId, SubscriptionTitle = "8 Seans Özel Ders", SubscriptionDescription = "Yüzme Becerilerini İlerlet", SubscriptionPrice = 3500, SubscriptionArticlelOne = "Kişisel Antrenman: 8 Seans", SubscriptionArticlelTwo = "Teknik Gelişim: Uzman Rehberlikle", SubscriptionArticlelThree = "Yüzme Becerileri: 8 Seans Etkili Dersler"},

            //Halk Oyunları
            new Subscription(){SubscriptionCategoryId = halkOyunlariId, SubscriptionTitle = "1 Oyun 8 Ders", SubscriptionDescription = "Geleneksel Danslara Merhaba", SubscriptionPrice = 1600, SubscriptionArticlelOne = "Eleneksel Danslar: Kemençe Horon", SubscriptionArticlelTwo = "Ritim Ve Kültür: Harmandalı", SubscriptionArticlelThree = "Grup Performansı: Halk Oyunları"}
        };

        return results;
    }


    private static List<Image> SeedImages()
    {
        List<Image> results = new()
        {
            new Image(){ImageName = "giris_1", ImageUrl="assets/img/foto_galery/giris_1.JPG"},
            new Image(){ImageName = "giris_2", ImageUrl="assets/img/foto_galery/giris_2.JPG"},
            new Image(){ImageName = "giris_3", ImageUrl="assets/img/foto_galery/giris_3.JPG"},
            new Image(){ImageName = "salon_1", ImageUrl="assets/img/foto_galery/salon_1.JPG"},
            new Image(){ImageName = "salon_2", ImageUrl="assets/img/foto_galery/salon_2.JPG"},
            new Image(){ImageName = "salon_3", ImageUrl="assets/img/foto_galery/salon_3.JPG"},
            new Image(){ImageName = "salon_4", ImageUrl="assets/img/foto_galery/salon_4.JPG"},
            new Image(){ImageName = "salon_5", ImageUrl="assets/img/foto_galery/salon_5.JPG"},
            new Image(){ImageName = "salon_6", ImageUrl="assets/img/foto_galery/salon_6.JPG"},
            new Image(){ImageName = "kadın_soyunma_1", ImageUrl="assets/img/foto_galery/kadın_soyunma_1.JPG"},
            new Image(){ImageName = "kadın_soyunma_2", ImageUrl="assets/img/foto_galery/kadın_soyunma_2.JPG"},
            new Image(){ImageName = "soyunma_giris", ImageUrl="assets/img/foto_galery/soyunma_giris.JPG"},
            new Image(){ImageName = "erkek_soyunma_1", ImageUrl="assets/img/foto_galery/erkek_soyunma_1.JPG"},
            new Image(){ImageName = "erkek_soyunma_2", ImageUrl="assets/img/foto_galery/erkek_soyunma_2.JPG"},
            new Image(){ImageName = "erkek_soyunma_3", ImageUrl="assets/img/foto_galery/erkek_soyunma_3.JPG"},
            new Image(){ImageName = "boks_antr_1", ImageUrl="assets/img/foto_galery/boks_antr_1.JPG"},
            new Image(){ImageName = "boks_antr_2", ImageUrl="assets/img/foto_galery/boks_antr_2.JPG"},
            new Image(){ImageName = "boks_antr_3", ImageUrl="assets/img/foto_galery/boks_antr_3.JPG"}
        };

        return results;
    }

    public async Task SeedAsync(IConfiguration configuration)
    {
        var dbContextBuilder = new DbContextOptionsBuilder();
        dbContextBuilder.UseSqlServer(configuration["ConnectionStrings:MsSqlServer"]);

        var context = new OmegaGymEfDbContext(dbContextBuilder.Options);

        if (!context.Users.Any())
        {
            // -------------- Seeding Operation Claim
            List<OperationClaim> seedOperationCliam = SeedOperationClaim();
            await context.AddRangeAsync(seedOperationCliam);
            await context.SaveChangesAsync();

            OperationClaim adminId = await context.OperationClaims.SingleOrDefaultAsync(x => x.RoleName == "admin");

            // -------------- Seeding User
            List<User> seedingUser = SeedUser(adminId.Id);
            await context.AddRangeAsync(seedingUser);
            await context.SaveChangesAsync();

            // -------------- Seeding SubscriptionCategory
            List<SubscriptionCategory> seedingSubscriptionCategories = SeedSubscriptionCategory();
            await context.AddRangeAsync(seedingSubscriptionCategories);
            await context.SaveChangesAsync();

            // -------------- Seeding Subscription

            var fitnessModel = await context.SubscriptionCategories.SingleOrDefaultAsync(x => x.SubscriptionCategoryName == "Fitness");
            var boksModel = await context.SubscriptionCategories.SingleOrDefaultAsync(x => x.SubscriptionCategoryName == "Boks");
            var pilatesModel = await context.SubscriptionCategories.SingleOrDefaultAsync(x => x.SubscriptionCategoryName == "Pilates");
            var yuzmeModel = await context.SubscriptionCategories.SingleOrDefaultAsync(x => x.SubscriptionCategoryName == "Yüzme");
            var halkOyunlarıModel = await context.SubscriptionCategories.SingleOrDefaultAsync(x => x.SubscriptionCategoryName == "Halk Oyunları");

            List<Subscription> seedingSubscription = SeedSubscription(fitnessModel.Id, boksModel.Id, pilatesModel.Id, yuzmeModel.Id, halkOyunlarıModel.Id);
            await context.AddRangeAsync(seedingSubscription);
            await context.SaveChangesAsync();

            // -------------- Seeding Images
            var imagesSeeding = SeedImages();
            await context.AddRangeAsync(imagesSeeding);
            await context.SaveChangesAsync();
        }

        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }

    }
}

