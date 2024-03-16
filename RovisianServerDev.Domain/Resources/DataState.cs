using System.Text.Json;

namespace RovisianServerDev.Domain.Resources
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
        // Encargado indicar peticion se hizo correctamento para los casos de eliminar y guardar y editar que no devuelven objectos
        public bool Success { get; set; }
        // Encargado de devolver objectos listas o modelo
        public T? Data { get; }
        public string? Error { get; }
        public DataState(T? data, string? error, bool success)
        {
            this.Success = success;
            this.Data = data;
            this.Error = error;
        }
    }


    public class DataSuccess<T> : DataState<T>
    {
        public DataSuccess(T data) : base(data: data, null, true)
        {

        }
    }

    public class DataFailed<T> : DataState<T>
    {
        public DataFailed(string error) : base(default, error: error, false)
        {

        }
    }

}