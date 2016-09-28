﻿using Microsoft.AspNet.SignalR.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Threading;

namespace RMSniperFeeder
{
    internal class Program
    {
        public static List<EncounterInfo> CreateData()
        {
            var PkmnLocations = new List<EncounterInfo>();
            Random rn = new Random();
            int c = rn.Next(1, 2);
            for (int i = 1; i < c + 1; i++)
            {
                PkmnLocations.Add(new EncounterInfo()
                {
                    EncounterId = (2157859740816806781 + rn.Next(1, 999)).ToString(),
                    Expiration = DateTime.Now.ToUnixTimestamp() + (int)new TimeSpan(0, 0, rn.Next(30, 90)).TotalMilliseconds,
                    PokemonName = ((PokemonId)rn.Next(1, 152)).ToString(),
                    Iv = 100,
                    Latitude = (-33.8646353402715 + rn.Next(1, 99999)).ToString("G17", CultureInfo.InvariantCulture),
                    Longitude = (151.20600957337419 + rn.Next(1, 99999)).ToString("G17", CultureInfo.InvariantCulture),
                    Move1 = ((PokemonMove)rn.Next(1, 241)).ToString(),
                    Move2 = ((PokemonMove)rn.Next(1, 241)).ToString(),
                    SpawnPointId = "6b12ae46d31"
                });
            }
            return PkmnLocations;
        }

        private static void Main(string[] args)
        {
            try
            {
                for (int i = 0; i < 5; i++)
                {
                    CloneConnection clone = new CloneConnection(i);
                    clone.Run();
                }
                do
                {
                    Thread.Sleep(99999);
                } while (true);
            }
            catch (Exception)
            {
            }
        }



    }
}