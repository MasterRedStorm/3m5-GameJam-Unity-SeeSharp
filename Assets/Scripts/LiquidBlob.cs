namespace DefaultNamespace
{
    // for class 'Color'
    using System.Drawing;
    public class LiquidBlob
    {
        private Color color
        {
            get;
            set;
        }
		//TODO: maybe implement a better mixing method, than just
		//        setting this color to the average values of both colors?
		public void MixBlob(LiquidBlob otherBlob)
		{
			this.color.R = (this.color.R + otherBlob.GetColor().R) / 2;
			this.color.G = (this.color.G + otherBlob.GetColor().G) / 2;
			this.color.B = (this.color.B + otherBlob.GetColor().B) / 2;
		}
    }
}