using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class Tile
    {
        public Tile(Texture2D tex, string name, int heartCost, int soulCost)
        {
            this.Texture = tex;
            this.Name = name;
            this.HeartCost = heartCost;
            this.SoulCost = soulCost;
        }

        public Tile(Tile t)
        {
            this.Texture = t.Texture;
            this.Name = t.Name;
            this.Rotation = t.Rotation;
        }

        public Texture2D Texture;
        public string Name;
        public float Rotation = 0;

        public int HeartCost;
        public int SoulCost;
    }
}