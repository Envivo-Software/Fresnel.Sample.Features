using Envivo.Fresnel.ModelAttributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of Number properties
    /// </summary>
    public class NumberValues
    {
        /// <summary>
        ///
        /// </summary>
        public NumberValues()
        {
            DoubleNumber = double.NaN;
        }

        private int _IntValue = 0;

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is a normal Number
        /// </summary>
        public int NormalNumber
        {
            get { return _IntValue; }
            set { _IntValue = value; }
        }

        /// <summary>
        /// This is a Number with a public Getter, but a hidden Setter.
        /// </summary>
        public int ReadOnlyNumber
        {
            get { return _IntValue; }
            internal set { _IntValue = value; }
        }

        /// <summary>
        /// This is a Number with a hidden Getter, but a public Setter.
        /// This will not be visible in the UI.
        /// </summary>
        public int WriteOnlyNumber
        {
            internal get { return _IntValue; }
            set { _IntValue = value; }
        }

        /// <summary>
        /// This is a public Number, but will be hidden in the UI.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public int HiddenNumber
        {
            get { return _IntValue; }
            set { _IntValue = value; }
        }

        /// <summary>
        /// This is a Number with a range of -234 to +234.
        /// Values beyond the ranges will not be allowed from the UI.
        /// </summary>
        [Range(-234, 234, ErrorMessage = "Please provide a value between -234 and +234")]
        public int NumberWithRange
        {
            get { return _IntValue; }
            set { _IntValue = value; }
        }

        /// <summary>
        /// This is a Float number
        /// </summary>
        [Display(GroupName = "Decimal Points")]
        public float FloatNumber { get; set; }

        /// <summary>
        /// This is a Double that is shown using local Currency format
        /// </summary>
        [DataType(DataType.Currency)]
        [Display(GroupName = "Decimal Points")]
        public double DoubleNumber { get; set; }

        /// <summary>
        /// This is a Float number shown to 5 decimal places
        /// </summary>
        [UI(decimalPlaces: 5)]
        [Display(GroupName = "Decimal Points")]
        public float FloatNumberWithPlaces { get; set; }

        /// <summary>
        /// This is a normal Decimal Number
        /// </summary>
        [Display(GroupName = "Decimal Points")]
        public decimal DecimalNumber { get; set; }

        /// <summary>
        /// This is a number property with a custom title
        /// </summary>
        [Display(Name = "This name has been made up")]
        internal virtual int CustomNumber
        {
            get { return _IntValue; }
            set { _IntValue = value; }
        }
    }
}