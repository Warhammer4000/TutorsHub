namespace Entity.UserModels
{
    public class Executive:User
    {
        public Executive()
        {
            Role = Role.Executive;
        }

        public override void Copy(object o)
        {
            throw new System.NotImplementedException();
        }
    }
}
