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
            throw new InvalidEnumArgumentException(credentialsType.ToString());
        }
    }
}
