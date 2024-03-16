namespace RovisianServerDev.Api.Responses
{
    public class ControllerResponse<T>
    {
        public ControllerResponse(T data)
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
