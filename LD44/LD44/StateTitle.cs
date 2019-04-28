using System;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class StateTitle : GameState
    {
        public StateTitle()
        {
        }

        Texture2D titleScreen;

        public virtual void Init()
        {
            titleScreen = LoadTexture("assets/title.png");
        }

        public virtual void Update()
        {
            DrawTexture(titleScreen, 0, 0, WHITE);

            if (IsKeyReleased(KEY_SPACE))
            {
                PlaySound(Sounds.TITLE);
                MainClass.stateManager.SwitchState(new StateTutorial());
            }
        }
    }
}
