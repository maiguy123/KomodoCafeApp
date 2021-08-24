using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadgeChallenge
{
    public class MenuRepo
    {
        protected readonly List<Menu> _menuDirectory = new List<Menu>();



        // Create
        public void AddContentToList(Menu content)
        {
            _menuDirectory.Add(content);
        }

        /// Read
        public List<Menu> GetMenuByList()
        {
            return _menuDirectory;
        }

        /// Update
        public bool UpdateExisitingMenu(string menu, Menu newcontent)
        {
            Menu oldcontent = GetMenu(menu);

            //update the content
            if (oldcontent != null)
            {
                oldcontent.Name = newcontent.Name;
                oldcontent.Descripition = newcontent.Descripition;
                oldcontent.Price = newcontent.Price;
                oldcontent.Ingredients = newcontent.Ingredients;
                return true;
            }
            else
            {
                return false;
            }
        }


        /// Delete
        public bool RemoveMenuFromList(string menu)
        {
            Menu content = GetMenu(menu);

            if (content == null)
            {
                return false;
            }

            int intialCount = _menuDirectory.Count;
            _menuDirectory.Remove(content);

            if (intialCount > _menuDirectory.Count)
            {
                return true;
            }
            else
            {
                return false;
            }


        }




        // Helper Method 
        public Menu GetMenu(string menu)
        {
            foreach (Menu content in _menuDirectory)
            {
                if (content.Name == menu)
                {
                    return content;
                }
            }

            return null;
        }
    }
}
