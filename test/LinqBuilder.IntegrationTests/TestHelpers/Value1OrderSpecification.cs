﻿using System;
using System.Linq.Expressions;
using LinqBuilder.OrderSpecifications;

namespace LinqBuilder.IntegrationTests.TestHelpers
{
    public class Value1OrderSpecification : OrderSpecification<TestData, int>
    {
        public Value1OrderSpecification(Order direction = Order.Ascending) 
            : base(direction) { }

        public override Expression<Func<TestData, int>> AsExpression()
        {
            return entity => entity.Value1;
        }
    }
}
