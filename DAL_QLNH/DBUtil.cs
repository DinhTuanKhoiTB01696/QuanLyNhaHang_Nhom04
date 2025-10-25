using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Data.SqlClient;


namespace DAL_QLNH
{
    public static class DBUtil
    {
        // 🔹 Chuỗi kết nối database QLNhaHang
        public static string connString = @"Data Source=KHOI\SQLEXPRESS;Initial Catalog=QLNhaHang;Integrated Security=True;Trust Server Certificate=True";

        // 🔹 Tạo SqlCommand
        //public static SqlCommand CreateCommand(string sql, Dictionary<string, object> args, CommandType cmdType, SqlConnection conn)
        //{
        //    SqlCommand cmd = new SqlCommand(sql, conn);
        //    cmd.CommandType = cmdType;

        //    if (args != null)
        //    {
        //        foreach (var param in args)
        //        {
        //            cmd.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
        //        }
        //    }

        //    return cmd;
        //}

        //// 🔹 Thực hiện INSERT/UPDATE/DELETE
        //public static int Update(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text)
        //{
        //    using (SqlConnection conn = new SqlConnection(connString))
        //    {
        //        conn.Open();
        //        using (SqlTransaction transaction = conn.BeginTransaction())
        //        using (SqlCommand cmd = CreateCommand(sql, args, cmdType, conn))
        //        {
        //            cmd.Transaction = transaction;
        //            try
        //            {
        //                int rowsAffected = cmd.ExecuteNonQuery();
        //                transaction.Commit();
        //                return rowsAffected;
        //            }
        //            catch
        //            {
        //                transaction.Rollback();
        //                throw;
        //            }
        //        }
        //    }
        //}

        //// 🔹 Truy vấn 1 giá trị duy nhất (SELECT COUNT, SELECT MAX, v.v.)
        //public static object ScalarQuery(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text)
        //{
        //    using (SqlConnection conn = new SqlConnection(connString))
        //    using (SqlCommand cmd = CreateCommand(sql, args, cmdType, conn))
        //    {
        //        conn.Open();
        //        return cmd.ExecuteScalar();
        //    }
        //}

        //// 🔹 Truy vấn nhiều dòng dữ liệu (SELECT)
        //public static DataTable Query(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text)
        //{
        //    using (SqlConnection conn = new SqlConnection(connString))
        //    using (SqlCommand cmd = CreateCommand(sql, args, cmdType, conn))
        //    {
        //        conn.Open();
        //        using (SqlDataReader reader = cmd.ExecuteReader())
        //        {
        //            DataTable dt = new DataTable();
        //            dt.Load(reader);
        //            return dt;
        //        }
        //    }
        //}

        //// 🔹 Truy vấn 1 đối tượng duy nhất
        //public static T QuerySingle<T>(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text) where T : new()
        //{
        //    DataTable dt = Query(sql, args, cmdType);
        //    if (dt.Rows.Count > 0)
        //    {
        //        return MapDataRowToT<T>(dt.Rows[0]);
        //    }
        //    return default;
        //}

        //// 🔹 Truy vấn danh sách đối tượng
        //public static List<T> QueryList<T>(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text) where T : new()
        //{
        //    DataTable dt = Query(sql, args, cmdType);
        //    List<T> resultList = new List<T>();
        //    foreach (DataRow row in dt.Rows)
        //    {
        //        resultList.Add(MapDataRowToT<T>(row));
        //    }
        //    return resultList;
        //}

        //// 🔹 Ánh xạ DataRow -> Object
        //private static T MapDataRowToT<T>(DataRow row) where T : new()
        //{
        //    T item = new T();
        //    Type type = typeof(T);

        //    foreach (DataColumn column in row.Table.Columns)
        //    {
        //        PropertyInfo property = type.GetProperty(column.ColumnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
        //        if (property != null && property.CanWrite)
        //        {
        //            object value = row[column.ColumnName];
        //            if (value == DBNull.Value)
        //            {
        //                property.SetValue(item, null);
        //            }
        //            else
        //            {
        //                try
        //                {
        //                    Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
        //                    property.SetValue(item, Convert.ChangeType(value, targetType));
        //                }
        //                catch
        //                {
        //                    // Có thể log lỗi nếu cần
        //                }
        //            }
        //        }
        //    }

        //    return item;
        //}

        //// 🔹 Alias gọn
        //public static List<T> Select<T>(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text) where T : new()
        //    => QueryList<T>(sql, args, cmdType);

        //public static T SelectOne<T>(string sql, Dictionary<string, object> args, CommandType cmdType = CommandType.Text) where T : new()
        //    => QuerySingle<T>(sql, args, cmdType);
    }
}
