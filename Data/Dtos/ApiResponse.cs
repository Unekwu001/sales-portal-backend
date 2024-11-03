namespace API.Data.Dtos
{

    public class ApiResponse<T>
    {
        public bool Successful { get; set; }
        public string Message { get; set; }
        public T? Data { get; set; }

        public ApiResponse(bool success, string message, T data)
        {
            Successful = success;
            Message = message;
            Data = data;
        }

        public static object ApiSuccessResponse(bool success, string message) 
        {
            return new { Successful = success, Message = message };
        }
        
        public static ApiResponse<T> Success(T data, string message = "Success")
        {
            return new ApiResponse<T>(true, message, data);
        }


        public static ApiResponse<T> Failed(string message = "Failure", T data = default)
        {
            return new ApiResponse<T>(false, message, data);
        }
    }
 
}


