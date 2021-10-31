using UnityEngine;

namespace DefaultNamespace
{
    public class LiquidBlob
    {
		public LiquidBlob(float r, float g, float b)
		{
			this.color = new Color(r, g, b);
		}
		
	    public LiquidBlob Clone()
	    {
		    return new LiquidBlob(r, g, b);
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
		
		public bool Equals(LiquidBlob otherLiquid)
		{
			if(null != otherLiquid)
			{
				if( this.color.r == otherLiquid.color.r
				&&  this.color.g == otherLiquid.color.g
				&&  this.color.b == otherLiquid.color.b)
				{
					return true;
				}
			}
			return false;
			
		}
    }
}