namespace DefaultNamespace
{
    public class Position
    {
        private int x
        {
            get;
            set;
        }

        private int y
        {
            get;
            set;
        }

        public bool Equals(Position otherPos) {
			if(this.x == otherPos.GetX()
			&& this.y == otherPos.GetY())
			{
				return true;
			} else
			{
				return false;
			}
		}

    }
}