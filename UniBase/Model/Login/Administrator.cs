namespace UniBase.Model.Login
{
    class Administrator : Users
    {
        public Administrator(int user_ID, string name, string email, string telephoneNo, string password, string imageSource) : base(user_ID, name, email, telephoneNo, password, imageSource)
        {

        }
    }
}
