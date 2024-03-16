using Envivo.Fresnel.ModelTypes.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.ValueObjects
{
/// <summary>
/// This object is only editable when new, and becomes read-only once the parent object is saved.
/// </summary>
public class Payment : IValueObject
{
    [Key]
    public Guid Id { get; set; }

    [DataType(DataType.Date)]
    public DateTime PaymentDate { get; set; } = DateTime.Now;

    public decimal Amount { get; set; } = new();

    public string? OtherNotes { get; set; }

    public override string ToString()
    {
        return $"{PaymentDate:d} : {Amount:c}";
    }
}
}
