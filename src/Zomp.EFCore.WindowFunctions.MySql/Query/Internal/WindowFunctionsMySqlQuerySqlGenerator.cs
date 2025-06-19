using Pomelo.EntityFrameworkCore.MySql.Query.ExpressionVisitors.Internal;

namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// Query SQL generator for MySql which includes window functions operations.
/// </summary>
[System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Multiple versions")]
public class WindowFunctionsMySqlQuerySqlGenerator : MySqlQuerySqlGenerator
{
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlQuerySqlGenerator"/> class.
    /// </summary>
    /// <param name="dependencies">Service dependencies.</param>
    /// <param name="relationalTypeMappingSource">Instance relational type mapping source.</param>
    /// <param name="options">MySql Options.</param>
    public WindowFunctionsMySqlQuerySqlGenerator(
        QuerySqlGeneratorDependencies dependencies,
        IRelationalTypeMappingSource relationalTypeMappingSource,
        IMySqlOptions options)
        : base(dependencies, relationalTypeMappingSource, options)
    {
    }

    /// <inheritdoc/>
    protected override Expression VisitExtension(Expression extensionExpression)
        => extensionExpression switch
        {
            WindowFunctionExpression windowFunctionExpression => this.VisitWindowFunction(windowFunctionExpression),
            _ => base.VisitExtension(extensionExpression),
        };
}