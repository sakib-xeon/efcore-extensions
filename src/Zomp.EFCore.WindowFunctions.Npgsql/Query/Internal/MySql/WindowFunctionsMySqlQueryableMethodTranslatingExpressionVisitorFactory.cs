using Pomelo.EntityFrameworkCore.MySql.Infrastructure.Internal;
using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// The WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory.
/// </summary>
public class WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory : MySqlQueryableMethodTranslatingExpressionVisitorFactory
{
    private readonly QueryableMethodTranslatingExpressionVisitorDependencies dependencies;
    private readonly RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies;
#if !EF_CORE_8
    private readonly IMySqlOptions mySqlOptions;
#endif

#if !EF_CORE_8
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory"/> class.
    /// </summary>
    /// <param name="dependencies">Type mapping source dependencies.</param>
    /// <param name="relationalDependencies">Relational type mapping source dependencies.</param>
    /// <param name="mySqlSingletonOptions">MySql Singleton Options.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "EF Core 8")]
    public WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory(
        QueryableMethodTranslatingExpressionVisitorDependencies dependencies,
        RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies,
        IMySqlOptions mySqlSingletonOptions)
        : base(dependencies, relationalDependencies, mySqlSingletonOptions)
    {
        this.dependencies = dependencies;
        this.relationalDependencies = relationalDependencies;
        this.mySqlOptions = mySqlSingletonOptions;
    }
#else
    /// <summary>
    /// Initializes a new instance of the <see cref="WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory"/> class.
    /// </summary>
    /// <param name="dependencies">Type mapping source dependencies.</param>
    /// <param name="relationalDependencies">Relational type mapping source dependencies.</param>
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "EF Core 8")]
    public WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitorFactory(QueryableMethodTranslatingExpressionVisitorDependencies dependencies, RelationalQueryableMethodTranslatingExpressionVisitorDependencies relationalDependencies)
        : base(dependencies, relationalDependencies)
    {
        this.dependencies = dependencies;
        this.relationalDependencies = relationalDependencies;
    }
#endif

#if !EF_CORE_8
    /// <inheritdoc/>
    public override QueryableMethodTranslatingExpressionVisitor Create(QueryCompilationContext queryCompilationContext)
        => new WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitor(dependencies, relationalDependencies, (RelationalQueryCompilationContext)queryCompilationContext, mySqlOptions);
#else
    /// <inheritdoc/>
    public override QueryableMethodTranslatingExpressionVisitor Create(QueryCompilationContext queryCompilationContext)
        => new WindowFunctionsMySqlQueryableMethodTranslatingExpressionVisitor(dependencies, relationalDependencies, queryCompilationContext);
#endif
}