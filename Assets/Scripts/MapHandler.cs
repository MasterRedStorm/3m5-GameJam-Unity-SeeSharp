namespace DefaultNamespace
{
    public class MapHandler
    {
        private GridElement[] field = null;
        private int width {
			get;
		}
        private int height {
			get;
		}
		
        MapHandler(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.field = GridElement[width * height];
        }


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