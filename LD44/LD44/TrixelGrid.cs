using static Raylib.Raylib;
using System.Collections.Generic;
using System.Collections;

namespace LD44
{
    public class TrixelGrid
    {
        private List<List<Trixel>> trixels = new List<List<Trixel>>();

        public TrixelGrid()
        {

        }

        public TrixelGrid(int sizeX, int sizeY)
        {
            for (int x = 0; x < sizeX; x++)
            {
                trixels.Add(new List<Trixel>());
                for (int y = 0; y < sizeY; y++)
                {
                    trixels[x].Add(new Trixel(new Raylib.Vector2(x * 32, y * 32), BLUE));
                }
            }
        }

        public Trixel TrixelAt(int x, int y)
        {
            return trixels[x][y];
        }

        public void SetTrixelAt(int x, int y, Trixel trixel)
        {
            trixels[x][y] = trixel;
        }
    }
}