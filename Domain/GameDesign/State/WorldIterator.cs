using Domain.Interfaces;

namespace Domain.GameDesign.State
{
    public class WorldIterator : ITerator<StaticElement>
    {
        private int _x;
        private int _y;
        private World _world;

        public WorldIterator(World world)
        {
            _world = world;
            _x = -1;
            _y = 0;
        }

        public bool HasNext()
        {
            if (_x + 1 < _world.GetWidth())
            {
                return true;
            }
            if (_y + 1 < _world.GetHeight())
            {
                return true;
            }
            return false;
        }

        public StaticElement Next()
        {
            if (_x + 1 < _world.GetWidth())
            {
                _x++;
            }
            else if (_y + 1 < _world.GetHeight())
            {
                _x = 0;
                _y++;
            }
            return _world.Get(_x, _y);
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }
    }
}
