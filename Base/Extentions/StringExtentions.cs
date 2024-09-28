using System.Text.Json;

namespace CQRS_MinimalAPI.Base.Extentions;

public static class StringExtentions
{
    public static string ToCamelCase(this string propertyName, bool ignoreFirstSplit = true)
    {
        if (string.IsNullOrWhiteSpace(propertyName))
            return string.Empty;

        if (ignoreFirstSplit)
        {
            var indexOfSplit = propertyName.IndexOf('.');
            if (indexOfSplit > -1)
                propertyName = propertyName[(indexOfSplit + 1)..];
        }

        string convertedToCamel;

        if (!propertyName.Contains('.'))
            convertedToCamel = JsonNamingPolicy.CamelCase.ConvertName(propertyName);
        else
        {
            var fullName = from prop in propertyName.Split('.', StringSplitOptions.RemoveEmptyEntries)
                select JsonNamingPolicy.CamelCase.ConvertName(prop);

            convertedToCamel = string.Join('.', fullName);
        }

        return convertedToCamel;
    }
}