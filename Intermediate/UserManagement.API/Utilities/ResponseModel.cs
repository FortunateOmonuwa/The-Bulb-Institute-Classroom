namespace UserManagement.API.Utilities
{
    public class ResponseModel<T>
    {
        public bool IsSuccessful { get; set; }
        public string? Message { get; set; }
        public T Result { get; set; }
        public int? ResultCode { get; set; }

        //Method for handling failed request
        public ResponseModel<T> FailedResultData(T res)
        {
            var r = new ResponseModel<T>
            {
                Message = "Operation was not successful",              
                IsSuccessful = false,
                Result = res,
                ResultCode = 400
            };

            return r;
        }

        //Method for handling failed responses
        public ResponseModel<T> SuccessResultData(T result)
        {
            var r = new ResponseModel<T>
            {
                Message = "Operation Successful",
                IsSuccessful = true,
                Result = result,
                ResultCode = 200
            };

            return r;
        }

    }
}
