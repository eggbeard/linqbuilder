﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace LinqBuilder
{
    public class Specification<TEntity> : SpecificationQuery<TEntity, bool>, ISpecification<TEntity> 
        where TEntity : class
    {
        public Specification() : this(entity => true) { }

        public Specification(Expression<Func<TEntity, bool>> expression) : base(expression) { }

        public static ISpecification<TEntity> New()
        {
            return new Specification<TEntity>();
        }

        public static ISpecification<TEntity> New(Expression<Func<TEntity, bool>> expression)
        {
            return new Specification<TEntity>(expression);
        }

        public ISpecification<TEntity> AsInterface()
        {
            return this;
        }

        public ISpecification<TEntity> And(ISpecification<TEntity> specification)
        {
            return new AndSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Or(ISpecification<TEntity> specification)
        {
            return new OrSpecification<TEntity>(this, specification);
        }

        public ISpecification<TEntity> Not()
        {
            return new NotSpecification<TEntity>(this);
        }

        public bool IsSatisfiedBy(TEntity entity)
        {
            var predicate = AsFunc();
            return predicate(entity);
        }

        public override IQueryable<TEntity> Invoke(IQueryable<TEntity> query)
        {
            return query.Where(AsExpression());
        }

        public override IEnumerable<TEntity> Invoke(IEnumerable<TEntity> collection)
        {
            return collection.Where(AsFunc());
        }
    }
}
