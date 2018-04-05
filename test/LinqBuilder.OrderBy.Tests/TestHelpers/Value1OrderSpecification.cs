﻿using System;
using System.Linq.Expressions;

namespace LinqBuilder.OrderBy.Tests.TestHelpers
{
    public class Value1OrderSpecification : OrderSpecification<Entity, int>
    {
        public Value1OrderSpecification(Sort sort = Sort.Ascending) : base(sort) { }

        public override Expression<Func<Entity, int>> AsExpression()
        {
            return entity => entity.Value1;
        }
    }
}
