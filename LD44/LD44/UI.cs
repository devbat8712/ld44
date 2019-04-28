using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class UI
    {
        public UI(string overlayFilename)
        {
            overlay = LoadTexture(overlayFilename);
        }

        private Texture2D overlay;

        public void Render()
        {
            DrawTexture(overlay, 0, 0, WHITE);
        }

        public void Update()
        {

        }
    }
}