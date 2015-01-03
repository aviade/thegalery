namespace TheGalery.Core
{
    public class UserCredentials
    {
        public static UserCredentials Default = new UserCredentials(CredentialsType.Deafult);

        public CredentialsType CredentialsType { get; private set; }

        public UserCredentials(CredentialsType credentialsType)
        {
            CredentialsType = credentialsType;
        }
    }

    public enum CredentialsType
    {
        Deafult,
        DropBox,
        GoogleDrive,
        OneDrive,
    }
}
