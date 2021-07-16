using System.ComponentModel.DataAnnotations.Schema;

namespace RawSqlCommandsGenerator
{
    public class RawSqlGenerator
    {
        public string InsertIntoTableNameByEntity<T>(T entity)
        {
            var resultFirst = $" INSERT INTO [{entity.GetType().Name}] (";
            var resultSecond = ") VALUES (";

            foreach (var property in entity.GetType().GetProperties())
            {
                var columnAttribute = System.Array.Find(property.GetCustomAttributes(true), a => a is ColumnAttribute);

                resultFirst += columnAttribute != null
                    ? $" {((ColumnAttribute)columnAttribute).Name},"
                    : $" {property.Name},";

                resultSecond += property.PropertyType.Equals(typeof(string))
                    ? $" '{property.GetValue(entity, null)}',"
                    : $" {property.GetValue(entity, null)},";
            }

            return $"{resultFirst.TrimEnd(',')} {resultSecond.TrimEnd(',')} ); ";
        }
    }
}
