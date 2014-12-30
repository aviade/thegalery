using System.ComponentModel;

namespace TheGalery.Core.Readers
{
    static class ReaderFactory
    {
        public static IFileShareReader GetReader(UserCredentials credentials)
        {
            CredentialsType credentialsType = credentials.CredentialsType;
            if (credentialsType == CredentialsType.Deafult)
            {
                return new DefaultReader();
            }
            if (credentialsType == CredentialsType.DropBox)
            {
                return new DropBoxReader();
            }
            if (credentialsType == CredentialsType.GoogleDrive)
            {
                return new GoogleDriveReader();
            }
            if (credentialsType == CredentialsType.OneDrive)
            {
                return new OneDriveReader();
            }
            throw new InvalidEnumArgumentException(credentialsType.ToString());
        }
    }
}
