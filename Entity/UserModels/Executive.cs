namespace Entity.UserModels
{
    public class Executive:User
    {
        public Executive()
        {
            Role = Role.Executive;
        }

        public override User Copy(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}
