using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelAttributes.Config;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass;
using Envivo.Fresnel.Sample.Features.Model.B_Collections;
using Envivo.Fresnel.Sample.Features.Model.C_Properties;
using Envivo.Fresnel.Sample.Features.Model.E_Methods;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model
{
    public class ModelConfig : ModelConfigBase
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public override void Configure()
        {
            Configure_A_Objects();

            Configure_B_Collections();

            Configure_C_Properties();

            ConfigureClass<MethodSamples>()
                .Method(o => o.MethodWithOneParameter, new KeyAttribute())
                .MethodParameter(o => o.MethodWithOneParameter, "dateTime",
                                        new DisplayAttribute { Name = "Date/Time" },
                                        new DataTypeAttribute(DataType.Date))
                .MethodParameter(o => o.MethodWithObjectParameters, "entity",
                                        new UIAttribute(preferredControl: UiControlType.Select),
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))
                .MethodParameter(o => o.MethodWithObjectParameters, "entities",
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))
                ;
        }

        private void Configure_A_Objects()
        {
            ConfigureClass<ObjectWithDependencies>()
                .Property(o => o.Id, new KeyAttribute())
                ;

            ConfigureClass<SaveableAggregateRoot>()
                .Property(o => o.Id, new KeyAttribute())
                .Property(o => o.Version, new ConcurrencyCheckAttribute())
                ;

            ConfigureClass<SaveableEntity>()
                .Property(o => o.Id, new KeyAttribute())
                ;

            ConfigureClass<AbstractObject>()
                .Property(o => o.HiddenProperty, new DisplayAttribute { AutoGenerateField = false })
                ;
        }

        private void Configure_B_Collections()
        {
            ConfigureClass<ChildObject>()
                .Property(p => p.Id, new KeyAttribute());

            ConfigureClass<ObjectWithCollections>()
                .Property(p => p.AssociatedItems,
                                new RelationshipAttribute(RelationshipType.Has),
                                new UIAttribute(UiRenderOption.InlineExpanded))
                .Property(p => p.OwnedItems,
                                new RelationshipAttribute(RelationshipType.Owns),
                                new UIAttribute(UiRenderOption.InlineExpanded));
        }

        private void Configure_C_Properties()
        {
            ConfigureClass<BooleanValues>()
                .Property(p => p.Orientation, new UIAttribute(trueValue: "Clockwise", falseValue: "Anti-Clockwise"));

            ConfigureClass<DateValues>()
                .Property(p => p.TimeFormat, new DataTypeAttribute(DataType.Time))
                .Property(p => p.DateFormat, new DataTypeAttribute(DataType.Date))
                .Property(p => p.CustomDateFormat, new DisplayFormatAttribute { DataFormatString = "yyyy MMMM dd (dddd) h:mm tt" })
                ;

            ConfigureClass<ExceptionTests>()
                .Property(p => p.ThrowExceptionIfTrue, new UIAttribute(trueValue: "Do it!", falseValue: "Don't do it!"));

        }
    }
}
