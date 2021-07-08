using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Badge
{
    public class BadgeRepository
    {
        protected readonly Dictionary<int, List<string>> _doorAccessList = new Dictionary<int, List<string>>();
        protected readonly List<Badges> _badgeDirectory = new List<Badges>();
        public bool AddBadgeToDirectory(Badges newContent)
        {
            int startingCount = _doorAccessList.Count;
            _doorAccessList.Add(newContent.BadgeID, new List<string>());
            bool wasAdded = (_doorAccessList.Count > startingCount) ? true : false;
            return wasAdded;
        }


        public Dictionary<int, List<string>> GetContents()
        {
            return _doorAccessList;
        }
        public Badges GetBadgeByID(int badgeid)
        {
            foreach (Badges content in _badgeDirectory)
            {
                return content;
            }
            return null;
        }

        public bool UpdateExistingBadge(int originalBadgeID, Badges newContent)
        {
            Badges oldContent = GetBadgeByID(originalBadgeID);
            if (oldContent != null)
            {
                oldContent.BadgeID = newContent.BadgeID;
                oldContent.DoorAccess = newContent.DoorAccess;
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool DeleteExistingBadge(Badges existingContent)
        {
            bool deleteResult = _badgeDirectory.Remove(existingContent);
            return deleteResult;
        }
    }
}

