namespace ExpressionConsole.Model
{
    public class SomeShape
    {

        public SomeShape(int perimetr, int area, Shapes name)
        {
            Name = name;
            Perimetr = perimetr;
            Area = area;
        }

        public int Perimetr { get; }
        public int Area {get;}
        public Shapes Name { get; }

        public override string ToString()
        {
            return $"{Name} P: {Perimetr}, A: {Area}";
        }
    }
}