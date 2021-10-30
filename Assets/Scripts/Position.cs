namespace DefaultNamespace
{
    public class Position
    {
        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

		public Position(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

        public bool Equals(Position otherPos) {
			if(this.x == otherPos.x
			&& this.y == otherPos.y)
			{
				return true;
			} else
			{
				return false;
			}
		}

    }
}