namespace Entity.UserModels
{
    public class Guest:User
    {
        public Guest()
        {
            Role=Role.Guest;
        }

        public override void Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
