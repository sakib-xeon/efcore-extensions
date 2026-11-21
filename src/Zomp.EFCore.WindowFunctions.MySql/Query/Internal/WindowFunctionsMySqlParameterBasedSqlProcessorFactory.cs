namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// Factory for producing <see cref="WindowFunctionsMySqlParameterBasedSqlProcessor"/> instances.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="WindowFunctionsMySqlParameterBasedSqlProcessorFactory"/> class.
/// </remarks>
public class WindowFunctionsMySqlParameterBasedSqlProcessorFactory : MySqlParameterBasedSqlProcessorFactory
{
    private readonly RelationalParameterBasedSqlProcessorDependencies dependencies;
    private readonly IMySqlOptions options;

#if !EF_CORE_8
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlParameterBasedSqlProcessorFactory"/> class.
    /// </summary>
    /// <param name="dependencies">Relational Parameter Based Sql ProcessorDependencies.</param>
    /// <param name="options">MySql Options.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "EF Core 8")]
    public WindowFunctionsMySqlParameterBasedSqlProcessorFactory(RelationalParameterBasedSqlProcessorDependencies dependencies, IMySqlOptions options)
        : base(dependencies, options)
    {
        this.dependencies = dependencies;
        this.options = options;
    }
#else
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlParameterBasedSqlProcessorFactory"/> class.
    /// </summary>
    /// <param name="dependencies">Relational Parameter Based Sql ProcessorDependencies.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "EF Core 8")]
    public WindowFunctionsMySqlParameterBasedSqlProcessorFactory(RelationalParameterBasedSqlProcessorDependencies dependencies)
        : base(dependencies)
    {
        this.dependencies = dependencies;
    }
#endif

#if !EF_CORE_8
    /// <inheritdoc/>
    public override RelationalParameterBasedSqlProcessor Create(RelationalParameterBasedSqlProcessorParameters parameters)
        => new WindowFunctionsMySqlParameterBasedSqlProcessor(dependencies, parameters, options);
#else
    /// <inheritdoc/>
    public override RelationalParameterBasedSqlProcessor Create(bool useRelationalNulls)
        => new WindowFunctionsMySqlParameterBasedSqlProcessor(dependencies, useRelationalNulls);
#endif
}