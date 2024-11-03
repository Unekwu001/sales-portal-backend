namespace API.Data.Dtos
{
    public class ipNXApiResponse
    {
        public static object Success(string message)
        {
            return new { Successful = true, Message = message };
        }

        public static object Failure(string message)
        {
            return new { Successful = false, Message = message };
        }
    }
}
