using System;
using Raylib;
using static Raylib.Raylib;
using System.Collections;
using System.Collections.Generic;

namespace LD44
{
    public class StateCity : GameState
    {
        public StateCity()
        {
        }

        private Mouse mouse;
        public Tile[,] tiles;
        private Tile[,] cursorMap;
        public Camera2D Camera;
        private readonly int WIDTH = 21;
        private readonly int HEIGHT = 15;

        private CityUI ui;

        private int palleteIndex = 1;
        private Tile[] pallete;

        private City city = new City();

        private long frames;

        public void Init()
        {
            mouse = new Mouse(48, 48, 20, 14);

            tiles = new Tile[WIDTH, HEIGHT];
            cursorMap = new Tile[WIDTH, HEIGHT];

            ui = new CityUI("assets/ui/overlay_city.png");

            Tileset.InitializeTiles();
            pallete = new Tile[] { Tileset.GRASS, 
                //Tileset.ROAD_STRAIGHT, Tileset.ROAD_TURN, Tileset.ROAD_T,
                Tileset.SUPERMART, Tileset.GAS, Tileset.OFFICE,
                Tileset.HIGHRISE, Tileset.HOUSE, Tileset.SHACK,
                Tileset.POLICE,
                Tileset.GYM, Tileset.BAR, Tileset.PLAYGROUND };
            //pallete = GenerateRotations(pallete);
            MakeTileMapBlank(ref tiles, WIDTH, HEIGHT, Tileset.GRASS);

            PlaySound(Sounds.AMBIENT_CITYHUM);
        }

        public Tile[] GenerateRotations(Tile[] thePallete)
        {
            List<Tile> final = new List<Tile>();

            foreach (Tile t in thePallete)
            {
                final.Add(t);

                if (t.Name != "NODRAW" && t.Name != "GRASS")
                {
                    Tile rot90 = new Tile(t);
                    rot90.Name += "_ROT90";
                    rot90.Rotation = 90;
                    final.Add(rot90);

                    Tile rot180 = new Tile(t);
                    rot180.Name += "_ROT180";
                    rot180.Rotation = 180;
                    final.Add(rot180);

                    Tile rot270 = new Tile(t);
                    rot270.Name += "_ROT270";
                    rot270.Rotation = 270;
                    final.Add(rot270);
                }
            }

            return final.ToArray();
        }

