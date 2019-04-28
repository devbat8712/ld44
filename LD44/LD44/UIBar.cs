using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class UIBar
    {
        public UIBar(int length, int maxValue)
        {
            this.length = length;
            this.maxValue = maxValue;
        }

        private int length;
        private int value;
        private int maxValue;

        public void Render(int x, int y, Color color)
        {
            int rectLength = (value * length) / maxValue;

            DrawLineEx(new Vector2(x, y), new Vector2(x + rectLength, y), 5.0f, color);
        }

        public void SetValue(int newValue)
        {
            value = newValue;
        }
    }
}