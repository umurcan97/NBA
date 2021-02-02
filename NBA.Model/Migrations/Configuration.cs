using System.Collections.Generic;

namespace NBA.Model.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NBA.Model.NBAContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(NBA.Model.NBAContext context)
        {
            context.Teams.Add(new Teams { ShortName = "ATL" , Conference = "EAST" , TeamName = "ATLANTAHAWKS" });
            context.Teams.Add(new Teams { ShortName = "BOS" , Conference = "EAST" , TeamName = "BOSTONCELTICS" });
            context.Teams.Add(new Teams { ShortName = "BKN" , Conference = "EAST" , TeamName = "BROOKLYNNETS" });
            context.Teams.Add(new Teams { ShortName = "CHA" , Conference = "EAST" , TeamName = "CHARLOTTEHORNETS" });
            context.Teams.Add(new Teams { ShortName = "CHI" , Conference = "EAST" , TeamName = "CHICAGOBULLS" });
            context.Teams.Add(new Teams { ShortName = "CLE" , Conference = "EAST" , TeamName = "CLEVELANDCAVALIERS" });
            context.Teams.Add(new Teams { ShortName = "DAL" , Conference = "WEST" , TeamName = "DALLASMAVERICKS" });
            context.Teams.Add(new Teams { ShortName = "DEN" , Conference = "WEST" , TeamName = "DENVERNUGGETS" });
            context.Teams.Add(new Teams { ShortName = "DET" , Conference = "EAST" , TeamName = "DETROITPISTONS" });
            context.Teams.Add(new Teams { ShortName = "GSW" , Conference = "WEST" , TeamName = "GOLDENSTATEWARRIORS" });
            context.Teams.Add(new Teams { ShortName = "HOU" , Conference = "WEST" , TeamName = "HOUSTONROCKETS" });
            context.Teams.Add(new Teams { ShortName = "IND" , Conference = "EAST" , TeamName = "INDIANAPACERS" });
            context.Teams.Add(new Teams { ShortName = "LAC" , Conference = "WEST" , TeamName = "LACLIPPERS" });
            context.Teams.Add(new Teams { ShortName = "LAL" , Conference = "WEST" , TeamName = "LOSANGELESLAKERS" });
            context.Teams.Add(new Teams { ShortName = "MEM" , Conference = "WEST" , TeamName = "MEMPHISGRIZZLIES" });
            context.Teams.Add(new Teams { ShortName = "MIA" , Conference = "EAST" , TeamName = "MIAMIHEAT" });
            context.Teams.Add(new Teams { ShortName = "MIL" , Conference = "EAST" , TeamName = "MILWAUKEEBUCKS" });
            context.Teams.Add(new Teams { ShortName = "MIN" , Conference = "WEST" , TeamName = "MINNESOTATIMBERWOLVES" });
            context.Teams.Add(new Teams { ShortName = "NOP" , Conference = "WEST" , TeamName = "NEWORLEANSPELICANS" });
            context.Teams.Add(new Teams { ShortName = "NYK" , Conference = "EAST" , TeamName = "NEWYORKKNICKS" });
            context.Teams.Add(new Teams { ShortName = "OKC" , Conference = "WEST" , TeamName = "OKLAHOMACITYTHUNDER" });
            context.Teams.Add(new Teams { ShortName = "ORL" , Conference = "EAST" , TeamName = "ORLANDOMAGIC" });
            context.Teams.Add(new Teams { ShortName = "PHI" , Conference = "EAST" , TeamName = "PHILADELPHIA76ERS" });
            context.Teams.Add(new Teams { ShortName = "PHX" , Conference = "WEST" , TeamName = "PHOENIXSUNS" });
            context.Teams.Add(new Teams { ShortName = "POR" , Conference = "WEST" , TeamName = "PORTLANDTRAILBLAZERS" });
            context.Teams.Add(new Teams { ShortName = "SAC" , Conference = "WEST" , TeamName = "SACRAMENTOKINGS" });
            context.Teams.Add(new Teams { ShortName = "SAS" , Conference = "WEST" , TeamName = "SANANTONIOSPURS" });
            context.Teams.Add(new Teams { ShortName = "TOR" , Conference = "EAST" , TeamName = "TORONTORAPTORS" });
            context.Teams.Add(new Teams { ShortName = "UTA" , Conference = "WEST" , TeamName = "UTAHJAZZ" });
            context.Teams.Add(new Teams { ShortName = "WAS" , Conference = "EAST" , TeamName = "WASHINGTONWIZARDS" });
            base.Seed(context);
        }
    }
}
