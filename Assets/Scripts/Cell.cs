using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour {

		private float _g			= 0; 		// de g score is de score voor het pad van het beginpunt tot deze cell. Deze score hebben we berekent
		private float _h			= 0; 		// de h score is de score voor het pad die we schatten vanaf deze cell tot het eindpunt.
		private float _f			= 0; 		// f = g + h; de variabele f is de geschatte score van het beginpunt VIA deze cell naar het eindpunt
		private bool _isWall	=	false;		// boolean om deze cell als wall te definieren
		private bool _isOpen 	=	false; 	// variabele om (snel) bij te houden of we deze cell als buurman hebben gezien en nog moeten checken
		private bool _isClosed	=	false; 	// variabele om bij te houden of we deze cell al hebben gecheckt
		private	Cell _parent; 				// variabele om bij te houden wie, in het pad, mijn parent is (via welke cell kom je bij mij)
		private Vector2 _position;			// wat is mijn positie in het grid
		private float[] _neighbors; 			// wie zijn mijn buren (cellen)
		
		
		public void Start() 
		{
			_position	=	new Vector2(1, 1);
		}
		
		
		public Vector2 position 
		{
			get { return _position;}
			set	{ _position = value;}
		}

		public float f 
		{
			get	{ return _f; }
			set {_f = value; }
		}
		
		public float g
		{
			get	{ return _g; }
			set {_g = value; }
		}
		
		public float h
		{
			get	{ return _h; }
			set {_h = value; }
		}
		
		public bool Walls
		{
			get	{ return _isWall; }
			set {_isWall = value; }
		}
		
		public Cell parent
		{
			get	{ return _parent; }
			set {_parent = value; }
		}
		
		public bool isOpen 
		{
			get	{ return _isOpen; }
			set {_isOpen = value; }
		}
		
		public bool isClosed
		{
			get	{ return _isClosed; }
			set {_isClosed = value; }
		}
		
		public float[] neighbors
		{
			get	{ return _neighbors; }
			set {_neighbors = value; }
		}
		
		public string toString()
		{
			return "{x:" + position.x + ", y:" + position.y + ", f: " + f + "}";
		}
}