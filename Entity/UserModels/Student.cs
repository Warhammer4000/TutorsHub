using System.Collections.Generic;

namespace Entity.UserModels
{
    public class Student:User
    {
        public List<Tutor> Tutors { get; set; }
        public List<Tutor> ActiveTutors { get; set; }
        public Student()
        {
            Role=Role.Student;
            Tutors=new List<Tutor>();
            ActiveTutors= new List<Tutor>();
        }

        public override void Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
