namespace Entity.UserModels
{
    public class Guest:User
    {
        public Guest()
        {
            Role=Role.Guest;
        }

    }
}
