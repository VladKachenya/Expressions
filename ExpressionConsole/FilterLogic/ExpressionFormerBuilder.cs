using System.Collections.Generic;
using System.Linq;
using FilterLogic.ExpressionFormers;
using FilterLogic.Interfaces;

namespace FilterLogic
{
    public class ExpressionFormerBuilder
    {
        List<IExpressionFormer> _formers = new List<IExpressionFormer>();

        public ExpressionFormerBuilder()
        {
            _formers.Add(new IntExpressionFormer());
            _formers.Add(new DataTimeExpressionFormer());
        }

        public IExpressionFormer GetExpressionFormer()
        {
            IExpressionFormer previous = null;
            foreach (var former in _formers)
            {
                if (previous != null) previous.ExpressionFormer = former;
                previous = former;
            }
            return _formers.First();
        }
    }
}