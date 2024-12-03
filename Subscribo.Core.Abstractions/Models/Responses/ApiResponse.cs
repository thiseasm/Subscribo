using Subscribo.Core.Abstractions.Enums;

namespace Subscribo.Core.Abstractions.Models.Responses
{
    public class ApiResponse<T>
    {
        public T Value { get; }
        public bool IsSuccess { get; }
        public string ErrorMessage { get; }
        public ResponseCode Code { get; }

        private ApiResponse(bool isSuccess, T value, string error, ResponseCode code)
        {
            IsSuccess = isSuccess;
            Value = value;
            ErrorMessage = error;
            Code = code;
        }

        public static ApiResponse<T> Success(T value, ResponseCode code) => new(true, value, null, code);
        public static ApiResponse<T> Fail(string error, ResponseCode code) => new(false, default, error, code);
    }
}
