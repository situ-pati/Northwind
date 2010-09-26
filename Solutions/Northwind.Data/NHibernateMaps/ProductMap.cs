﻿namespace Northwind.Data.NHibernateMappings
{
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;

    using Northwind.Core;

    public class ProductMap : IAutoMappingOverride<Product>
    {
        public void Override(AutoMapping<Product> mapping)
        {
            mapping.Id(x => x.Id, "ProductID").UnsavedValue(0).GeneratedBy.Identity();

            mapping.References(x => x.Supplier, "SupplierID");
            mapping.References(x => x.Category, "CategoryID");
        }
    }
}