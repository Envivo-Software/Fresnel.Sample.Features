// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using System;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of Date properties
    /// </summary>
    public class DateValues
    {
        private DateTime _DateTime = DateTime.Now;

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This is an unformatted Date.
        /// Clicking the value reveals the appropriate editor control.
        /// </summary>
        public DateTime NormalDate
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        /// <summary>
        /// This is a date showing a Time format.
        /// Clicking the value reveals the appropriate editor control.
        /// </summary>
        [DataType(DataType.Time)]
        public DateTime TimeFormat
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        /// <summary>
        /// This is a date showing a Date format.
        /// Clicking the value reveals the appropriate editor control.
        /// </summary>
        [DataType(DataType.Date)]
        public DateTime DateFormat
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        /// <summary>
        /// This is a Date showing a custom format "yyyy MMMM dd (dddd) h:mm tt"
        /// </summary>
        [DisplayFormat(DataFormatString = "yyyy MMMM dd (dddd) h:mm tt")]
        public DateTime CustomDateFormat
        {
            get { return _DateTime; }
            set { _DateTime = value; }
        }

        /// <summary>
        /// This date has no setter, so will be read-only
        /// </summary>
        public DateTime DisabledDateFormat
        {
            get { return _DateTime; }
        }

        private TimeSpan _Timespan;

        /// <summary>
        /// This is a TimeSpan value, and will be editable using an appropriate editor
        /// </summary>
        public TimeSpan Timespan
        {
            get { return _Timespan; }
            set { _Timespan = value; }
        }
    }
}