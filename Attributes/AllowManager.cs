using System.ComponentModel.DataAnnotations;

namespace ChallangeBackend.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
    public class AllowManager : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            return base.IsValid(value);
        }
        public AllowManager() { }

    }
}
