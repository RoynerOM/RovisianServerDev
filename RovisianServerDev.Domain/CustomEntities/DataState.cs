using System.Text.Json;

namespace RovisianServerDev.Domain.CustomEntities
{

    public static class DataStateExtensions
    {
        public static string ToJson<T>(this DataState<T> dataState)
        {
            return JsonSerializer.Serialize(dataState, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            });
        }
    }

    public abstract class DataState<T>
    {
        public T? Data { get; }
        public string? Error { get; }
        public long? RequestTime { get; set; }
        public DataState(T? Data, string? Error, long? requestTime)
        {
            this.Data = Data;
            this.Error = Error;
            this.RequestTime = requestTime;
        }
    }


    public class DataSuccess<T> : DataState<T>
    {
        public DataSuccess(T data) : base(Data: data, null, null)
        {

        }
    }

    public class DataFailed<T> : DataState<T>
    {
        public DataFailed(string error) : base(default, Error: error, null)
        {

        }
    }

}