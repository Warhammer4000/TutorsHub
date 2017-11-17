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

        public override void Copy(object o)
        {
            throw new System.NotImplementedException();
        }
    }
}
