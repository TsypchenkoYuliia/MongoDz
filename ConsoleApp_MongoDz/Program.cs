using ConsoleApp_MongoDz.Services;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_MongoDz
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PetService petService = new PetService(new MongoClient("mongodb://localhost:27017").GetDatabase("petdb"));

            if (await petService.CheckCollection() == 0)
                await InitializeDb(petService);

            ShowPage(petService);

            Console.WriteLine();

            await ShowReport(petService);

            Console.ReadLine();
        }

        private static async Task InitializeDb(PetService petService)
        {
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Murzik", RegistrationDate = new DateTime(2019, 4, 8), Owner = new Models.Owner { Name = "Olga", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Tuzik", RegistrationDate = new DateTime(2019, 7, 22), Owner = new Models.Owner { Name = "Marina", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Parrot", Nickname = "Kirik", RegistrationDate = new DateTime(2018, 2, 13), Owner = new Models.Owner { Name = "Oleg", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Rabbit", Nickname = "Senya", RegistrationDate = new DateTime(2020, 9, 10), Owner = new Models.Owner { Name = "Roma", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Phil", RegistrationDate = new DateTime(2019, 9, 10), Owner = new Models.Owner { Name = "Karina", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Murka", RegistrationDate = new DateTime(2020, 3, 14), Owner = new Models.Owner { Name = "Lera", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Rem", RegistrationDate = new DateTime(2018, 3, 25), Owner = new Models.Owner { Name = "Lena", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Alex", RegistrationDate = new DateTime(2019, 8, 21), Owner = new Models.Owner { Name = "Victor", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Ice", RegistrationDate = new DateTime(2021, 5, 5), Owner = new Models.Owner { Name = "Bella", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Rabbit", Nickname = "Robby", RegistrationDate = new DateTime(2020, 4, 29), Owner = new Models.Owner { Name = "Diana", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Sheri", RegistrationDate = new DateTime(2018, 4, 26), Owner = new Models.Owner { Name = "Alina", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Rabbit", Nickname = "Rex", RegistrationDate = new DateTime(2018, 6, 2), Owner = new Models.Owner { Name = "Stepan", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Tim", RegistrationDate = new DateTime(2019, 3, 22), Owner = new Models.Owner { Name = "Timur", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Cat", Nickname = "Sam", RegistrationDate = new DateTime(2017, 3, 12), Owner = new Models.Owner { Name = "Roma", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Roy", RegistrationDate = new DateTime(2018, 6, 24), Owner = new Models.Owner { Name = "Victor", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Dog", Nickname = "Ralph", RegistrationDate = new DateTime(2019, 4, 4), Owner = new Models.Owner { Name = "Karina", Phone = "+380975676545" } });
            await petService.AddAsync(new Models.Pet { Type = "Rabbit", Nickname = "Jack", RegistrationDate = new DateTime(2020, 9, 11), Owner = new Models.Owner { Name = "Marina", Phone = "+380975676545" } });
        }

        private static void ShowPage(PetService petService)
        {
            int skip = 0;
            int limit = 3;
            int page = 0;

            while (true)
            {
                var result = petService.ShowPage(new BsonDocument(), skip, limit);

                if (result.Count != 0)
                {
                    Console.WriteLine("------------------------------------------------------------------------------------------------------");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Page {++page}");
                    Console.ForegroundColor = ConsoleColor.White;

                    foreach (var item in result)
                        Console.WriteLine($"Nickname: {item.Nickname}, Type: {item.Type}, RegistrationDate: {item.RegistrationDate.Date.ToString("yyyy-mm-dd")}, Owner: {item.Owner.Name}, Phone: {item.Owner.Phone}");
                }
                else
                    break;

                Console.WriteLine("------------------------------------------------------------------------------------------------------");
                skip += 3;
            }
        }

        private static async Task ShowReport(PetService petService)
        {
            foreach (var item in await petService.ShowReport())
                Console.WriteLine($"Type: {item.Type}, Count: {item.Count}");
        }
    }
}
