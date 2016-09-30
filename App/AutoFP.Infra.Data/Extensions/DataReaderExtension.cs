using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;

namespace AutoFP.Infra.Data.Extensions
{
    public static class DataReaderExtension
    {
        public static List<T> DataReaderMapToList<T>(this IDataReader reader)
        {
            var list = new List<T>();
            T obj = default(T);

            while (reader.Read())
            {
                obj = Activator.CreateInstance<T>();

                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    if (prop.PropertyType.Namespace == obj.GetType().Namespace)
                    {
                        var subObj = Activator.CreateInstance(prop.GetMethod.ReturnType);
                        var instancied = false;

                        foreach (PropertyInfo subProp in subObj.GetType().GetProperties())
                        {
                            string subPropName = prop.Name + "." + subProp.Name;

                            if (reader.HasColumn(subPropName) && prop.GetValue(obj) == null)
                                instancied = true;

                            if (reader.HasColumn(subPropName) && !Equals(reader[subPropName], DBNull.Value))
                                subProp.SetValue(subObj, reader[subPropName], null);
                        }

                        if (instancied)
                            prop.SetValue(obj, subObj, null);
                    }

                    if (reader.HasColumn(prop.Name) && !Equals(reader[prop.Name], DBNull.Value))
                    {
                        var eenum = Nullable.GetUnderlyingType(prop.PropertyType);
                        if (eenum != null && eenum.IsEnum)
                        {
                            prop.SetValue(obj, Enum.ToObject(Nullable.GetUnderlyingType(prop.PropertyType), reader[prop.Name]), null);
                            continue;
                        }

                        prop.SetValue(obj, reader[prop.Name], null);
                    }
                } // Final - foreach

                list.Add(obj);
            } // Final - while

            return list;
        } // Final - method

        public static bool HasColumn(this IDataReader reader, string columnName)
        {
            foreach (DataRow row in reader.GetSchemaTable().Rows)
                if (row["ColumnName"].ToString() == columnName)
                    return true;

            return false;
        }
    }
}