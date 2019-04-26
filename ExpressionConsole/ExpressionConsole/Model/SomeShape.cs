namespace ExpressionConsole.Model
{
    public class SomeShape
    {
        private readonly int _perimetr;
        private readonly int _area;

        public SomeShape(int perimetr, int area, Shapes name)
        {
            Name = name;
            _perimetr = perimetr;
            _area = area;
        }

        public int Perimetr => _perimetr;
        public int Area => _area;
        public Shapes Name { get; }

        public override string ToString()
        {
            return $"{Name} P: {_perimetr}, A: {_area}";
        }
    }
}