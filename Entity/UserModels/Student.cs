using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.UserModels
{
    public class Student:User
    {
        [NotMapped]
        public List<Tutor> Tutors { get; set; }
        [NotMapped]
        public List<Tutor> ActiveTutors { get; set; }

        public string TutorsList { get; set; }

        public string ActiveTutorsList { get; set; }

        public string Schedule { get; set; }

        public string Location { set; get; }
        public Student()
        {
            Role=Role.Student;
            Tutors=new List<Tutor>();
            ActiveTutors= new List<Tutor>();
        }

        public override User Copy(User user)
        {
            Student student = (Student) user;
            Name = student.Name;
            Location = student.Location;
            ProfilePictureUrl = student.ProfilePictureUrl;
            Mobilenumber = student.Mobilenumber;
            return student;
        }
    }
}
