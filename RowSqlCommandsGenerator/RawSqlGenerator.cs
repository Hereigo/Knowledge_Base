namespace RawSqlCommandsGenerator
{
    public class RawSqlGenerator
    {
        public string InsertIntoTableNameByEntity<T>(T entity)
        {
            string resultFirst = $" INSERT INTO [{entity.GetType().Name}] (";
            string resultSecond = ") VALUES (";

            foreach (var property in entity.GetType().GetProperties())
            {
                resultFirst += $" {property.Name},";

                resultSecond += property.PropertyType.Equals(typeof(string))
                    ? $" '{property.GetValue(entity, null)}',"
                    : $" {property.GetValue(entity, null)},";
            }

            return $"{resultFirst.TrimEnd(',')} {resultSecond.TrimEnd(',')} ); ";
        }
    }
}
