﻿using Microsoft.EntityFrameworkCore;
using BattleCards.Data;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using BattleCards.Services;

namespace BattleCards
{
    public class Startup : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUserService, UserService>();
            serviceCollection.Add<ICardsService, CardsService>();
        }

        public void Configure(List<Route> routeTable)
        {
            new ApplicationDbContext().Database.Migrate();
        }
    }
}
