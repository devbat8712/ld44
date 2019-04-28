using System;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class StateGameOver : GameState
    {
        public StateGameOver()
        {
        }

        Texture2D gameOverScreen;
        Texture2D gameOverScreenCityDead;

        public void Init()
        {
            gameOverScreen = LoadTexture("assets/gameover.png");
            gameOverScreenCityDead = LoadTexture("assets/gameover-citydead.png");
        }

        public void Update()
        {
            StopSound(Sounds.AMBIENT_CITYHUM);

            DrawTexture(gameOverScreen, 0, 0, WHITE);

            if (StaticPlayer.IsCityDead) DrawTexture(gameOverScreenCityDead, 0, 0, WHITE);

            DrawText("you survived for", 20, 540, 40, BLACK);
            DrawText(StaticPlayer.Days.ToString(), 20, 580, 72, BLACK);
            DrawText("days.", 20, 652, 40, BLACK);

            if (IsKeyReleased(KEY_SPACE))
            {
                MainClass.stateManager.SwitchState(new StateTitle());
                StaticPlayer.ResetStats();
            }
        }
    }
}
