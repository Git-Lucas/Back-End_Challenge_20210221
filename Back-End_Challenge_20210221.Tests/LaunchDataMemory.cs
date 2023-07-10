using Back_End_Challenge_20210221.Domain.Models;
using Back_End_Challenge_20210221.Domain.Models.Enums;

namespace Back_End_Challenge_20210221.Infra.Data
{
    public class LaunchDataMemory
    {
        public List<Launch> Launchers { get; set; } = new List<Launch>()
        {
            new ()
            {
                Id = new Guid("e3df2ecd-c239-472f-95e4-2b89b4f75800"),
                Url = new Uri("https://ll.thespacedevs.com/2.0.0/launch/e3df2ecd-c239-472f-95e4-2b89b4f75800"),
                Slug = "sputnik-8k74ps-sputnik-1",
                Name = "Sputnik 8K74PS | Sputnik 1",
                StatusLaunch = new()
                {
                    Id = 3,
                    Name = "Success"
                },
                Net = new DateTime(1957, 10, 04),
                WindowEnd = new DateTime(1957, 10, 04),
                WindowStart = new DateTime(1957, 10, 04),
                LaunchServiceProvider = new()
                {
                    Id = 66,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/agencies/66/"),
                    Name = "Soviet Space Program",
                    Type = "Government"
                },
                Rocket = new()
                {
                    Id = 3003,
                    Configuration = new()
                    {
                        Id = 468,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/config/launcher/468/"),
                        Name = "Sputnik 8K74PS",
                        Family = "Sputnik",
                        FullName = "Sputnik 8K74PS",
                        Variant = "8K74PS"
                    }
                },
                Mission = new()
                {
                    Id = 1430,
                    Name = "Sputnik 1",
                    Description = "First artificial satellite consisting of a 58 cm pressurized aluminium shell containing two 1 W transmitters for a total mass of 83.6 kg.",
                    Type = "Test Flight",
                    Orbit = new()
                    {
                        Id = 8,
                        Name = "Low Earth Orbit",
                        Abbrev = "LEO"
                    }
                },
                Pad = new()
                {
                    Id = 32,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/pad/32/"),
                    Name = "1/5",
                    MapUrl = new Uri("https://www.google.com/maps?q=45.92,63.342"),
                    Latitude = "45.92",
                    Longitude = "63.342",
                    Location = new()
                    {
                        Id = 15,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/location/15/"),
                        Name = "Baikonur Cosmodrome, Republic of Kazakhstan",
                        CountryCode = "KAZ",
                        MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_15_20200803142517.jpg"),
                        TotalLaunchCount = 1541,
                        TotalLandingCount = 0
                    },
                    MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_32_20200803143513.jpg"),
                    TotalLaunchCount = 487
                },
                Image = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launcher_images/sputnik_8k74ps_image_20210830185541.jpg"),
                Imported_T = DateTime.UtcNow,
                Status = Import_Status.Draft
            },
            new ()
            {
                Id = new Guid("f8c9f344-a6df-4f30-873a-90fe3a7840b3"),
                Url = new Uri("https://ll.thespacedevs.com/2.0.0/launch/f8c9f344-a6df-4f30-873a-90fe3a7840b3/"),
                Slug = "sputnik-8k74ps-sputnik-2",
                Name = "Sputnik 8K74PS | Sputnik 2",
                StatusLaunch = new()
                {
                    Id = 3,
                    Name = "Success"
                },
                Net = new DateTime(1957, 10, 04),
                WindowEnd = new DateTime(1957, 10, 04),
                WindowStart = new DateTime(1957, 10, 04),
                LaunchServiceProvider = new()
                {
                    Id = 66,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/agencies/66/"),
                    Name = "Soviet Space Program",
                    Type = "Government"
                },
                Rocket = new()
                {
                    Id = 3003,
                    Configuration = new()
                    {
                        Id = 468,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/config/launcher/468/"),
                        Name = "Sputnik 8K74PS",
                        Family = "Sputnik",
                        FullName = "Sputnik 8K74PS",
                        Variant = "8K74PS"
                    }
                },
                Mission = new()
                {
                    Id = 1430,
                    Name = "Sputnik 1",
                    Description = "First artificial satellite consisting of a 58 cm pressurized aluminium shell containing two 1 W transmitters for a total mass of 83.6 kg.",
                    Type = "Test Flight",
                    Orbit = new()
                    {
                        Id = 8,
                        Name = "Low Earth Orbit",
                        Abbrev = "LEO"
                    }
                },
                Pad = new()
                {
                    Id = 32,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/pad/32/"),
                    Name = "1/5",
                    MapUrl = new Uri("https://www.google.com/maps?q=45.92,63.342"),
                    Latitude = "45.92",
                    Longitude = "63.342",
                    Location = new()
                    {
                        Id = 15,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/location/15/"),
                        Name = "Baikonur Cosmodrome, Republic of Kazakhstan",
                        CountryCode = "KAZ",
                        MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_15_20200803142517.jpg"),
                        TotalLaunchCount = 1541,
                        TotalLandingCount = 0
                    },
                    MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_32_20200803143513.jpg"),
                    TotalLaunchCount = 487
                },
                Image = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launcher_images/sputnik_8k74ps_image_20210830185541.jpg"),
                Imported_T = DateTime.UtcNow,
                Status = Import_Status.Trash
            },
            new ()
            {
                Id = new Guid("535c1a09-97c8-4f96-bb64-6336d4bcb1fb"),
                Url = new Uri("https://ll.thespacedevs.com/2.0.0/launch/535c1a09-97c8-4f96-bb64-6336d4bcb1fb/"),
                Slug = "vanguard-vanguard",
                Name = "Vanguard | Vanguard",
                StatusLaunch = new()
                {
                    Id = 3,
                    Name = "Success"
                },
                Net = new DateTime(1957, 10, 04),
                WindowEnd = new DateTime(1957, 10, 04),
                WindowStart = new DateTime(1957, 10, 04),
                LaunchServiceProvider = new()
                {
                    Id = 66,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/agencies/66/"),
                    Name = "Soviet Space Program",
                    Type = "Government"
                },
                Rocket = new()
                {
                    Id = 3003,
                    Configuration = new()
                    {
                        Id = 468,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/config/launcher/468/"),
                        Name = "Sputnik 8K74PS",
                        Family = "Sputnik",
                        FullName = "Sputnik 8K74PS",
                        Variant = "8K74PS"
                    }
                },
                Mission = new()
                {
                    Id = 1430,
                    Name = "Sputnik 1",
                    Description = "First artificial satellite consisting of a 58 cm pressurized aluminium shell containing two 1 W transmitters for a total mass of 83.6 kg.",
                    Type = "Test Flight",
                    Orbit = new()
                    {
                        Id = 8,
                        Name = "Low Earth Orbit",
                        Abbrev = "LEO"
                    }
                },
                Pad = new()
                {
                    Id = 32,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/pad/32/"),
                    Name = "1/5",
                    MapUrl = new Uri("https://www.google.com/maps?q=45.92,63.342"),
                    Latitude = "45.92",
                    Longitude = "63.342",
                    Location = new()
                    {
                        Id = 15,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/location/15/"),
                        Name = "Baikonur Cosmodrome, Republic of Kazakhstan",
                        CountryCode = "KAZ",
                        MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_15_20200803142517.jpg"),
                        TotalLaunchCount = 1541,
                        TotalLandingCount = 0
                    },
                    MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_32_20200803143513.jpg"),
                    TotalLaunchCount = 487
                },
                Image = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launcher_images/sputnik_8k74ps_image_20210830185541.jpg"),
                Imported_T = DateTime.UtcNow,
                Status = Import_Status.Draft
            },
            new ()
            {
                Id = new Guid("1b9e28d0-c531-44b0-9b37-244e62a6d3f4"),
                Url = new Uri("https://ll.thespacedevs.com/2.0.0/launch/1b9e28d0-c531-44b0-9b37-244e62a6d3f4/"),
                Slug = "juno-i-explorer-1",
                Name = "Juno-I | Explorer 1",
                StatusLaunch = new()
                {
                    Id = 3,
                    Name = "Success"
                },
                Net = new DateTime(1957, 10, 04),
                WindowEnd = new DateTime(1957, 10, 04),
                WindowStart = new DateTime(1957, 10, 04),
                LaunchServiceProvider = new()
                {
                    Id = 66,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/agencies/66/"),
                    Name = "Soviet Space Program",
                    Type = "Government"
                },
                Rocket = new()
                {
                    Id = 3003,
                    Configuration = new()
                    {
                        Id = 468,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/config/launcher/468/"),
                        Name = "Sputnik 8K74PS",
                        Family = "Sputnik",
                        FullName = "Sputnik 8K74PS",
                        Variant = "8K74PS"
                    }
                },
                Mission = new()
                {
                    Id = 1430,
                    Name = "Sputnik 1",
                    Description = "First artificial satellite consisting of a 58 cm pressurized aluminium shell containing two 1 W transmitters for a total mass of 83.6 kg.",
                    Type = "Test Flight",
                    Orbit = new()
                    {
                        Id = 8,
                        Name = "Low Earth Orbit",
                        Abbrev = "LEO"
                    }
                },
                Pad = new()
                {
                    Id = 32,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/pad/32/"),
                    Name = "1/5",
                    MapUrl = new Uri("https://www.google.com/maps?q=45.92,63.342"),
                    Latitude = "45.92",
                    Longitude = "63.342",
                    Location = new()
                    {
                        Id = 15,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/location/15/"),
                        Name = "Baikonur Cosmodrome, Republic of Kazakhstan",
                        CountryCode = "KAZ",
                        MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_15_20200803142517.jpg"),
                        TotalLaunchCount = 1541,
                        TotalLandingCount = 0
                    },
                    MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_32_20200803143513.jpg"),
                    TotalLaunchCount = 487
                },
                Image = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launcher_images/sputnik_8k74ps_image_20210830185541.jpg"),
                Imported_T = DateTime.UtcNow,
                Status = Import_Status.Draft
            },
            new ()
            {
                Id = new Guid("48bc7deb-b2e1-46c2-ab63-0ce00fbd192b"),
                Url = new Uri("https://ll.thespacedevs.com/2.0.0/launch/48bc7deb-b2e1-46c2-ab63-0ce00fbd192b/"),
                Slug = "vanguard-vanguard-2",
                Name = "Vanguard | Vanguard",
                StatusLaunch = new()
                {
                    Id = 3,
                    Name = "Success"
                },
                Net = new DateTime(1957, 10, 04),
                WindowEnd = new DateTime(1957, 10, 04),
                WindowStart = new DateTime(1957, 10, 04),
                LaunchServiceProvider = new()
                {
                    Id = 66,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/agencies/66/"),
                    Name = "Soviet Space Program",
                    Type = "Government"
                },
                Rocket = new()
                {
                    Id = 3003,
                    Configuration = new()
                    {
                        Id = 468,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/config/launcher/468/"),
                        Name = "Sputnik 8K74PS",
                        Family = "Sputnik",
                        FullName = "Sputnik 8K74PS",
                        Variant = "8K74PS"
                    }
                },
                Mission = new()
                {
                    Id = 1430,
                    Name = "Sputnik 1",
                    Description = "First artificial satellite consisting of a 58 cm pressurized aluminium shell containing two 1 W transmitters for a total mass of 83.6 kg.",
                    Type = "Test Flight",
                    Orbit = new()
                    {
                        Id = 8,
                        Name = "Low Earth Orbit",
                        Abbrev = "LEO"
                    }
                },
                Pad = new()
                {
                    Id = 32,
                    Url = new Uri("https://ll.thespacedevs.com/2.0.0/pad/32/"),
                    Name = "1/5",
                    MapUrl = new Uri("https://www.google.com/maps?q=45.92,63.342"),
                    Latitude = "45.92",
                    Longitude = "63.342",
                    Location = new()
                    {
                        Id = 15,
                        Url = new Uri("https://ll.thespacedevs.com/2.0.0/location/15/"),
                        Name = "Baikonur Cosmodrome, Republic of Kazakhstan",
                        CountryCode = "KAZ",
                        MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/location_15_20200803142517.jpg"),
                        TotalLaunchCount = 1541,
                        TotalLandingCount = 0
                    },
                    MapImage = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launch_images/pad_32_20200803143513.jpg"),
                    TotalLaunchCount = 487
                },
                Image = new Uri("https://spacelaunchnow-prod-east.nyc3.digitaloceanspaces.com/media/launcher_images/sputnik_8k74ps_image_20210830185541.jpg"),
                Imported_T = DateTime.UtcNow,
                Status = Import_Status.Draft
            }
        };

