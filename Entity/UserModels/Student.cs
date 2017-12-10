using System.Collections.Generic;

namespace Entity.UserModels
{
    public class Student:User
    {
        public List<Tutor> Tutors { get; set; }
        public List<Tutor> ActiveTutors { get; set; }
        public string Location { set; get; }
        public Student()
        {
            Role=Role.Student;
            Tutors=new List<Tutor>();
            ActiveTutors= new List<Tutor>();
        }

        public override User Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
