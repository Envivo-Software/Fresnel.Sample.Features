// SPDX-FileCopyrightText: Copyright (c) 2022-2023 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of Text(string) properties
    /// </summary>
    public class TextValues
    {
        private string _CustomValidation;

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is a normal Text property
        /// </summary>
        public string? NormalText { get; set; }

        /// <summary>
        /// This is a Text property with a public Getter, but a hidden Setter.
        /// </summary>
        public string? ReadOnlyText
        {
            get { return NormalText; }
            internal set { NormalText = value; }
        }

        /// <summary>
        /// This is a Text property with a public Getter, but no Setter.
        /// </summary>
        public string? ReadOnlyText2 => NormalText;

        /// <summary>
        /// This is a Text property with a hidden Getter, but a public Setter.
        /// This will not be visible in the UI.
        /// </summary>
        public string? WriteOnlyText
        {
            internal get { return NormalText; }
            set { NormalText = value; }
        }

        /// <summary>
        /// This is a public Text property, but will be hidden in the UI.
        /// </summary>
        [Display(AutoGenerateField = false)]
        public string? HiddenText
        {
            get { return NormalText; }
            set { NormalText = value; }
        }

        /// <summary>
        /// This is a multi-line Text property. Use SHIFT-ENTER to move to the next line.
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string? MultiLineText
        {
            get { return NormalText; }
            set { NormalText = value; }
        }

        /// <summary>
        /// This is a password string, and will be hidden using asterisks
        /// </summary>
        [DataType(DataType.Password)]
        public string? PasswordText { get; set; }

        /// <summary>
        /// This is a Text property that must be at most 8 characters
        /// </summary>
        [MaxLength(8)]
        public string? TextWithMaximumSize { get; set; }

        /// <summary>
        /// This is a Text property that must be between 8 and 16 characters in length
        /// </summary>
        [MinLength(8, ErrorMessage = "Please provide a value greater than 8 characters")]
        [MaxLength(16)]
        public string? TextWithSize { get; set; }

        /// <summary>
        /// This will force the string to only allow numbers
        /// </summary>
        [MaxLength(10)]
        [RegularExpression("[0-9]*")]
        public string? EditMaskText { get; set; }

        /// <summary>
        /// This property has custom validation when it is modified (try entering numeric digits)
        /// </summary>
        public string? CustomValidation
        {
            get { return _CustomValidation; }
            set
            {
                if (value?.Any(char.IsDigit) == true)
                    throw new ApplicationException("Numbers are not allowed!");

                _CustomValidation = value;
            }
        }

        /// <summary>
        /// Sets the text value using a method
        /// </summary>
        /// <param name="newValue">Provide the new value here</param>
        public void ChangeStringValue(string newValue)
        {
            this.NormalText = newValue;
        }
    }
}