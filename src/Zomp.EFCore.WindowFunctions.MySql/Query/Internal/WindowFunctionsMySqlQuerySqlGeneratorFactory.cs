using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionVisitors.Internal;

namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// Factory for generating <see cref="WindowFunctionsMySqlQuerySqlGenerator"/>.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Multiple versions")]
public class WindowFunctionsMySqlQuerySqlGeneratorFactory : MySqlQuerySqlGeneratorFactory
{
    private readonly QuerySqlGeneratorDependencies dependencies;
    private readonly IRelationalTypeMappingSource relationalTypeMappingSource;
    private readonly IMySqlOptions mySqlOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlQuerySqlGeneratorFactory"/> class.
    /// </summary>
    /// <param name="dependencies">Service dependencies.</param>
    /// <param name="relationalTypeMappingSource">Instance relational type mapping source.</param>
    /// <param name="mySqlOptions">Options for MySql.</param>
    public WindowFunctionsMySqlQuerySqlGeneratorFactory(QuerySqlGeneratorDependencies dependencies, IRelationalTypeMappingSource relationalTypeMappingSource, IMySqlOptions mySqlOptions)
        : base(dependencies, relationalTypeMappingSource, mySqlOptions)
    {
        this.dependencies = dependencies;
        this.relationalTypeMappingSource = relationalTypeMappingSource;
        this.mySqlOptions = mySqlOptions;
    }

    /// <inheritdoc/>
    public override QuerySqlGenerator Create()
        => new WindowFunctionsMySqlQuerySqlGenerator(dependencies, relationalTypeMappingSource, mySqlOptions);
}
