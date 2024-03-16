namespace RovisianServerDev.Domain.Error
{
  
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message){}
    }

    public class DataDuplicateException : Exception
    {
        public DataDuplicateException(string message) : base(message){ }
    }

    public class ParamNullException : Exception
    {
        public ParamNullException(string message) : base(message){}
    }


}
