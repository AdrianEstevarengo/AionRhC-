using System;
using System.Collections.Concurrent;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Infra.CrossCutting.Helpers
{
    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<Enum, string> DisplayNameCache = new();

        public static string ToStringRepresentation<T>(this T enumValue)
            where T : Enum
        {
            return enumValue.ToString();
        }

        public static T ToEnumValue<T>(this string stringValue)
            where T : Enum
        {
            if (string.IsNullOrWhiteSpace(stringValue))
            {
                throw new ArgumentException(
                    "String value cannot be null or whitespace.",
                    nameof(stringValue)
                );
            }

            if (
                Enum.TryParse(typeof(T), stringValue, true, out var result)
                && result is T enumResult
            )
            {
                return enumResult;
            }
            throw new ArgumentException(
                $"'{stringValue}' is not a valid value for enum {typeof(T).Name}."
            );
        }

        public static string GetDisplayName<T>(this T? enumValue)
            where T : struct, Enum
        {
            ArgumentNullException.ThrowIfNull(enumValue, nameof(enumValue));
            return GetDisplayName(enumValue.Value);
        }

        public static string GetDisplayName<T>(this T enumValue)
            where T : Enum
        {
            return DisplayNameCache.GetOrAdd(
                enumValue,
                value =>
                {
                    var fieldInfo = value.GetType().GetField(value.ToString());
                    var displayAttribute = fieldInfo
                        ?.GetCustomAttributes(typeof(DisplayAttribute), false)
                        .Cast<DisplayAttribute>()
                        .FirstOrDefault();
                    return displayAttribute?.Name ?? value.ToString();
                }
            );
        }
    }
}