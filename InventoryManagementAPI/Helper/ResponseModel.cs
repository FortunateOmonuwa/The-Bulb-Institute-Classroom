namespace InventoryManagementAPI.Helper
{
    public class ResponseModel<T>
    {
        public bool IsSuccess { get; set; } 
        public string Messsage { get; set; }
        public T Result { get; set; }
        public int? ResultCode { get; set; }

        //Method for Success 
        public ResponseModel<T>SuccessResult(T result)
        {
            var c = new ResponseModel<T>
            {
                Messsage = "Operation Successfull",
                IsSuccess = true,
                Result = result,
                ResultCode = 200
            };
            return c;
        }
        //Method for failed
        public ResponseModel<T> FailedResult(T result)
        {
            var c = new ResponseModel<T>
            {
                Messsage = "Operation Successfull",
                IsSuccess = true,
                Result = result,
                ResultCode = 200
            };
            return c;
        }
    }
}
