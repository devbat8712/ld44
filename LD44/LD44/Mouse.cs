namespace LD44
{
    public class Mouse
    {
        public Mouse(int width, int height, int tilesWidth, int tilesHeight)
        {
            this.width = width;
            this.height = height;
            this.tilesWidth = tilesWidth;
            this.tilesHeight = tilesHeight;
        }

        private int width;
        private int height;
        private int tilesWidth;
        private int tilesHeight;
        private int mouseX;
        private int mouseY;

        public int CursorX;
        public int CursorY;

        public int CursorTileX;
        public int CursorTileY;

        public void UpdateMouse(int x, int y)
        {
            this.mouseX = x;
            this.mouseY = y;

            CursorX = Util.RoundUp(mouseX, width) - width;
            CursorY = Util.RoundUp(mouseY, height) - height;

            CursorTileX = CursorX / width;
            CursorTileY = CursorY / height;

            if (CursorTileX > tilesWidth) CursorTileX = tilesWidth;
            if (CursorTileY > tilesHeight) CursorTileY = tilesHeight;
            if (CursorTileX < 0) CursorTileX = 0;
            if (CursorTileY < 0) CursorTileY = 0;
        }
    }
}