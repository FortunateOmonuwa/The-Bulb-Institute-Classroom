using UserManagementApi.Domain;

namespace UserManagementApi.Utilities
{
    public class ResponseModel<T>
    {
        public bool IsSuccessfull {  get; set; }
        public string Message { get; set; }
        public T Result { get; set; }
        public int? ResultCode { get; set; }

        //Method for handling Success responses
        public ResponseModel<T> SuccessResultData (T result)
        {
            var k = new ResponseModel<T>
            {
                Message = "Operation Successfull",
                IsSuccessfull = true,
                Result = result,
                ResultCode = 200
            };

            return k;
        } 
        //Method for handling failed response
        public ResponseModel<T> FailedResultData (T result)
        {
            var k = new ResponseModel<T>
            {
                Message = "Operation was not Successfull",
                IsSuccessfull = false,
                Result = result,
                ResultCode = 400
            };

            return k;
        }


    }
}
