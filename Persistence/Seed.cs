using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;

namespace Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (!context.Activities.Any()){

                var activities = new List<Activity>
                {
                    new Activity
                    {
                        Title = "Past Activity 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Activity 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Activity
                    {
                        Title = "Past Activity 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Activity 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                    },
                    new Activity
                    {
                        Title = "Future Activity 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Activity 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                    },
                    new Activity
                    {
                        Title = "Future Activity 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Activity 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Activity
                    {
                        Title = "Future Activity 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Activity 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Activity 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Activity 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Just another pub",
                    },
                    new Activity
                    {
                        Title = "Future Activity 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Activity 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "Roundhouse Camden",
                    },
                    new Activity
                    {
                        Title = "Future Activity 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Activity 2 months ago",
                        Category = "travel",
                        City = "London",
                        Venue = "Somewhere on the Thames",
                    },
                    new Activity
                    {
                        Title = "Future Activity 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Activity 8 months in future",
                        Category = "film",
                        City = "London",
                        Venue = "Cinema",
                    }
                };
                await context.Activities.AddRangeAsync(activities);
            }
            
           if (!context.Concerts.Any()){

                var concerts = new List<Concert>
                {
                    new Concert
                    {
                        Title = "Past Concert 1",
                        Date = DateTime.Now.AddMonths(-2),
                        Description = "Concert 2 months ago",
                        Category = "drinks",
                        City = "London",
                        Venue = "Pub",
                    },
                    new Concert
                    {
                        Title = "Past Concert 2",
                        Date = DateTime.Now.AddMonths(-1),
                        Description = "Concert 1 month ago",
                        Category = "culture",
                        City = "Paris",
                        Venue = "Louvre",
                    },
                    new Concert
                    {
                        Title = "Future Concert 1",
                        Date = DateTime.Now.AddMonths(1),
                        Description = "Concert 1 month in future",
                        Category = "culture",
                        City = "London",
                        Venue = "Natural History Museum",
                    },
                    new Concert
                    {
                        Title = "Future Concert 2",
                        Date = DateTime.Now.AddMonths(2),
                        Description = "Concert 2 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "O2 Arena",
                    },
                    new Concert
                    {
                        Title = "Future Concert 3",
                        Date = DateTime.Now.AddMonths(3),
                        Description = "Concert 3 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Another pub",
                    },
                    new Concert
                    {
                        Title = "Future Concert 4",
                        Date = DateTime.Now.AddMonths(4),
                        Description = "Concert 4 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Yet another pub",
                    },
                    new Concert
                    {
                        Title = "Future Concert 5",
                        Date = DateTime.Now.AddMonths(5),
                        Description = "Concert 5 months in future",
                        Category = "drinks",
                        City = "London",
                        Venue = "Just another pub",
                    },
                    new Concert
                    {
                        Title = "Future Concert 6",
                        Date = DateTime.Now.AddMonths(6),
                        Description = "Concert 6 months in future",
                        Category = "music",
                        City = "London",
                        Venue = "Roundhouse Camden",
                    },
                    new Concert
                    {
                        Title = "Future Concert 7",
                        Date = DateTime.Now.AddMonths(7),
                        Description = "Concert 2 months ago",
                        Category = "travel",
                        City = "London",
                        Venue = "Somewhere on the Thames",
                    },
                    new Concert
                    {
                        Title = "Future Concert 8",
                        Date = DateTime.Now.AddMonths(8),
                        Description = "Concert 8 months in future",
                        Category = "film",
                        City = "London",
                        Venue = "Cinema",
                    }
                };
                await context.Concerts.AddRangeAsync(concerts);

           }
            await context.SaveChangesAsync();
        }
    }
}