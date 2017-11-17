namespace Entity.UserModels
{
    public class Guest:User
    {
        public Guest()
        {
            Role=Role.Guest;
        }

        public override void Copy(object o)
        {
            throw new System.NotImplementedException();
        }
    }
}