        public int Count() => Launchers.Count();

        public int CountUnlikeTrash() => Launchers.Where(x => x.Status != Import_Status.Trash)
                                                                   .Count();

        public Launch Get(Guid id)
        {
            var launch = Launchers.SingleOrDefault(x => x.Id == id);

            if (launch is not null)
            {
                return launch;
            }
            else
            {
                throw new Exception("Not found!");
            }
        }

        public List<Launch> GetAll(int skip, int take) =>
            Launchers.Where(x => x.Status != Import_Status.Trash)
                     .Skip(skip)
                     .Take(take)
                     .ToList();

        public async Task Put(Guid id, Launch launch)
        {
            var launchList = Launchers.SingleOrDefault(x => x.Id == id);

            if (launchList is not null)
            {
                if (launchList.Status != Import_Status.Trash)
                {
                    launch.Status = Import_Status.Published;
                    launchList = launch;
                }
                else
                {
                    throw new Exception("Deleted locally.");
                }
            }
            else
            {
                throw new Exception("Not found.");
            }
        }

        public async Task Delete(Guid id)
        {
            try
            {
                var launch = Get(id);

                if (launch.Status != Import_Status.Trash)
                    launch.Status = Import_Status.Trash;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeleteAll() => Launchers.Clear();
    }
}
