﻿using Doubi.Core.Domain;
using Doubi.Core.MyEventArgs;
using Doubi.Core.PagedList;
using FluentData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doubi.Data.DAL
{
    public partial class ProductSupplierRepository<T> : IRepository<T> where T : ProductSupplier
    {
        public delegate void EntityEventHandler(object sender, EntityEventArgs<T> e);

        public event EntityEventHandler OnLoaded;

        protected virtual void _onLoaded(EntityEventArgs<T> e)
        {
            if (OnLoaded != null)
                OnLoaded(this, e);
        }

        public event EntityEventHandler OnInserting;

        protected virtual void _onInserting(EntityEventArgs<T> e)
        {
            if (OnInserting != null)
                OnInserting(this, e);
        }

        public event EntityEventHandler OnUpdating;

        protected virtual void _onUpdating(EntityEventArgs<T> e)
        {
            if (OnUpdating != null)
                OnUpdating(this, e);
        }
        private IDbContext Context()
        {
            return new DbContext().ConnectionStringName(DBSettings.ConnectionStringName,
                    new SqlServerProvider());
        }

        public T GetById(int id)
        {
            using (var context = Context())
            {
                T entity = context.Sql(@"select * from product_supplier where id=@id").Parameter("id", id).QuerySingle<T>();
                return entity;
            }
        }


      public bool Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            using (var context = Context())
            {
                int id = context.Insert("product_supplier")
                        .Column("productid",entity.Productid)
                        .Column("supplier_name",entity.Supplier_name)
                        .Column("supplier_price",entity.Supplier_price)
                        .Column("map_productcode",entity.Map_productcode)
                        .Column("supplier_inventory",entity.Supplier_inventory)
                        .Column("supplier_code",entity.Supplier_code)
                        .Column("suppliertype",entity.Suppliertype)
                        .ExecuteReturnLastId<int>();

                entity.Id = id;
                return id > 0;
            }
        }

        private void Insert(T entity, IDbContext context)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            int id = context.Insert("product_supplier")
                        .Column("productid",entity.Productid)
                        .Column("supplier_name",entity.Supplier_name)
                        .Column("supplier_price",entity.Supplier_price)
                        .Column("map_productcode",entity.Map_productcode)
                        .Column("supplier_inventory",entity.Supplier_inventory)
                        .Column("supplier_code",entity.Supplier_code)
                        .Column("suppliertype",entity.Suppliertype)
                    .ExecuteReturnLastId<int>();

            entity.Id = id;
        }

        public void InsertWithTransaction(T entity, IDbContext context)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (context == null)
                throw new ArgumentNullException("entity");

            int id = context.Insert("product_supplier")
                        .Column("productid",entity.Productid)
                        .Column("supplier_name",entity.Supplier_name)
                        .Column("supplier_price",entity.Supplier_price)
                        .Column("map_productcode",entity.Map_productcode)
                        .Column("supplier_inventory",entity.Supplier_inventory)
                        .Column("supplier_code",entity.Supplier_code)
                        .Column("suppliertype",entity.Suppliertype)
                    .ExecuteReturnLastId<int>();

            entity.Id = id;
        }

        public void InsertRange(IEnumerable<T> entities, int batchSize = 100)
        {
            if (entities == null)
                throw new ArgumentNullException("entities");

            if (batchSize <= 0)
            {
                using (var context = Context())
                {
                    foreach (T entity in entities)
                    {
                        Insert(entity, context);
                    }
                }
            }
            else
            {
                int i = 1;
                List<T> tempEntities = new List<T>();
                foreach (var entity in entities)
                {
                    if (i % batchSize == 0)
                    {
                        InsertRange(tempEntities, 0);
                        tempEntities.Clear();
                        i = 0;
                    }
                    else
                    {
                        tempEntities.Add(entity);
                    }
                    i++;
                }
            }
        }

        public bool Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            using (var context = Context())
            {
                return context.Update("product_supplier")
                        .Column("productid",entity.Productid)
                        .Column("supplier_name",entity.Supplier_name)
                        .Column("supplier_price",entity.Supplier_price)
                        .Column("map_productcode",entity.Map_productcode)
                        .Column("supplier_inventory",entity.Supplier_inventory)
                        .Column("supplier_code",entity.Supplier_code)
                        .Column("suppliertype",entity.Suppliertype)
                    .Where("Id",entity.Id)
                    .Execute() > 0;
            }
        }

        public void UpdateWithTransaction(T entity, IDbContext context)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            if (context == null)
                throw new ArgumentNullException("entity");

            context.Update("product_supplier")
                        .Column("productid",entity.Productid)
                        .Column("supplier_name",entity.Supplier_name)
                        .Column("supplier_price",entity.Supplier_price)
                        .Column("map_productcode",entity.Map_productcode)
                        .Column("supplier_inventory",entity.Supplier_inventory)
                        .Column("supplier_code",entity.Supplier_code)
                        .Column("suppliertype",entity.Suppliertype)
                     .Where("Id",entity.Id)
                     .Execute();
        }

        public bool Delete(T entity)
        {
            if (entity == null || entity.Id <= 0)
                throw new ArgumentNullException("entity");

            using (var context = Context())
            {
                return context.Sql(" DELETE FROM product_supplier WHERE id = @id ")
                    .Parameter("id", entity.Id)
                    .Execute() > 0;
            }
        }
        
         public bool Delete(int id)
         {
            if (id <= 0)
            {
                throw new ArgumentNullException("id error");
            }
            using (var context = Context())
            {
                return context.Sql(" DELETE FROM product_supplier WHERE id = @id ")
                    .Parameter("id", id)
                    .Execute() > 0;
            }
         }

        public List<T> SelectAll()
        {
            return SelectAll(string.Empty);
        }

        public List<T> SelectAll(string sortExpression)
        {
            return SelectAll(0, 0, sortExpression);
        }

        public List<T> SelectAll(int pageIndex, int maximumRows, string sortExpression)
        {            
            using (var context = Context())
            {
                var select = context.Select<T>(" * ")
                        .From(" product_supplier ");

                if (maximumRows > 0)
                {
                    if (pageIndex <= 0)
                        pageIndex=1;

                    select.Paging(pageIndex, maximumRows);
                }

                if (!string.IsNullOrEmpty(sortExpression))
                    select.OrderBy(sortExpression);
                else
                    select.OrderBy("Id");
                return select.QueryMany();
            }
        }
        
        public int CountByField(string fieldname, object fieldvalue)
        {
            using (var context = Context())
            {               
                return context.Sql(" SELECT COUNT(*) FROM product_supplier where " + fieldname + " = @" + fieldname)
                              .Parameter(fieldname, fieldvalue)
                              .QuerySingle<int>();
            }
        }
        
        public List<T> SelectByField(string fieldname, object fieldvalue)
        {
            return SelectByField(fieldname, fieldvalue, string.Empty);
        }
        
         public List<T> SelectByField(string fieldname, object fieldvalue,string sortExpression)
        {
            return SelectByField(fieldname, fieldvalue, 0, 0, sortExpression);
        }
        

        public List<T> SelectByField(string fieldname, object fieldvalue, int pageIndex, int maximumRows, string sortExpression)
        {            
            List<T> result = null;
            using (var context = Context())
            {
                var select = context.Select<T>(" * ")
                        .From("product_supplier")
                        .Where(" " + fieldname + " = @" + fieldname + " ")
                        .Parameter(fieldname, fieldvalue);

                if (maximumRows > 0)
                {
                    if (pageIndex <= 0)
                        pageIndex=1;

                    select.Paging(pageIndex, maximumRows);
                }

                if (!string.IsNullOrEmpty(sortExpression))
                    select.OrderBy(sortExpression);
                else
                    select.OrderBy("Id");
                result = select.QueryMany();
            }

            if (maximumRows > 0)
            {
                return new PagedList<T>(result, pageIndex, maximumRows, CountByField(fieldname, fieldvalue));
            }
            else
            {
                return result;
            }
        }
    }
}




