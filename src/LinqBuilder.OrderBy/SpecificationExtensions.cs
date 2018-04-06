﻿using System.Collections.Generic;

namespace LinqBuilder.OrderBy
{
    public static class SpecificationExtensions
    {
        public static IOrderedSpecification<TEntity> OrderBy<TEntity>(this ISpecification<TEntity> specification, IOrderSpecification<TEntity> orderSpecification)
            where TEntity : class
        {
            if (orderSpecification == null) throw Exceptions.SpecificationCannotBeNull(nameof(orderSpecification));
            return new OrderedSpecification<TEntity>(specification, new List<IOrderSpecification<TEntity>> { orderSpecification });
        }
    }
}
