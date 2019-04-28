using System;
using System.Collections;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class StateTutorial : GameState
    {
        public StateTutorial()
        {
        }

        List<Texture2D> tutorialScreens = new List<Texture2D>();
        int numberOfScreens = 10;
        int currentScreen = 1;

        public void Init()
        {
            for (int i = 0; i < numberOfScreens; i++)
            {
                tutorialScreens.Add(LoadTexture("assets/tutorial/" + (i + 1) + ".png"));
            }
        }

        public void Update()
        {
            DrawTexture(tutorialScreens[currentScreen - 1], 0, 0, WHITE);

            if (IsKeyReleased(KEY_SPACE))
            {
                PlaySound(Sounds.CLICK);
                currentScreen++;
            }

            if (IsKeyReleased(KEY_S))
            {
                currentScreen = numberOfScreens + 1;
            }

            if (currentScreen == numberOfScreens + 1)
            {
                PlaySound(Sounds.TITLE);
                MainClass.stateCity = new StateCity();
                MainClass.stateManager.SwitchState(MainClass.stateCity);
            }
        }
    }
}
