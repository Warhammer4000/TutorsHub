namespace Entity.UserModels
{
    public class Student:User
    {
        public Student()
        {
            Role=Role.Student;
        }

        public override void Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
