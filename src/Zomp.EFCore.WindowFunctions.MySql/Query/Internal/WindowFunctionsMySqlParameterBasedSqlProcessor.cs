namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// A class that processes the <see cref="SelectExpression" /> including  window functions.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="WindowFunctionsMySqlParameterBasedSqlProcessor"/> class.
/// </remarks>
public class WindowFunctionsMySqlParameterBasedSqlProcessor : MySqlParameterBasedSqlProcessor
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlParameterBasedSqlProcessor"/> class.
    /// </summary>
    /// <param name="dependencies">Service dependencies.</param>
    /// <param name="parameters">Processor parameters.</param>
    /// <param name="options">MySql Options.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "EF Core 8")]
    public WindowFunctionsMySqlParameterBasedSqlProcessor(RelationalParameterBasedSqlProcessorDependencies dependencies, RelationalParameterBasedSqlProcessorParameters parameters, IMySqlOptions options)
        : base(dependencies, parameters, options)
    {
    }

    /// <inheritdoc/>
    protected override Expression ProcessSqlNullability(Expression selectExpression, ParametersCacheDecorator parametersDecorator)
        => new WindowFunctionsMySqlSqlNullabilityProcessor(Dependencies, Parameters)
        .Process(selectExpression, parametersDecorator);
}
