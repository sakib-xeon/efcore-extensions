using Pomelo.EntityFrameworkCore.MySql.Query.Internal;

namespace Zomp.EFCore.WindowFunctions.MySql.Query.Internal;

/// <summary>
/// Evaluatable expression filter for MySql.
/// </summary>
/// <param name="dependencies">Service dependencies.</param>
/// <param name="relationalDependencies">Relational service dependencies.</param>
/// <param name="mySqlEvaluatableExpressionFilters">MySql Evaluatable Expression Filters.</param>
public class WindowFunctionsMySqlEvaluatableExpressionFilter(
    EvaluatableExpressionFilterDependencies dependencies,
    RelationalEvaluatableExpressionFilterDependencies relationalDependencies,
    IEnumerable<IMySqlEvaluatableExpressionFilter> mySqlEvaluatableExpressionFilters) : MySqlEvaluatableExpressionFilter(dependencies, relationalDependencies, mySqlEvaluatableExpressionFilters)
{
    /// <inheritdoc/>
    public override bool IsEvaluatableExpression(Expression expression, IModel model)
        => WindowFunctionsEvaluatableExpressionFilter.IsEvaluatableExpression(expression)
        && base.IsEvaluatableExpression(expression, model);
}
