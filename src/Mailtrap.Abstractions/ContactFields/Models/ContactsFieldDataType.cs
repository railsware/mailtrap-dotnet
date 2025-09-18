namespace Mailtrap.ContactFields.Models;

/// <summary>
/// Contact subscription status.
/// </summary>
public sealed record ContactsFieldDataType : StringEnum<ContactsFieldDataType>
{
    /// <summary>
    /// Gets the value representing "text" contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "text" contacts field data type.
    /// </value>
    public static readonly ContactsFieldDataType Text = Define("text");

    /// <summary>
    /// Gets the value representing "integer" contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "integer" contacts field data type.
    /// </value>
    public static readonly ContactsFieldDataType Number = Define("integer");

    /// <summary>
    /// Gets the value representing "float" contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "float" contacts field data type.
    /// </value>
    public static readonly ContactsFieldDataType FloatValue = Define("float");

    /// <summary>
    /// Gets the value representing "boolean" contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "boolean" contacts field data type.
    /// </value>
    public static readonly ContactsFieldDataType Boolean = Define("boolean");

    /// <summary>
    /// Gets the value representing "date" contacts field data type.
    /// </summary>
    ///
    /// <value>
    /// Represents "date" contacts field data type.
    /// </value>
    public static readonly ContactsFieldDataType Date = Define("date");
}
