using System;
using Newtonsoft.Json.Linq;
using Raylib;
using System.IO;
using static Raylib.Raylib;
using System.Threading.Tasks;

namespace LD44
{
    class MainClass
    {
        private static int screenWidth = 1024;
        private static int screenHeight = 768;

        public static StateManager stateManager = new StateManager();
        public static StateCity stateCity;

        public static void Main(string[] args)
        {
            InitWindow(screenWidth, screenHeight, "LD44");
            Console.WriteLine("window init");

            SetTargetFPS(60);
            Console.WriteLine("target fps set");

            InitAudioDevice();
            Console.WriteLine("init sfx device");

            Texture2D loadingScreen = LoadTexture("assets/loading.png");


            Task t = Task.Run((Action)Sounds.InitializeSounds);

            while (!t.IsCompleted)
            {
                BeginDrawing();
                DrawTexture(loadingScreen, 0, 0, WHITE);
                EndDrawing();
            }

            stateManager.SwitchState(new StateTitle());

            while (!WindowShouldClose())    // Detect window close button or ESC key
            {
                BeginDrawing();

                ClearBackground(RAYWHITE);

                stateManager.State.Update();

                EndDrawing();

                SetWindowTitle("LD44 FPS: " + GetFPS());

                if (IsKeyReleased(KEY_F11))
                    ToggleFullscreen();
            }

            CloseWindow();
        }
    }
}
