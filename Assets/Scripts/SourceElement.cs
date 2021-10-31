using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

namespace DefaultNamespace
{
    // for class 'List<T>'
    using System.Collections.Generic;
    public class SourceElement : FlowElement
    {
        public static SourceElement CreateElement(Vector3Int intPos, Tilemap tilemap, MapHandler map, TilemapIterator iterator)
        {
            /*var topPos = new Vector3Int(intPos.x, intPos.y + 1, intPos.z);
            var rightPos = new Vector3Int(intPos.x + 1, intPos.y, intPos.z);
            var bottomPos = new Vector3Int(intPos.x, intPos.y - 1, intPos.z);
            var leftPos = new Vector3Int(intPos.x - 1, intPos.y, intPos.z);

            var topOpen = tilemap.GetTile(topPos);
            var rightOpen = tilemap.GetTile(rightPos);
            var bottomOpen = tilemap.GetTile(bottomPos);
            var leftOpen = tilemap.GetTile(leftPos);

            return new SourceElement(map, pos, topOpen, rightOpen, bottomOpen, leftOpen);*/
            return new SourceElement(
                map,
                new Position(intPos),
                new LiquidBlob(),
                iterator);
        }
        
        // A water tank or 'SourceElement' is never 'open'
        protected SourceElement(MapHandler map, Position pos, LiquidBlob content, TilemapIterator iterator) : base(map, pos, content, false, false, false, false)
        {
            TilemapIterator = iterator;
        }

		public override void tick()
		{
			this.FlowFurther();
		}

        // Nothing can flow into our water tank!
        public override bool TryFill(Position fromPos, LiquidBlob blob)
        {
            return false;
        }
        public override void FlowFurther()
        {
            List<GridElement> targets = base.GetTargets(false, true);

            foreach (GridElement curTarget in targets)
            {
                if(null != curTarget)
                {
                    ((FlowElement) curTarget).TryFill(this.pos, this.content.Clone());
                }
            }
        }
	}
}