using System;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class CityUI : UI
    {
        public CityUI(string overlayFilename) : base(overlayFilename)
        {
        }

        // player stat bars
        public UIBar statHeart = new UIBar(180, 100);
        public UIBar statSoul = new UIBar(180, 100);

        // city stat bars
        public UIBar cityStatHealth = new UIBar(160, 100);
        public UIBar cityStatPopPercent = new UIBar(160, 100);
        public UIBar cityStatCrimeRate = new UIBar(160, 100);
        public UIBar cityStatUnemployment = new UIBar(160, 100);
        public UIBar cityStatHappiness = new UIBar(160, 100);

        public Rectangle selfCareButton = new Rectangle(805, 91, 204, 111);

        public new void Update()
        {
            base.Update();
            //if (heart < 100) heart++; else heart = 0;
            //if (soul < 100) soul += 2; else soul = 0;

            //Console.WriteLine(heart);

            statHeart.SetValue((int)StaticPlayer.Heart);
            statSoul.SetValue((int)StaticPlayer.Soul);

            cityStatHealth.SetValue((int)StaticPlayer.CityHealth);
            cityStatPopPercent.SetValue((int)StaticPlayer.CityPopPercent);
            cityStatCrimeRate.SetValue((int)StaticPlayer.CityCrimeRate);
            cityStatUnemployment.SetValue((int)StaticPlayer.CityUnemployment);
            cityStatHappiness.SetValue((int)StaticPlayer.CityHappiness);

            if (IsMouseButtonReleased(MOUSE_LEFT_BUTTON))
            {
                if (CheckCollisionPointRec(new Vector2(GetMouseX(), GetMouseY()), selfCareButton))
                {
                    StopSound(Sounds.AMBIENT_CITYHUM);
                    MainClass.stateCity = (StateCity)MainClass.stateManager.State;
                    MainClass.stateManager.SwitchState(new StateSelfCare());
                }
            }
        }

        public new void Render()
        {
            base.Render();
            statHeart.Render(830, 20, RED);
            statSoul.Render(830, 60, ORANGE);

            cityStatHealth.Render(45, 640, GREEN);
            cityStatPopPercent.Render(50, 675, GOLD);
            cityStatCrimeRate.Render(64, 710, RED);
            cityStatUnemployment.Render(330, 632, BROWN);
            cityStatHappiness.Render(335, 665, PURPLE);

            // 839, 640
            DrawText(StaticPlayer.TimeHour + ":" + Util.PadZeroes(StaticPlayer.TimeMinute, 2), 839, 640, 72, BLACK);
            // 832, 720
            DrawText("you have survived for " + StaticPlayer.Days + " days.", 832, 720, 12, DARKGRAY);
        }
    }
}
