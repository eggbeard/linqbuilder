﻿using System;
using System.Linq.Expressions;
using LinqBuilder.Specifications;

namespace LinqBuilder.IntegrationTests.TestHelpers
{
    public class Value1Specification : Specification<Entity>
    {
        private readonly int _value;

        public Value1Specification(int value)
        {
            _value = value;
        }

        public override Expression<Func<Entity, bool>> AsExpression()
        {
            return entity => entity.Value1 == _value;
        }
    }
}
