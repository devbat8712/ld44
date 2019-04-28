using System;
using Raylib;
using static Raylib.Raylib;
namespace LD44
{
    public class Sounds
    {
        public Sounds()
        {
        }

        public static Sound CLICK;
        public static Sound PLACE;
        public static Sound ALERT;
        public static Sound TITLE;
        public static Sound HIT;

        public static Sound MUSIC_SELFCARE;

        public static Sound AMBIENT_CITYHUM;

        public static void InitializeSounds()
        {
            CLICK = LoadSound("assets/sound/click.wav");
            PLACE = LoadSound("assets/sound/place.wav");
            ALERT = LoadSound("assets/sound/alert.wav");
            TITLE = LoadSound("assets/sound/title.wav");
            HIT = LoadSound("assets/sound/hit.wav");

            MUSIC_SELFCARE = LoadSound("assets/sound/music_selfcare.ogg");

            AMBIENT_CITYHUM = LoadSound("assets/sound/ambient_cityhum.ogg");
        }
    }
}
