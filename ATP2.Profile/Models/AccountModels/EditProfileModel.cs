using System.Collections.Generic;
using BLL.DataRepository;
using Entity.Data;
using Entity.UserModels;

namespace ATP2.Profile.Models.AccountModels
{
    public class EditProfileModel
    {
        public Tutor Tutor { get; set; }
        public List<Subject> Subjects { get; set; }
        public List<Location> Locations { get; set; }
        public List<Class> Classes { get; set; }
        

        public EditProfileModel(Tutor tutor)
        {
            Tutor = tutor;
            Subjects=new SubjectRepository().GetAll();
            Locations=new LocationRepostiory().GetAll();
            Classes=new List<Class>();

            for (var i = 1; i <= 12; i++)
            {
                Classes.Add(new Class(){Value = i.ToString()});
            }

            /*foreach (var classes in tutor.PreferredClasses)
            {
                foreach (var classsClass in Classes)
                {
                    if (classsClass.Value.Equals(classes))
                    {
                        classsClass.IsChecked = true;
                    }
                }
            }*/

           
        }

        public EditProfileModel()
        {
            Tutor= new Tutor();
            Subjects = new List<Subject>();
            Locations = new List<Location>();
            Classes = new List<Class>(12);
            for (var i = 1; i <= 12; i++)
            {
                Classes.Add(new Class() { Value = i.ToString() });
            }
        }

    }

    public class Class
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public bool IsChecked { get; set; }
    }




}