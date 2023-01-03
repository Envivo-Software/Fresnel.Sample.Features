// SPDX-FileCopyrightText: Copyright (c) 2022 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.C_Properties
{
    /// <summary>
    /// A set of Exception handling
    /// </summary>
    public class ExceptionTests
    {
        private bool _Bool = false;
        private string _PropertyValue;

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// This property will thrown an exception when it is read
        /// </summary>
        public string PropertyWithReadError
        {
            get { throw new ApplicationException("This property threw an exception when it was accessed"); }
            set { _PropertyValue = value; }
        }

        /// <summary>
        /// This property will thrown an exception when it is modified
        /// </summary>
        public string PropertyWithWriteError
        {
            get { return _PropertyValue; }
            set { throw new ApplicationException("This property threw an exception when it was updated"); }
        }

        /// <summary>
        /// This will throw a single exception when the value is set to "Do it!"
        /// </summary>
        [UI(trueValue: "Do it!", falseValue: "Don't do it!")]
        public bool ThrowExceptionIfTrue
        {
            get { return _Bool; }

            set
            {
                _Bool = value;
                if (_Bool)
                {
                    throw new ApplicationException("This is a forced exception");
                }
            }
        }

        /// <summary>
        ///
        /// </summary>
        /// <returns></returns>
        public string ThrowAnException()
        {
            throw new ApplicationException("This is a forced exception");
        }
    }
}