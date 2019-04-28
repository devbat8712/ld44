using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class Trixel
    {
        public Vector2 coord;
        public Color color;

        public Trixel(Vector2 coord, Color color)
        {
            this.coord = coord;
            this.color = color;
        }
    }
}