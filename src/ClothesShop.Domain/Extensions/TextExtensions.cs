using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Clothes.Domain.Extensions;

public static class TextExtensions
{
    /// <summary>
    /// Chức năng: xoá các kí tự khoảng trắng bị lặp lại (2 kí tự space -> 1 kí tự space)
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string RemoveSpaceCharacter(this string? text) =>
        string.IsNullOrEmpty(text) ? string.Empty : Regex.Replace(text.Trim(), @"\s{2,}", " ");

    /// <summary>
    /// Chức năng: xoá kí tự khoảng trắng bị lặp và viết thường tất cả
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToLowerAndRemoveSpace(this string? text) =>
        RemoveSpaceCharacter(text).ToLower();
    
    /// <summary>
    /// Chức năng: xoá kí tự khoảng trắng bị lặp và viết hoa tất cả
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string ToUpperAndRemoveSpace(this string? text) =>
        RemoveSpaceCharacter(text).ToUpper();

    /// <summary>
    /// Chức năng: loại bỏ toàn bộ kí tự khoảng trắng khỏi chuỗi
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string RemoveAllSpaceChar(this string? text) =>
        string.IsNullOrEmpty(text) ? string.Empty : Regex.Replace(text.Trim(), @"\s+", "");

    #region MySerialize

    private static JsonSerializerOptions _opt = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    };

    /// <summary>
    /// Chức năng: sử dụng Deserialize với CamelCase cho đồng bộ toàn hệ thống
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static T? MyDeserialize<T>(this string? source)
    {
        if (string.IsNullOrEmpty(source))
            return default;

        return JsonSerializer.Deserialize<T>(source, _opt);
    }

    /// <summary>
    /// Chức năng: sử dụng Serialize với CamelCase cho đồng bộ toàn hệ thống
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="source"></param>
    /// <returns></returns>
    public static string MySerialize<T>(this T source)
    {
        if (source is null)
            return string.Empty;

        return JsonSerializer.Serialize(source, _opt);
    }
    
    #endregion
}