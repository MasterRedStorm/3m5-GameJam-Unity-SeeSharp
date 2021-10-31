using UnityEditor.Compilation;

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
		
        public MapHandler(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.field = new GridElement[width * height];
        }

        public void SetElement(Position pos, GridElement el)
        {
            this.field[pos.x * height + pos.y] = el;
        }
        
        public GridElement GetElementAtPos(int x, int y)
        {
            if (x >= 0 && x < this.width)
            {
                if (y >= 0 && y < this.height)
                {
                    return this.field[x * height +y];
                }
            }

            return null;
        }
    }
}