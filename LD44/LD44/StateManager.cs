namespace LD44
{
    public class StateManager
    {
        public GameState State;
        public void SwitchState(GameState newState)
        {
            State = newState;
            State.Init();
        }

        public void SwitchStateNoInit(GameState newState)
        {
            State = newState;
        }
    }
}