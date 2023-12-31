﻿namespace Register.API.Helpers;

public class ConfigurationConnectionStrings
{

    public static IConfiguration ConfigConnection()
    {
        var configuration = new ConfigurationBuilder()
        .AddJsonFile("appsettings.Development.json")
        .Build();

        var cnn = configuration.GetSection("ConnectionStrings");

        return cnn;
    }
}
