using System.ComponentModel.DataAnnotations;

namespace OWASPTop10.Models
{
    public sealed class ShouldNotContainSingleQuotesValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !value.ToString().Contains("'");
        }
    }
}
