﻿using System;
using System.Data;
using System.Data.Common;

namespace Common.DataBase
{
    public static partial class SqlHelper
    {
        /// <summary>
        /// 针对 .NET Framework 数据提供程序的 Connection 对象执行 SQL 语句，并返回受影响的行数。
        /// </summary>
        /// <param name="sql">sql 语句。</param>
        /// <param name="parameters">sql 参数。</param>
        /// <returns>受影响的行数。</returns>
        public static int ExecuteNonQuery(string sql, params DbParameter[] parameters)
        {
            using (IDbConnection conn = Activator.CreateInstance(DbProvider) as IDbConnection)
            {
                conn.ConnectionString = ConnectionString;
                conn.Open();
                using (IDbCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    foreach (DbParameter parameter in parameters)
                    {
                        cmd.Parameters.Add(parameter);
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
