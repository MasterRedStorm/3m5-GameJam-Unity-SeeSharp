
using UnityEngine;

namespace DefaultNamespace {
	public class GridElement : /*MonoBehaviour,*/ MapElement {
		protected Position pos;
		protected MapHandler map;
		public Position GetPosition()
		{
			return this.pos;
		}
		public GridElement(MapHandler map, Position pos)
		{
			this.map = map;
			this.pos = pos;
		}
	}
}