namespace NUnit.Logic
{
    public class ValidationResult
    {
        public bool IsValid { get; set; } = false;
        public string ValidationMessage { get; set; } = string.Empty;
    }
}
