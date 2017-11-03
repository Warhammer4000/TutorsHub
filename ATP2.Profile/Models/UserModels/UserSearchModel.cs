using System.Collections.Generic;
using Entity;
using Entity.UserModels;

namespace ATP2.Profile.Models.UserModels
{
    public enum FilterBy { Any,Name,Email,Status}
    public class UserSearchModel
    {

        public string SearchText { get; set; }
        public List<User> Users { get; set; }

        public UserSearchModel()
        {
            Users=new List<User>();
        }
    }
}