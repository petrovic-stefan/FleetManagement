using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public static class Seed
{
    public static async Task EnsureSeedAsync(this FleetDbContext db)
    {
        await db.Database.EnsureCreatedAsync();

        if (!await db.Vehicles.AnyAsync())
        {
            db.Vehicles.AddRange(
                new Vehicle
                {
                    PlateNumber = "BG-123-AA",
                    Make = "Ford",
                    Model = "Transit",
                    Year = 2018,
                    Odometer = 185000,
                    VIN = "WF0XXXTTGXJA12345"
                },
                new Vehicle
                {
                    PlateNumber = "NS-456-BB",
                    Make = "VW",
                    Model = "Crafter",
                    Year = 2019,
                    Odometer = 142500,
                    VIN = "WV1ZZZ2EZKX123456"
                },
                new Vehicle
                {
                    PlateNumber = "NI-789-CC",
                    Make = "Peugeot",
                    Model = "Boxer",
                    Year = 2017,
                    Odometer = 210300,
                    VIN = "VF3YCBMFB12A34567"
                },
                new Vehicle
                {
                    PlateNumber = "KG-321-DD",
                    Make = "Mercedes-Benz",
                    Model = "Sprinter",
                    Year = 2020,
                    Odometer = 96500,
                    VIN = "WDB9066571S543210"
                },
                new Vehicle
                {
                    PlateNumber = "SU-654-EE",
                    Make = "Opel",
                    Model = "Movano",
                    Year = 2016,
                    Odometer = 250800,
                    VIN = "W0L0ZCF6898012345"
                },
                new Vehicle
                {
                    PlateNumber = "ZR-987-FF",
                    Make = "Citroën",
                    Model = "Jumper",
                    Year = 2015,
                    Odometer = 278400,
                    VIN = "VF7YCBMFA12D67890"
                },
                new Vehicle
                {
                    PlateNumber = "LO-852-GG",
                    Make = "Iveco",
                    Model = "Daily",
                    Year = 2021,
                    Odometer = 45300,
                    VIN = "ZCFC135A1M1234567"
                },
                new Vehicle
                {
                    PlateNumber = "VR-369-HH",
                    Make = "Renault",
                    Model = "Master",
                    Year = 2018,
                    Odometer = 162000,
                    VIN = "VF1MAFEF521234567"
                }
            );

            await db.SaveChangesAsync();
        }
    }
}
