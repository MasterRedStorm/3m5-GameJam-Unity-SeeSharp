using UnityEngine;

namespace DefaultNamespace
{
    // for class 'Color'
    public class LiquidBlob
    {
	    public LiquidBlob Clone()
	    {
		    return new LiquidBlob();
	    }
	    
        private Color color
        {
            get;
            set;
        }
		//TODO: maybe implement a better mixing method, than just
		//        setting this color to the average values of both colors?
		public void MixBlob(LiquidBlob otherBlob)
		{
			float R = (this.color.r + otherBlob.color.r) / 2;
			float G = (this.color.g + otherBlob.color.g) / 2;
			float B = (this.color.b + otherBlob.color.b) / 2;

			this.color = new Color(R, G, B);
		}
    }
}