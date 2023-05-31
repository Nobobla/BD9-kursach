using System;

using System.Linq;
using System.Threading.Tasks;

namespace BD9.Models
{
    public class ApplicationContextSeed
    {
        public static async Task InitializeDb(ApplicationContext db)
        {
            if (db.Orders.Any())
                return;

            var model1 = new Model() { Manufacture = "Sumsung", ModelName = "Alfa" };
            var model2 = new Model() { Manufacture = "Sumsung", ModelName = "Note10" };
            var model3 = new Model() { Manufacture = "Apple", ModelName = "14pro" };
            var model4 = new Model() { Manufacture = "Apple", ModelName = "14pro max" };
            var model5 = new Model() { Manufacture = "Huawei", ModelName = "Mate 40" };
            await db.Models.AddRangeAsync(model1, model2, model3, model4, model5);


            var cl1 = new Client() { Surname = "Швед", Name = "Александр", Lastname = "Сергеевич", Email = "1@mail.ru", Phone = 81234567890 };
            var cl2 = new Client() { Surname = "Останкина", Name = "Александра", Lastname = "Сергеевна", Email = "2@mail.ru", Phone = 81234567891 };
            var cl3 = new Client() { Surname = "Гоголь", Name = "Дмитрий", Lastname = "Артемьевич", Email = "3@mail.ru", Phone = 81234567892 };
            var cl4 = new Client() { Surname = "Воровец", Name = "Лев", Lastname = "Николаевич", Email = "4@mail.ru", Phone = 81234567893 };
            await db.Clients.AddRangeAsync(cl1, cl2, cl3, cl4);


            var j1 = new Job() { JobName = "Мастер" };
            var j2 = new Job() { JobName = "Менеджер" };
            var j3 = new Job() { JobName = "Старший Мастер" };
            await db.Jobs.AddRangeAsync(j1, j2, j3);


            var of1 = new Office() { Adress = "Мира 10", Email = "main1@yandex.ru", Phone = "80987654321" };
            var of2 = new Office() { Adress = "Газеты Звезда 22", Email = "main2@yandex.ru", Phone = "81987654321" };
            var of3 = new Office() { Adress = "Макаренко 41", Email = "main3@yandex.ru", Phone = "82987654321" };

            await db.Offices.AddRangeAsync(of1, of2, of3);

            var CI1 = new ContactInform() { Surname = "Уборников", Name = "Илья", Lastname = "Семёнович", Phone = 89194787111, PSeries = 5213, PNumber = 525281, Snils = 1111111110, Adress = "Танкистов 11", Date = new DateTime(1991, 01, 22) };
            var CI2 = new ContactInform() { Surname = "Задиров", Name = "Александр", Lastname = "Викторович", Phone = 89194787112, PSeries = 5213, PNumber = 525282, Snils = 1111111111, Adress = "Баумана 14", Date = new DateTime(1985, 03, 10) };
            var CI3 = new ContactInform() { Surname = "Балковна", Name = "Индира", Lastname = "Садамовна", Phone = 89194787113, PSeries = 5213, PNumber = 525283, Snils = 1111111112, Adress = "Лебедева 58", Date = new DateTime(1993, 05, 12) };
            await db.Informs.AddRangeAsync(CI1, CI2, CI3);

            var Ep1 = new Emploee() { ContactInform = CI1, Job = j1, Office = of1 };
            var Ep2 = new Emploee() { ContactInform = CI2, Job = j3, Office = of2 };
            var Ep3 = new Emploee() { ContactInform = CI3, Job = j2, Office = of1 };
            await db.Emps.AddRangeAsync(Ep1, Ep2, Ep3);

            var s1 = new Service() { ServiceName = "Замена экрана",  Price = 1000 };
            var s2 = new Service() { ServiceName = "Замена батареи", Price = 1000 };
            var s3 = new Service() { ServiceName = "Замена материнской платы", Price = 2000 };
            var s4 = new Service() { ServiceName = "Замена камеры", Price = 3000 };
            await db.Services.AddRangeAsync(s1, s2, s3, s4);

            var sm1 = new ServiceModel() {model = model1, Services = s1,Note="!!!", Discription = "Работы на пару дней" };
            var sm2 = new ServiceModel() { model = model2, Services = s2, Note = "!!233", Discription = "Сложно" };
            var sm3 = new ServiceModel() { model = model3, Services = s3, Note = "!№!", Discription = "Легко" };
            var sm4 = new ServiceModel() { model = model4, Services = s4, Note = "!0!", Discription = "За вечер закончим" };
            await db.ServiceModels.AddRangeAsync(sm1, sm2, sm3, sm4);

            var com1 = new Complaint() {Discription = "Долгая обработка",ComplaintType = "Незначительная" };
            var com2 = new Complaint() { Discription = "От мастера плохо пахло", ComplaintType = "Значительная" };
            await db.Complaints.AddRangeAsync(com1,com2);

            var o1 = new Order() { Service = s1, Warraty = "Нет", Emp = Ep1, Client = cl1, DateIssue = new DateTime(2022, 12, 03), Description = "Не работает экран, внешнее состояние без нареканий" };
            var o2 = new Order() { Service = s2, Warraty = "Нет", Emp = Ep3, Client = cl2, DateIssue = new DateTime(2022, 12, 02), Description = "Не работает аккумулятор, внешнее состояние без нареканий"};
            var o3 = new Order() { Service = s3, Warraty = "Нет", Emp = Ep3, Client = cl3, DateIssue = new DateTime(2022, 12, 01), Description = "Не работает материнская плата, внешнее состояние без нареканий", Complaints = com1 };
            var o4 = new Order() { Service = s4, Warraty = "Да", Emp = Ep1, Client = cl4, DateIssue = new DateTime(2022, 12, 03), Description = "Не работает камера, внешнее состояние без нареканий",Complaints =com2 };
            await db.Orders.AddRangeAsync(o1, o2, o3, o4);


            var user = new User("1@mail.ru", "111");
            await db.Users.AddAsync(user);
            await db.SaveChangesAsync();
        }
    }
}
