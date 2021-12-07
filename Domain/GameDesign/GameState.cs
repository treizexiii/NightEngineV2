using Domain.GameDesign.State;

namespace Domain.GameDesign
{
    public class GameState
    {
        public Characters Chars { get; set; }
        public World World { get; set; }

        public GameState()
        {

        }
    }
}
