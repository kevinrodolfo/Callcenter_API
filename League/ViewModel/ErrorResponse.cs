namespace Callcenter.ViewModel
{
    public class ErrorResponse : JsonResponse
    {
        public string ErrorMessage { get; set; } = default!;
    }
}
