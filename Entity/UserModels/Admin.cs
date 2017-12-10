namespace Entity.UserModels
{
    public class Admin:User
    {
        public Admin()
        {
            Role=Role.Admin;
            
        }

        public void Copy(Admin admin)
        {
            throw new System.NotImplementedException();
        }

        public override User Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
