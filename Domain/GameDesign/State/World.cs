using Domain.Interfaces;

namespace Domain.GameDesign.State
{
    public class World : ITerable<StaticElement>
    {
        private int _width;
        private int _height;
        private StaticElement[,] _elements;

        public World(int width, int height)
        {
            _width = width;
            _height = height;
            _elements = new StaticElement[width, height];

        }

        private bool CoordonatesControl(int x, int y)
        {
            bool test = true;
            if (x < 0 || x >= _width || y < 0 || y >= _height)
            {
                test = false;
            }
            return test;
        }

        public int GetWidth()
        {
            return _width;
        }

        public int GetHeight()
        {
            return _height;
        }

        public StaticElement Get(int x, int y)
        {
            return _elements[x, y];
        }

        public StaticElement Get(int x, int y, Direction d)
        {
            StaticElement e;
            switch (d)
            {
                case Direction.NONE:
                    if (!CoordonatesControl(x, y))
                    {
                        throw new ArgumentOutOfRangeException("Bad coordonates");
                    }
                    e = _elements[x, y];
                    break;
                case Direction.NORTH:
                    return Get(x, y + 1, Direction.NONE);
                case Direction.SOUTH:
                    return Get(x, y - 1, Direction.NONE);
                case Direction.EAST:
                    return Get(x + 1, y, Direction.NONE);
                case Direction.WEST:
                    return Get(x - 1, y, Direction.NONE);
                default:
                    throw new ArgumentOutOfRangeException("No direction");
            }
            return e;
        }

        public void Set(int x, int y, StaticElement e)
        {
            if (_elements == null)
            {
                throw new ArgumentNullException("No element");
            }
            if (!CoordonatesControl(x, y))
            {
                throw new ArgumentOutOfRangeException("Bad coordonates");
            }

            _elements[x, y] = e;
        }

        public ITerator<StaticElement> Iterator()
        {
            return new WorldIterator(this);
        }
    }
}
