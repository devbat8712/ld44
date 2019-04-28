using System;
using Raylib;

namespace LD44
{
    public interface GameState
    {
        void Init();
        void Update();
    }
}
