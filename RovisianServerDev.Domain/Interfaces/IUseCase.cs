namespace RovisianServerDev.Domain.Interfaces
{
    public interface IUseCase<Type, Values>
    {
        Task<Type> Call(Values? values);
    }
}
