﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CustomConfigurationProvider
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            builder.AddEnvironmentVariables();
            var config = builder.Build();
            builder.AddEntityFramework(options => 
                options.UseSqlServer(config["Data:DefaultConnection:ConnectionString"]));
            config = builder.Build();

            Console.WriteLine("key1={0}", config["key1"]);
            Console.WriteLine("key2={0}", config["key2"]);
            Console.WriteLine("key3={0}", config["key3"]);
        }
    }
}
