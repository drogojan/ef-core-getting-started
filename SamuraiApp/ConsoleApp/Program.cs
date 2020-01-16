﻿using System;
using System.Linq;
using SamuraiApp.Data;
using SamuraiApp.Domain;

namespace ConsoleApp
{
    internal class Program
    {
        private static SamuraiContext context = new SamuraiContext();

        private static void Main(string[] args)
        {
            // context.Database.EnsureCreated();
            GetSamurais("Before Add:");
            AddSamurai();
            GetSamurais("After Add:");
            InsertMultipleSamurais();
            Console.Write("Press any key...");
            Console.ReadKey();
        }

        private static void AddSamurai()
        {
            var samurai = new Samurai {Name = "Sampson"};
            context.Samurais.Add(samurai);
            context.SaveChanges();
        }
        
        private static void InsertMultipleSamurais()
        {
            var samurai = new Samurai {Name = "Sampson"};
            var samurai2 = new Samurai {Name = "Tasha"};
            var samurai3 = new Samurai {Name = "Number 3"};
            var samurai4 = new Samurai {Name = "Number 4"};
            context.Samurais.AddRange(samurai, samurai2, samurai3, samurai4);
            context.SaveChanges();
        }

        private static void InsertVariousTypes()
        {
            var samurai = new Samurai { Name = "Kikuchio" };
            var clan = new Clan { ClanName = "Imperial Clan" };
            context.AddRange(samurai, clan);
            context.SaveChanges();
        }

        private static void GetSamurais(string text)
        {
            var samurais = context.Samurais.ToList();
            Console.WriteLine($"{text}: Samurai count is {samurais.Count}");
            foreach (var samurai in samurais)
            {
                Console.WriteLine(samurai.Name);
            }
        }
    }
}
