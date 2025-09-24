namespace Mailtrap.ContactFields.Models;

/// <summary>
/// Contact field data type.
/// </summary>
public sealed record ContactFieldDataType : StringEnum<ContactFieldDataType>
{
    /// <summary>
    /// Gets the value representing "text" contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "text" contact field data type.
    /// </value>
    public static readonly ContactFieldDataType Text = Define("text");

    /// <summary>
    /// Gets the value representing "integer" contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "integer" contact field data type.
    /// </value>
    public static readonly ContactFieldDataType Number = Define("integer");

    /// <summary>
    /// Gets the value representing "float" contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "float" contact field data type.
    /// </value>
    public static readonly ContactFieldDataType FloatValue = Define("float");

    /// <summary>
    /// Gets the value representing "boolean" contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "boolean" contact field data type.
    /// </value>
    public static readonly ContactFieldDataType Boolean = Define("boolean");

    /// <summary>
    /// Gets the value representing "date" contact field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "date" contact field data type.
    /// </value>
    public static readonly ContactFieldDataType Date = Define("date");
}
