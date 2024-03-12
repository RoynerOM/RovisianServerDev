namespace RovisianServerDev.Domain.UseCases
{
    public interface IUseCase<Type,Values>
    {
       Task<Type> Call(Values? values);

    }
}
