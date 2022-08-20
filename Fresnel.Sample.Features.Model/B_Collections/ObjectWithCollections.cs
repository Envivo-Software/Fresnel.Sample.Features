using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model.B_Collections
{
    /// <summary>
    /// This object has collections with other objects within them
    /// </summary>
    public class ObjectWithCollections
    {
        private IList<BasicObject> _OwnedItems = new List<BasicObject>();
        private IList<SaveableEntity> _AssociatedItems = new List<SaveableEntity>();

        /// <summary>
        /// The unique Id for this entity
        /// </summary>
        [Key]
        public Guid Id { get; set; }

        /// <summary>
        ///
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// New items can be created within this property. Existing items cannot be added to this list.
        /// </summary>
        [Relationship(RelationshipType.Owns)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public IList<BasicObject> OwnedItems
        {
            get { return _OwnedItems; }
            set { _OwnedItems = value; }
        }

        /// <summary>
        /// Existing items can be added to this property.  New items cannot be added to this list.
        /// </summary>
        [Relationship(RelationshipType.Has)]
        [UI(renderOption: UiRenderOption.InlineExpanded)]
        public IList<SaveableEntity> AssociatedItems
        {
            get { return _AssociatedItems; }
            set { _AssociatedItems = value; }
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name;
        }
    }
}