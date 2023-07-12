namespace CustomersExercise.Application
{
    public class BaseResult
    {
        public bool IsSuccess { get; set; } = true;
        public string ErrorMessage { get; set; }
    }
}
