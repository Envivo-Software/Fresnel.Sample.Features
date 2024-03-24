// SPDX-FileCopyrightText: Copyright (c) 2022-2024 Envivo Software
// SPDX-License-Identifier: Apache-2.0
using Envivo.Fresnel.ModelAttributes;
using Envivo.Fresnel.ModelAttributes.Config;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Aggregates;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.Basics;
using Envivo.Fresnel.Sample.Features.Model.A_Objects.InheritanceByClass;
using Envivo.Fresnel.Sample.Features.Model.B_Collections;
using Envivo.Fresnel.Sample.Features.Model.C_Properties;
using Envivo.Fresnel.Sample.Features.Model.E_Methods;
using Envivo.Fresnel.Sample.Features.Model.G_Factories;
using Envivo.Fresnel.Sample.Features.Model.H_Queries;
using Envivo.Fresnel.Sample.Features.Model.J_Services;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Envivo.Fresnel.Sample.Features.Model
{
    public class ModelConfig : ModelConfigBase
    {
        /// <inheritdoc/>
        public override void Configure()
        {
            Configure_A_Objects();

            Configure_B_Collections();

            Configure_C_Properties();

            Configure_E_Methods();

            ConfigureClass<ExampleObject>()
                .Property(o => o.An_Int, new DefaultValueAttribute(99))
                .Property(o => o.A_DateTime, new DefaultValueAttribute(typeof(DateTimeValueProvider)))
                ;
        }

        private void Configure_A_Objects()
        {
            ConfigureClass<ExampleUsingDependencies>()
                .Property(o => o.Id, new KeyAttribute())
                ;

            ConfigureClass<SaveableAggregateRoot>()
                .WithAttributes(new VisualIdentifierAttribute { IconHtml = "<i class=\"bi bi-stack\"></i>", HtmlColour = "#DD0000" })
                .Property(o => o.Id, new KeyAttribute())
                .Property(o => o.Version, new ConcurrencyCheckAttribute())
                ;

            ConfigureClass<SaveableEntity>()
                .WithAttributes(new VisualIdentifierAttribute { IconHtml = "<i class=\"bi bi-layers-half\"></i>", HtmlColour = "#DF0000" })
                .Property(o => o.Id, new KeyAttribute())
                .Property(o => o.CreatedAt, new DefaultValueAttribute(typeof(DateTimeValueProvider)))
                ;

            ConfigureClass<AbstractObject>()
                .Property(o => o.HiddenProperty, new DisplayAttribute { AutoGenerateField = false })
                ;

            ConfigureClass<ExampleWithCustomNames>(new DisplayNameAttribute("Custom Names"))
                .Property(o => o.A_Boolean, new DisplayNameAttribute("Yes or No"))
                .Property(o => o.A_String, new DisplayNameAttribute("Text"))
                .Property(o => o.An_Int, new DisplayNameAttribute("Whole number"))
                .Property(o => o.A_Double, new DisplayNameAttribute("Fractional number"))
                .Property(o => o.A_DateTime, new DisplayNameAttribute("Date/Time"))
                .Method(o => o.A_Method, new DisplayNameAttribute("Open dialog"))
                .MethodParameter(o => o.A_Method, "property1", new DisplayNameAttribute("First property"))
                .MethodParameter(o => o.A_Method, "property2", new DisplayNameAttribute("Second property"))
                ;
        }

        private void Configure_B_Collections()
        {
            ConfigureClass<NestedChildObject>()
                .Property(p => p.Id, new KeyAttribute());

            ConfigureClass<ExampleOfCollectionProperties>()
                .Property(p => p.OwnedItems,
                                new RelationshipAttribute(RelationshipType.Owns),
                                new UIAttribute(UiRenderOption.InlineExpanded))
                .Method(m => m.AddNewOwnedItem,
                                new MethodAttribute(relatedPropertyName: nameof(ExampleOfCollectionProperties.OwnedItems)))

                .Property(p => p.AssociatedItems,
                                new RelationshipAttribute(RelationshipType.Has),
                                new UIAttribute(UiRenderOption.SeparateTabExpanded),
                                new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)),
                                new CollectionAttribute(nameof(ExampleOfCollectionProperties.AddToAssociatedItems),
                                                        nameof(ExampleOfCollectionProperties.RemoveFromAssociatedItems)))

                .Property(p => p.CollectionWithCustomColumns,
                                new RelationshipAttribute(RelationshipType.Owns),
                                new CollectionAttribute(visibleColumnNames: new string[] {
                                    nameof(ExampleObject.A_Bitwise_Enum),
                                    nameof(ExampleObject.An_Enum),
                                    nameof(ExampleObject.An_Object),
                                    nameof(ExampleObject.An_Int),
                                    nameof(ExampleObject.A_Boolean)
                                }))
                ;
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

            ConfigureClass<RequiredValues>()
                .Property(p => p.Id, new KeyAttribute())
                .Property(p => p.Version, new ConcurrencyCheckAttribute())
                .Property(p => p.NullableBool, new RequiredAttribute())
                .Property(p => p.NullableDateTime, new RequiredAttribute())
                .Property(p => p.NullableDouble, new RequiredAttribute())
                .Property(p => p.NullableInt, new RequiredAttribute())
                .Property(p => p.NullableString, new RequiredAttribute())
                ;

            ConfigureClass<ExceptionTests>()
                .Property(p => p.ThrowExceptionIfTrue, new UIAttribute(trueValue: "Do it!", falseValue: "Don't do it!"));

        }

        private void Configure_E_Methods()
        {
            ConfigureClass<ExamplesOfMethods>()
                .Method(o => o.MethodWithOneParameter, new KeyAttribute())
                .MethodParameter(o => o.MethodWithOneParameter, "dateTime",
                                        new RequiredAttribute(),
                                        new DisplayNameAttribute("Date/Time"),
                                        new DefaultValueAttribute(typeof(DateTimeValueProvider)),
                                        new DataTypeAttribute(DataType.DateTime))

                .MethodParameter(o => o.MethodWithObjectParameters, "entity",
                                        new RequiredAttribute(),
                                        new UIAttribute(preferredControl: UiControlType.Select),
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))

                .MethodParameter(o => o.MethodWithObjectParameters, "entities",
                                        new RequiredAttribute(),
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))

                .MethodParameter(o => o.MethodWithValueParameters, "aString",
                                        new DisplayAttribute { Prompt = "Enter a value" })
                .MethodParameter(o => o.MethodWithValueParameters, "aNumber",
                                        new RangeAttribute(0, 99))
                .MethodParameter(o => o.MethodWithValueParameters, "aDate",
                                        new DisplayAttribute { Prompt = "Enter a date" },
                                        new DefaultValueAttribute(typeof(DateTimeValueProvider)),
                                        new DataTypeAttribute(DataType.Date))

                .MethodParameter(o => o.MethodWithObjectParameters, "entity",
                                        new UIAttribute(preferredControl: UiControlType.Select),
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))
                .MethodParameter(o => o.MethodWithObjectParameters, "entities",
                                        new FilterQuerySpecificationAttribute(typeof(SaveableEntityQuerySpecification)))

                .MethodParameter(o => o.MethodWithRequiredParameters, "aString", new RequiredAttribute())
                .MethodParameter(o => o.MethodWithRequiredParameters, "anInteger", new RequiredAttribute())
                .MethodParameter(o => o.MethodWithRequiredParameters, "aBoolean", new RequiredAttribute())
                .MethodParameter(o => o.MethodWithRequiredParameters, "aDate",
                                        new RequiredAttribute(),
                                        new DataTypeAttribute(DataType.Date))
            ;
        }
    }
}
