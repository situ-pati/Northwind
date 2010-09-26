namespace Northwind.Data.NHibernateMaps
{
    using System;

    using FluentNHibernate.Automapping;
    using FluentNHibernate.Conventions;

    using Northwind.Core;
    using Northwind.Data.NHibernateMaps.Conventions;

    using SharpArch.Core.DomainModel;
    using SharpArch.Data.NHibernate.FluentNHibernate;

    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            return
                AutoMap.AssemblyOf<Category>(new NorthwindMappingConfiguration()).Conventions.Setup(
                    this.GetConventions()).IgnoreBase<Entity>().IgnoreBase(typeof(EntityWithTypedId<>)).
                    UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();
        }

        private Action<IConventionFinder> GetConventions()
        {
            return c =>
                {
                    c.Add<PrimaryKeyConvention>();
                    c.Add<HasManyConvention>();
                    c.Add<TableNameConvention>();
                };
        }
    }
}