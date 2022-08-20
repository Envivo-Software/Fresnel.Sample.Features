using Envivo.Fresnel.ModelTypes.Interfaces;
using System;

namespace Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics
{
    /// <summary>
    /// This is a transient object, and will appear in the UI.
    /// Transient objects are not saveable.
    /// </summary>
    public class BasicObject : IEntity
    {
        public Guid Id { get; set; }


        /// <summary>
        /// The name of this object
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The description for this object
        /// </summary>
        public string Description { get; set; }
    }
}