using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoBadge_Repo
{
    public class BadgeRepo
    {
        protected readonly Dictionary<string, Badges> _Badges = new Dictionary<string, Badges>();
        protected readonly List<Badges> _badges = new List<Badges>();


        // Create
        public void CreateNewBadges(Badges content)
        {
            _badges.Add(content);
        }
        
        //Read
        public List<Badges> GetBadgesByList()
        {
            return _badges;
        }
          

        // Update
        public bool UpdateExistingDoors(string doors, Badges newcontent)
        {
            Badges oldcontent = GetBadge(doors);

            if(oldcontent != null)
            {
                oldcontent.BadgeID = newcontent.BadgeID;
                oldcontent.Doors = newcontent.Doors;
                return true;

            }
            else
            {
                return false;
            }
        }

        public bool DeleteDoorFromExisitingBadges(string doors)
        {
            Badges content = GetBadge(doors);

            if (content == null)
            {
                return false;
            }
            int intialCount = _badges.Count;
            _badges.Remove(content);

            if (intialCount > _badges.Count)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public Badges GetBadge(string doors)
        {
            foreach(Badges content in _badges)
            {
                if (content.BadgeID == doors)
                {
                    return content;
                }
            }
            return null;
        }
    }
}
