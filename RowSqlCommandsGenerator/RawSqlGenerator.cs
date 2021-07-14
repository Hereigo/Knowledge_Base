using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RawSqlCommandsGenerator
{
    public class RawSqlGenerator
    {
        public string InsertIntoTableNameByEntity<T>(T entity)
        {
            var resultFirst = $" INSERT INTO [{entity.GetType().Name}] (";
            var resultSecond = ") VALUES (";

            var _attrDict = new Dictionary<string, string>();

            var properties = entity.GetType().GetProperties();

            foreach (var property in properties)
            {
                foreach (var attr in property.GetCustomAttributes(true))
                {
                    if (attr is ColumnAttribute authAttr)
                    {
                        var propName = property.Name;
                        var auth = authAttr.Name;

                        _attrDict.Add(propName, auth);
                    }
                }
            }

            foreach (var property in properties)
            {
                resultFirst += _attrDict.ContainsKey(property.Name)
                    ? $" {_attrDict[property.Name]},"
                    : $" {property.Name},";

                resultSecond += property.PropertyType.Equals(typeof(string))
                    ? $" '{property.GetValue(entity, null)}',"
                    : $" {property.GetValue(entity, null)},";
            }

            return $"{resultFirst.TrimEnd(',')} {resultSecond.TrimEnd(',')} ); ";
        }
    }
}
