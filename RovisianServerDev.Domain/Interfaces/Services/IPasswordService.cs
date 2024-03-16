namespace RovisianServerDev.Domain.Interfaces.Services
{
    public interface IPasswordService
    {
        string Hash(string password, byte[] salt);

        byte[] GenerateSalt();

        bool Verify(string passwordEntered, string storedHashed, byte[] salt);
    }
}
