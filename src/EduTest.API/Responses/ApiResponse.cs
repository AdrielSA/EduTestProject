using EduTest.Domain.CustomEntities;

namespace EduTest.API.Responses
{
    public class ApiResponse
    {
        public ApiResponse()
        {
            Success = true;
        }

        public bool Success { get; set; }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Content { get; set; }
        public MetaData MetaData { get; set; }
    }
}
