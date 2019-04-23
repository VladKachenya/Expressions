using FilterLogic.Entities;
using FilterLogic.Interfaces;

namespace FilterLogic.ExpressionFormers
{
    public abstract class ExpressionFormerBase : IExpressionFormer
    {
        public IExpressionFormer ExpressionFormer { get; set; }
        public virtual void Configure(IFilters predictionExpression, Prediction prediction)
        {
            ExpressionFormer?.Configure(predictionExpression, prediction);
        }
    }
}