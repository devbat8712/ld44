using System;
using Raylib;
using static Raylib.Raylib;

namespace LD44
{
    public class Tileset
    {
        public Tileset()
        {
        }

        public static Tile GRASS;
        public static Tile ROAD_STRAIGHT;
        public static Tile ROAD_TURN;
        public static Tile ROAD_T;

        public static Tile NODRAW;

        //BUILDINGS
        public static Tile SUPERMART;
        public static Tile GAS;
        public static Tile OFFICE;
        public static Tile HIGHRISE;
        public static Tile HOUSE;
        public static Tile SHACK;
        public static Tile POLICE;
        public static Tile GYM;
        public static Tile BAR;
        public static Tile PLAYGROUND;

        public static void InitializeTiles()
        {
            GRASS = new Tile(LoadTexture("assets/tile/grass.png"), "GRASS", 0, 0);
            ROAD_STRAIGHT = new Tile(LoadTexture("assets/tile/road_straight.png"), "ROAD_STRAIGHT", 0, 0);
            ROAD_TURN = new Tile(LoadTexture("assets/tile/road_turn.png"), "ROAD_TURN", 0, 0);
            ROAD_T = new Tile(LoadTexture("assets/tile/road_t.png"), "ROAD_T", 0, 0);

            SUPERMART = new Tile(LoadTexture("assets/tile/supermart.png"), "SUPERMART", 0, 20);
            GAS = new Tile(LoadTexture("assets/tile/gas.png"), "GAS", 0, 15);
            OFFICE = new Tile(LoadTexture("assets/tile/office.png"), "OFFICE", 0, 50);
            HIGHRISE = new Tile(LoadTexture("assets/tile/highrise.png"), "HIGHRISE", 25, 0);
            HOUSE = new Tile(LoadTexture("assets/tile/house.png"), "HOUSE", 15, 0);
            SHACK = new Tile(LoadTexture("assets/tile/shack.png"), "SHACK", 5, 0);
            POLICE = new Tile(LoadTexture("assets/tile/police.png"), "POLICE", 0, 20);
            GYM = new Tile(LoadTexture("assets/tile/gym.png"), "GYM", 15, 0);
            BAR = new Tile(LoadTexture("assets/tile/bar.png"), "BAR", 20, 0);
            PLAYGROUND = new Tile(LoadTexture("assets/tile/playground.png"), "PLAYGROUND", 20, 0);

            NODRAW = new Tile(new Texture2D(), "NODRAW", 0, 0);
        }
    }
}
