using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class MixerElement : FlowElement
    {
        public static MixerElement CreateElement(Vector3Int intPos, Tilemap tilemap, MapHandler map, TilemapIterator iterator)
        {
            var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new MixerElement(
                map,
                new Position(intPos),
                iterator,
                topOpen,
                rightOpen,
                bottomOpen,
                leftOpen);
        }
        
        protected MixerElement(MapHandler map, Position pos, TilemapIterator iterator, bool openTop, bool openRight, bool openBottom, bool openLeft) : base(map, pos, null, openTop, openRight, openBottom, openLeft)
        {
            TilemapIterator = iterator;
        }
		
		public override void tick()
		{
			this.FlowFurther();
		}
        
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            // TODO: make it dependent on button press!
			
			if(null != this.content)
			{
				this.content.MixBlob(blob);
			} else
			{
				this.content = null;
			}
			// TODO: Reconsider this
			return true;
        }


        public override void FlowFurther()
        {
            List<GridElement> targets = this.GetTargets(true, true);
            
            // Count successfull flows
            int countSuccessfullFlows = 0;
            foreach (FlowElement curTarget in targets)
            {
                if (null != curTarget)
                {
                    if (((FlowElement) curTarget).TryFill(this.pos, this.content))
                    {
                        countSuccessfullFlows += 1;
                    }
                }
            }

            if (countSuccessfullFlows >= 1)
            {
                this.Clear();
            }
        }
    }
}