using FilterLogic.Entities;

namespace FilterLogic.Interfaces
{
    public interface IExpressionFormer
    {
        IExpressionFormer ExpressionFormer { get; set; }

        void Configure(IFilters predictionExpression, Prediction prediction);

    }
}