using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class CrystalElement : FlowElement
    {
	    int growthStage {
			get;
			set;
		}
		const int MAX_GROWTH_STAGE = 1000;
		
		public static CrystalElement CreateElement(Vector3Int intPos, Tilemap tilemap, MapHandler map, TilemapIterator iterator)
        {
            var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new CrystalElement(
                map,
                new Position(intPos),
                iterator,
                topOpen,
                rightOpen,
                bottomOpen,
                leftOpen);
        }
        
        protected CrystalElement(MapHandler map, Position pos, TilemapIterator iterator, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
	        TilemapIterator = iterator;
	        
			// from 0 (nothing) to 1000 (completed)
			this.growthStage = 0;
        }
		
		public override void tick()
		{
			if(null != this.content)
			{
				// from 0 (nothing) to 1000 (completed)
				if(this.growthStage < CrystalElement.MAX_GROWTH_STAGE)
				{
					this.growthStage += 1;
				}
				
				this.content = null;
			}
		}
		
		public bool IsComplete()
		{
			if(CrystalElement.MAX_GROWTH_STAGE == this.growthStage)
			{
				return true;
			} else
			{
				return false;
			}
		}
		
		public double CompletionInPercent()
		{
			return (this.growthStage * 100.00 / CrystalElement.MAX_GROWTH_STAGE);
		}
		
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
			this.content = blob;
			
            // TODO: figure out
            // the real magic happens here
			return true;
        }

        //non-sensical for this class
        public override void FlowFurther()
        {
            return;
        }
    }
}