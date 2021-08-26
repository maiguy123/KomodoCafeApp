using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoBadge_Repo
{
    [TestClass]
    public class Badges
    {
        public string BadgeID { get; set; }
        public List<string> Doors { get; set; }
        public Badges() { }
        public Badges(string badgeID, List<string> doors)
        {
            BadgeID = badgeID;
            Doors = doors;

        }

    }


}

