namespace Capibara.Enterprise.Core.API.Util.Interfaces;

/// <summary>
///     Simple mapper interface safe cast dapper to c# object vice-versa
/// </summary>
/// <typeparam name="T">Typeof c# class to cast to/from</typeparam>
public interface ISqlSerializer<T>
{
    /// <summary>
    ///     Cast dynamic dapper row result to c# object
    /// </summary>
    /// <param name="row">Dapper query result</param>
    /// <returns>T object</returns>
    /// <exception cref="ArgumentException">Row must be dapper row result</exception>
    public T? FromDapperDynamicRow(dynamic? row)
    {
        if (row is not IEnumerable<KeyValuePair<string, object>> enumerable)
            throw new ArgumentException("invalid type argument", nameof(row));

        var dictionary = new Dictionary<string, object>();
        using var enumerator = enumerable.GetEnumerator();
        while (enumerator.MoveNext()) dictionary.Add(enumerator.Current.Key, enumerator.Current.Value);

        return (T?)FromDictionary(dictionary);
    }

    public T? FromDictionary(IDictionary<string, object> row);

    /// <summary>
    ///     Cast objet as dapper sql params
    /// </summary>
    /// <param name="value">Objet to be casted</param>
    /// <returns>Params object</returns>
    public object ToAnonymousObject(T value);
}