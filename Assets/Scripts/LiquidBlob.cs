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
			int R = (this.color.R + otherBlob.color.R) / 2;
			int G = (this.color.G + otherBlob.color.G) / 2;
			int B = (this.color.B + otherBlob.color.B) / 2;

			this.color = Color.FromArgb(R, G, B);
		}
    }
}