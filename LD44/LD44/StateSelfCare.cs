using System;
using System.Collections;
using System.Collections.Generic;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class StateSelfCare : GameState
    {
        public StateSelfCare()
        {
        }

        public string[] games    = { "biking", "dancing", "donating", "eating", "family", "meditating", "reading", "sleeping", "walking" };
        public int[] soulEffect  = { 10,       10,        0,          10,       0,        10,           10,        10,         10        };
        public int[] heartEffect = { 0,        10,        10,         10,       10,       10,           0,         10,         0         };
        public Texture2D[] gameBackgrounds;
        public Texture2D instructionsBackground;
        public UIBar enoughTapsBar;
        public UIBar timerBar;

        public Dictionary<string, int> keyMapping = new Dictionary<string, int> {
            ["a"]=KEY_A,
            ["b"]=KEY_B,
            ["c"]=KEY_C,
            ["d"]=KEY_D,
            ["e"]=KEY_E,
            ["f"]=KEY_F,
            ["g"]=KEY_G,
            ["i"]=KEY_I,
            ["k"]=KEY_K,
            ["l"]=KEY_L,
            ["m"]=KEY_M,
            ["n"]=KEY_N,
            ["o"]=KEY_O,
            ["p"]=KEY_P,
            ["r"]=KEY_R,
            ["s"]=KEY_S,
            ["t"]=KEY_T,
            ["w"]=KEY_W,
            ["y"]=KEY_Y
        };

        public void Init()
        {
            List<Texture2D> gameBacks = new List<Texture2D>();
            foreach (var game in games)
            {
                gameBacks.Add(LoadTexture("assets/selfcare/" + game + ".png"));
            }
            gameBackgrounds = gameBacks.ToArray();

            instructionsBackground = LoadTexture("assets/selfcare/instructionbg.png");
            candidates = new string[games.Length];
            candidateSelected = new bool[games.Length];
            enoughTapsBar = new UIBar(390, 100);
            timerBar = new UIBar(1004, 600);

            PlaySound(Sounds.MUSIC_SELFCARE);
        }

        private int index = 0;
        bool[] candidateSelected;
        string[] candidates;
        int amount = 0;
        int barMax = 100;
        int time = 0;
        public void Update()
        {
            time++;
            if (time < 600)
            {
                DrawTexture(gameBackgrounds[index], 0, 0, WHITE);

                DrawTexture(instructionsBackground, 0, 0, WHITE);

                enoughTapsBar.SetValue(amount);
                timerBar.SetValue(time);
                enoughTapsBar.Render(10, 180, RED);
                timerBar.Render(10, 740, WHITE);

                int offset = 0;
                foreach (char c in games[index])
                {
                    if (!candidateSelected[index])
                    {
                        if (GetRandomValue(1, 10) < 9)
                        {
                            DrawText(c.ToString(), 10 + offset, 10, 65, BLACK);
                        }
                        else
                        {
                            candidates[index] = c.ToString();
                            candidateSelected[index] = true;
                            DrawText(c.ToString(), 10 + offset, 10, 65, GREEN);
                        }
                    }
                    else
                    {
                        if (c.ToString() == candidates[index])
                        {
                            DrawText(c.ToString(), 10 + offset, 10, 65, GREEN);
                        }
                        else
                        {
                            DrawText(c.ToString(), 10 + offset, 10, 65, BLACK);
                        }
                    }
                    offset += 2 + MeasureText(c.ToString(), 65);
                }

                if (candidateSelected[index])
                {
                    if (IsKeyReleased(keyMapping[candidates[index]]))
                    {
                        PlaySound(Sounds.HIT);
                        amount += 40;
                        if (amount >= barMax)
                        {
                            StaticPlayer.Heart += heartEffect[index];
                            StaticPlayer.Soul += soulEffect[index];

                            if (StaticPlayer.Heart > 100) StaticPlayer.Heart = 100;
                            if (StaticPlayer.Soul > 100) StaticPlayer.Soul = 100;

                            amount = 0;
                            index++;
                            if (index == gameBackgrounds.Length)
                            {
                                PlaySound(Sounds.TITLE);
                                index = 0;
                                barMax += 100;
                                enoughTapsBar = new UIBar(390, barMax);
                                candidates = new string[games.Length];
                                candidateSelected = new bool[games.Length];
                            }
                        }
                    }
                }
                amount--;
                if (amount < 0) amount = 0;
            }
            else
            {
                StopSound(Sounds.MUSIC_SELFCARE);
                PlaySound(Sounds.AMBIENT_CITYHUM);
                MainClass.stateManager.SwitchStateNoInit(MainClass.stateCity);
            }
        }
    }
}
