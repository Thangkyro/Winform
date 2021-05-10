using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
//using Asiasoft.Framework.Types;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace CoreBase.Helpers
{
    public static class ObjectLibrary
    {
        /// <summary>
        /// Dùng để Serialize 1 đối tượng thành byte[] để lưu vào binary field trong sql server
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng bất kỳ</typeparam>
        /// <param name="obj">Đối tượng được truyền vào</param>
        /// <returns>Byte[] để lưu vào binary field</returns>
        public static byte[] SerializeObject<T>(T obj)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryFormatter binFormatter = new BinaryFormatter();
            binFormatter.Serialize(memStream, obj);
            byte[] bytes = memStream.ToArray();
            memStream.Close();
            return bytes;
        }
        /// <summary>
        /// Dùng để Deserialize 1 byte[] thành 1 đối tượng 
        /// </summary>
        /// <typeparam name="T">Kiểu đối tượng bất kỳ</typeparam>
        /// <param name="bytes">byte[] dữ liệu được serialize</param>
        /// <returns>1 đối tượng</returns>
        public static T DeserializeObject<T>(byte[] bytes)
        {
            MemoryStream memStream = new MemoryStream();
            BinaryWriter binWriter = new BinaryWriter(memStream);
            BinaryFormatter binFormatter = new BinaryFormatter();

            binWriter.Write(bytes, 0, bytes.Length);
            memStream.Seek(0, SeekOrigin.Begin);
            T obj = (T)binFormatter.Deserialize(memStream);
            return obj;
        }

        //public static string CreateFilterText(string filterField, string filterValue,
        //    FilterOperators filterOperator)
        //{
        //    string filterSeparated = AsList<object>.filterSeperated;
        //    return filterField.Trim() + filterSeparated + ((int)filterOperator).ToString() +
        //        filterSeparated + filterValue.Trim();
        //}

        public static T CreateInstance<T>(IDataReader reader) where T:new()
        {
            T result = new T();
            object objValue = new object();
            DataColumnCollection dataColumns = reader.GetSchemaTable().Columns;
            Type type = typeof(T);

            foreach (PropertyInfo pi in type.GetProperties())
            {
                string propertyName = pi.Name.Trim();
                string propertyType = pi.PropertyType.FullName.Trim();
                int ordinal = GetOrdinalOfColumn(reader, propertyName);


                if (ordinal >=0 )
                {   
                    switch (propertyType)
                    {
                        case "System.Boolean":
                            objValue = reader.GetBoolean(ordinal);
                            break;
                        case "System.Byte":
                            objValue = reader.GetByte(ordinal);
                            break;
                        case "System.Char":
                            objValue = reader.GetChar(ordinal);
                            break;                        
                        case "System.DateTime":
                            objValue = reader.GetDateTime(ordinal);
                            break;
                        case "System.Decimal":
                            objValue = reader.GetDecimal(ordinal);
                            break;
                        case "System.Double":
                            objValue = reader.GetDouble(ordinal);
                            break;
                        case "System.Guid":
                            objValue = reader.GetGuid(ordinal);
                            break;
                        case "System.Int16":
                            objValue = reader.GetInt16(ordinal);
                            break;
                        case "System.Int32":
                            objValue = reader.GetInt32(ordinal);
                            break;
                        case "System.Int64":
                            objValue = reader.GetInt64(ordinal);
                            break;
                        case "System.String":
                            objValue = reader.GetString(ordinal).Trim();
                            break;
                            
                    }

                    pi.SetValue(result, objValue,null);
                }
            }

            return result;
            
        }

        public static ArrayList CreateArrayList<T>(IDataReader reader) where T : new()
        {
            ArrayList arr = new ArrayList();

            while (reader.Read())
            {
                T obj = ObjectLibrary.CreateInstance<T>(reader);
                arr.Add(obj);
            }
            if (reader != null)
            {
                reader.Close();
            }
            return arr;
        }

        //public static AsList<T> CreateAsList<T>(IDataReader reader) where T : new()
        //{
        //    AsList<T> list = new AsList<T>();
        //    while (reader.Read())
        //    {
        //        T obj = ObjectLibrary.CreateInstance<T>(reader);
        //        list.Add(obj);
        //    }
        //    if (reader != null)
        //    {
        //        reader.Close();
        //    }
        //    return list;
        //}

        private static int GetOrdinalOfColumn(IDataReader reader, string columnName)
        {
            try
            {
                return reader.GetOrdinal(columnName);
            }
            catch(IndexOutOfRangeException)
            {
                return -1;
            }
        }

        /// <summary>
        /// Convert từ list sang aslist
        /// </summary>
        /// <typeparam name="T">kiểu dữ liệu item trong list được convert</typeparam>
        /// <param name="list"></param>
        /// <returns>aslist</returns>
        //public static AsList<T> ConvertFromListToAslist<T>(List<T> list)
        //{
        //    AsList<T> asList = null;

        //    if (list != null)
        //    {
        //        asList = new AsList<T>();
        //        foreach (T obj in list.ToList())
        //            asList.Add(obj);
        //    }
        //    return asList;
        //}

        /// <summary>
        /// Gọi động hàm non static dạng generic và không generic 
        /// </summary>
        /// <param name="type">Kiểu dữ liệu của generic , null nếu không generic</param>
        /// <param name="methodName">Tên hàm </param>
        /// <param name="target">Đối tượng chứa hàm</param>
        /// <param name="args">Các tham số </param>
        public static object DynamicInvokeNonStaticMethod(Type type, string methodName,
                           object target, params object[] args)
        {          
            try
            {
                MethodInfo method =
                    target.GetType().GetMethod(methodName,
                            BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
                if (type != null)
                    method = method.MakeGenericMethod(type);
                return method.Invoke(target, args);                
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Gọi động hàm static dạng generic và không generic 
        /// </summary>
        /// <param name="type">Kiểu dữ liệu của generic , null nếu không generic</param>
        /// <param name="methodName">Tên hàm </param>
        /// <param name="target">Đối tượng chứa hàm</param>
        /// <param name="args">Các tham số </param>
        public static object DynamicInvokeStaticMethod(Type genericType, string methodName, Type objectType,
                            params object[] args)
        {
            try
            {
                MethodInfo method =
                    objectType.GetMethod(methodName,
                            BindingFlags.NonPublic | BindingFlags.IgnoreCase | BindingFlags.Instance 
                            | BindingFlags.Public | BindingFlags.Static);
                if (genericType != null)
                    method = method.MakeGenericMethod(genericType);
                return method.Invoke(null, args);
            }
            catch
            {
                throw;
            }
        } 
    }
}
