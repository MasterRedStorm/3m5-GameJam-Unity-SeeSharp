namespace DefaultNamespace
{
    public class MapHandler
    {
        MapHandler(width, height)
        {
            this.width = width;
            this.height = height;
            this.field = GridElement[width * height];
        }
        private GridElement[] field = null;
        private int width;
        private int height;

        public GridElement GetElementAtPos(int x, int y)
        {
            if (x >= 0 && x < this.height)
            {
                if (y >= 0 && y < this.height)
                {
                    return this.field[y * width + x];
                }
            }

            return null;
        }
    }
}