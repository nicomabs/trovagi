using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trovagi.Models;


namespace Trovagi.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void Initialize()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<TrovagiContext>())
                {
                    context.Database.Migrate();
                }
            }
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<TrovagiContext>())
                {

                    //add admin user
                    if (!context.Cities.Any())
                    {
                        City Mexico = new City { Name = "Mexico" };
                        City Barcelone = new City { Name = "Barcelone" };
                        City Naples = new City { Name = "Naples" };
                        context.Cities.Add(Mexico); context.Cities.Add(Barcelone); context.Cities.Add(Naples);

                        Hotel Bellagio = new Hotel { Name = "Bellagio", Description = "Situé à Barcelone, à 400 mètres de la Sagrada Familia, l'Hotel Bellagio 1882 possède une piscine extérieure et une salle de sport. Cet hôtel 4 étoiles propose des chambres climatisées avec une salle de bains privative et une connexion Wi-Fi gratuite. ", PhoneNumber="0565437834", Address = "22bis, avenue des calzones Barcelone", IsSelected = false, PhotoName = "unknown.png", City = Barcelone };
                        Hotel Vesuvio = new Hotel { Name = "Grand Hotel Vesuvio", Description = "Cet établissement élégant, édifié au début du XXe siècle, jouit d'un impessionnant design Art déco. ", PhoneNumber = "0565437891", Address = "78, rue Carbonara Naples", IsSelected = false, PhotoName = "unknown.png", City = Naples };
                        Hotel Sun = new Hotel { Name = "SunHotel Club", Description = "Toutes les chambres présentent un style élégant, la climatisation, une connexion Wi-Fi gratuite et une télévision à écran plat. ", PhoneNumber = "0965425670", Address = "13, rue Bonneterie Barcelonne", IsSelected = false, PhotoName = "unknown.png", City = Barcelone };
                        Hotel Paradisio = new Hotel { Name = "Hotel Paradisio", Description = "Il faut le voir pour y croire ! ", PhoneNumber = "0966324678", Address = "38, impasse des quesadillas Mexico", IsSelected = false, PhotoName = "unknown.png", City = Mexico };


                        context.Hotels.Add(Bellagio); context.Hotels.Add(Vesuvio); context.Hotels.Add(Sun); context.Hotels.Add(Paradisio);
                        context.SaveChanges();
                        
                    }

                    context.SaveChanges();
                }
            }
        }
    }
}