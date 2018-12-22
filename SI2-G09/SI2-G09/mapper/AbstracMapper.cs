﻿/*
*  ISEL-ADEETC-SI2
*   ND 2014-2017
*
*   Material didático para apoio 
*   à unidade curricular de 
*   Sistemas de Informação II
*
*   O código pode não ser completo.
*/
using System;
using System.Collections.Generic;
using System.Data;
using DAL.mapper.interfaces;

namespace DAL.mapper
{
    #region ExtensionMethods
    public static class CollectionExtensions
    {
        public static void AddRange(this IDataParameterCollection collection, IEnumerable<IDataParameter> newItems)
        {
            foreach (IDataParameter item in newItems)
            {
                collection.Add(item);
            }
        }
    }
    #endregion
    abstract class AbstracMapper<T, Tid, TCol> : IMapper<T, Tid, TCol> where T : class, new() where TCol : IList<T>, IEnumerable<T>, new()
    {
        protected IContext context;
        #region Abstract Methods
        protected abstract T Map(IDataRecord record); //How to map entity
        protected abstract T UpdateEntityID(IDbCommand cmd, T e); //Update the generated ID
        protected abstract string SelectAllCommandText { get; }
        protected virtual CommandType SelectAllCommandType { get { return System.Data.CommandType.Text; } }
        protected virtual void SelectAllParameters(IDbCommand command) { }

        protected abstract string SelectCommandText { get; }
        protected virtual CommandType SelectCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void SelectParameters(IDbCommand command, Tid k);

        //Changed
        protected abstract string UpdateCommandText { get; }
        //protected virtual CommandType UpdateCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract CommandType UpdateCommandType { get; }
        protected abstract T UpdateParameters(T e);

        protected abstract string DeleteCommandText { get; }
        protected virtual CommandType DeleteCommandType { get { return System.Data.CommandType.Text; } }
        protected abstract void DeleteParameters(IDbCommand command, T e);

        protected abstract string InsertCommandText { get; }
        protected abstract CommandType InsertCommandType { get; }
        protected abstract T InsertParameters(T e);

        #endregion

       
        protected TCol MapAll(IDataReader reader)
        {
            TCol collection = new TCol();
            while (reader.Read())
            {
                try
                {
                    collection.Add(Map(reader));
                }
                catch
                {
                    throw;
                }

            }
            return collection;
        }

        #region Helper Methods
        protected void EnsureContext()
        {
            if (context == null)
                throw new InvalidOperationException("Data Context not set.");
        }
        protected IDataReader ExecuteReader(String commandText, List<IDataParameter> parameters)
        {
            using (IDbCommand cmd = context.createCommand())
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandText = commandText;
                return cmd.ExecuteReader(CommandBehavior.Default);
            }
        }
        protected void ExecuteNonQuery(String commandText, List<IDataParameter> parameters)
        {
            using (IDbCommand cmd = context.createCommand())
            {
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                cmd.CommandText = commandText;
                cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
            }
        }

        #endregion
        public AbstracMapper(IContext ctx)
        {
            context = ctx;
        }
        #region IMapper implementation
        public virtual T Create(T entity)
        {
            if (entity == null)
                throw new ArgumentException("The " + typeof(T) + " to update cannot be null");
            EnsureContext();
            //cmd.CommandText = InsertCommandText;
            //cmd.CommandType = InsertCommandType;
            T result;
            result = InsertParameters(entity);
            //cmd.ExecuteNonQuery();
            //cmd.Parameters.Clear();
            return result;
            
        }

        public virtual T Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentException("The " + typeof(T) + " to delete cannot be null");

            EnsureContext();

            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandText = DeleteCommandText;
                cmd.CommandType = DeleteCommandType;
                DeleteParameters(cmd, entity);
                int result = cmd.ExecuteNonQuery();
                return (result == 0) ? null : entity;
            }
        }

        public virtual T Read(Tid id)
        {
            EnsureContext();
            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandText = SelectCommandText;
                cmd.CommandType = SelectCommandType;
                SelectParameters(cmd, id);
                using (IDataReader reader = cmd.ExecuteReader())
                    return reader.Read() ? Map(reader) : null;
            }
        }

        public virtual TCol ReadAll()
        {
            EnsureContext();

            using (IDbCommand cmd = context.createCommand())
            {
                cmd.CommandText = SelectAllCommandText;
                cmd.CommandType = SelectAllCommandType;
                SelectAllParameters(cmd);
                using (IDataReader reader = cmd.ExecuteReader())
                    return MapAll(reader);
            }
        }

        public virtual T Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("The " + typeof(T) + " to update cannot be null");

            EnsureContext();

            T result;
            result = UpdateParameters(entity);
            return result;

        }
        #endregion
    }
}
