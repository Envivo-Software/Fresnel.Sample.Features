namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass
{
    /// <summary>
    /// This object has a String and a couple of Methods
    /// </summary>
    public class ObjectC : AbstractObject
    {
        public string A_StringValue { get; set; }

        public void A_Method()
        {
            this.A_StringValue += "+ ";
        }

        public void A_MethodWithArgs(string value)
        {
            this.A_StringValue += $"{value} ";
        }
    }
}