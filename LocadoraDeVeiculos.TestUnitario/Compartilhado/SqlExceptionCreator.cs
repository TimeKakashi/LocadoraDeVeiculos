﻿using System.Data.SqlClient;
using System.Reflection;

namespace LocadoraDeVeiculos.TestUnitario.Compartilhado
{
    internal class SqlExceptionCreator
    {
        public static T Construct<T>(params object[] p)
        {
            var ctors = typeof(T).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance);
            return (T)ctors.First(ctor => ctor.GetParameters().Length == p.Length).Invoke(p);
        }

        internal static SqlException NewSqlException(int number = 1, string errorMessage = "Error Message")
        {
            SqlErrorCollection collection = Construct<SqlErrorCollection>();
            SqlError error = Construct<SqlError>(number, (byte)2, (byte)3, "server name", errorMessage, "proc", 100, null);

            typeof(SqlErrorCollection)
                .GetMethod("Add", BindingFlags.NonPublic | BindingFlags.Instance)
                .Invoke(collection, new object[] { error });

            return typeof(SqlException)
                .GetMethod("CreateException", BindingFlags.NonPublic | BindingFlags.Static, null,
                    CallingConventions.ExplicitThis, new[] { typeof(SqlErrorCollection), typeof(string) },
                    new ParameterModifier[] { })
                .Invoke(null, new object[] { collection, "7.0.0" }) as SqlException;
        }
    }
}