        public void MakeTileMapBlank(ref Tile[,] tilemap, int w, int h, Tile blankWith)
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    tilemap[x, y] = blankWith;
                }
            }
        }

        public void DrawTileMap(Tile[,] tilemap, Color tint, bool outline, int w, int h)
        {
            for (int x = 0; x < w; x++)
            {
                for (int y = 0; y < h; y++)
                {
                    try
                    {
                        if (tilemap[x, y].Name != "NODRAW")
                        {
                            if (tilemap[x, y].Name.Contains("ROT90")) 
                            {
                                DrawTextureEx(tilemap[x, y].Texture, new Vector2(x * 48 + 48, y * 48), tilemap[x, y].Rotation, 1.0f, tint);
                            }
                            else if (tilemap[x, y].Name.Contains("ROT180"))
                            {
                                DrawTextureEx(tilemap[x, y].Texture, new Vector2(x * 48 + 48, y * 48 + 48), tilemap[x, y].Rotation, 1.0f, tint);
                            }
                            else if (tilemap[x, y].Name.Contains("ROT270"))
                            {
                                DrawTextureEx(tilemap[x, y].Texture, new Vector2(x * 48, y * 48 + 48), tilemap[x, y].Rotation, 1.0f, tint);
                            }
                            else
                            {
                                DrawTextureEx(tilemap[x, y].Texture, new Vector2(x * 48, y * 48), tilemap[x, y].Rotation, 1.0f, tint);
                            }

                            if (outline)
                                DrawRectangleLines(x * 48, y * 48, 48, 48, BLACK);
                        }
                    } catch (NullReferenceException) { }
                }
            }
        }

        public void IncreasePallete()
        {
            palleteIndex++;
            if (palleteIndex > pallete.Length - 1) palleteIndex = 0;
        }

        public void DecreasePallete()
        {
            palleteIndex--;
            if (palleteIndex < 0) palleteIndex = pallete.Length - 1;
        }

        public void Update()
        {
            frames++;

            if ((frames % 10) == 0)
            {
                StaticPlayer.TimeMinute++;
                if (StaticPlayer.TimeMinute == 60)
                {
                    StaticPlayer.TimeHour++;
                    StaticPlayer.TimeMinute = 0;

                    if (StaticPlayer.TimeHour == 24)
                    {
                        StaticPlayer.TimeHour = 0;
                        StaticPlayer.TimeMinute = 0;
                        StaticPlayer.Days++;
                    }
                }
                StaticPlayer.TurnsSinceLastAction++;
                city.Simulate(tiles);

                if (StaticPlayer.IsCityDead) MainClass.stateManager.SwitchState(new StateGameOver());
                if (StaticPlayer.Heart < 0) MainClass.stateManager.SwitchState(new StateGameOver());
                if (StaticPlayer.Soul < 0) MainClass.stateManager.SwitchState(new StateGameOver());
            }

            if (StaticPlayer.TimeHour < 5)
            {
                DrawTileMap(tiles, BLACK, false, WIDTH, HEIGHT);
            } 
            else if (StaticPlayer.TimeHour > 18)
            {
                DrawTileMap(tiles, BLACK, false, WIDTH, HEIGHT);
            }
            else
            {
                DrawTileMap(tiles, WHITE, false, WIDTH, HEIGHT);
            }

            mouse.UpdateMouse(GetMouseX(), GetMouseY());

            MakeTileMapBlank(ref cursorMap, WIDTH, HEIGHT, Tileset.NODRAW);
            cursorMap[mouse.CursorTileX, mouse.CursorTileY] = pallete[palleteIndex];
            DrawTileMap(cursorMap, BLUE, true, WIDTH, HEIGHT);

            ui.Update();
            ui.Render();

            DrawText("mouse x: " + GetMouseX() + " mouse y: " + GetMouseY(), 0, 0, 10, WHITE);
            DrawText("cursor x: " + mouse.CursorX + " cursor y: " + mouse.CursorY, 0, 10, 10, WHITE);
            DrawText("cursor tx: " + mouse.CursorTileX + " cursor ty: " + mouse.CursorTileY, 0, 20, 10, WHITE);
            DrawText("tile @ cursor: " + tiles[mouse.CursorTileX, mouse.CursorTileY].Name, 0, 30, 10, WHITE);
            DrawText("tile selected: " + pallete[palleteIndex].Name, 0, 40, 10, WHITE);

            if (IsMouseButtonDown(MOUSE_LEFT_BUTTON))
            {
                //Console.WriteLine("mouse click");
                if (!CheckCollisionPointRec(GetMousePosition(), ui.selfCareButton))
                {
                    if (StaticPlayer.Heart - pallete[palleteIndex].HeartCost > 0)
                    {
                        if (StaticPlayer.Soul - pallete[palleteIndex].SoulCost > 0)
                        {
                            StaticPlayer.Heart -= pallete[palleteIndex].HeartCost;
                            StaticPlayer.Soul -= pallete[palleteIndex].SoulCost;
                            tiles[mouse.CursorTileX, mouse.CursorTileY] = pallete[palleteIndex];

                            if (pallete[palleteIndex].Name != "GRASS")
                                if (!pallete[palleteIndex].Name.Contains("ROAD"))
                                    StaticPlayer.AddToCityHealth(10);
                            StaticPlayer.TurnsSinceLastAction = 0;
                            StaticPlayer.StagnationCoefficient = 1;
                            PlaySound(Sounds.PLACE);
                        }
                    }
                }
            }
            else if (IsMouseButtonDown(MOUSE_RIGHT_BUTTON))
            {
                tiles[mouse.CursorTileX, mouse.CursorTileY] = Tileset.GRASS;
            }

            if (GetMouseWheelMove() > 0) IncreasePallete();
            if (GetMouseWheelMove() < 0) DecreasePallete();
        }
    }
}
