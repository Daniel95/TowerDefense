using UnityEngine;
using System.Collections;

public class Grid : MonoBehaviour {

	// variabelen om het grid en de grootte van het grid bij te houden
	private Cell[,] _grid;
	private int _width;
	private int _height;
	
	void Grids(int width, int height)
	{
		this._width = width;
		this._height = height;
		_grid = new Cell[width, height];
		
		// we doen een forLoop in een forLoop om alle cellen aan te maken
		for (int x = 0; x < width; x++)
		{
			for (int y = 0; y < height; y++)
			{
				_grid[x,y] = new Cell();
			}
		}
	}
	
	// functie om een specifieke cell op te halen
	public Cell getCell(int x, int y)
	{
		if (_grid[x,y]) 
		{
			return _grid[x,y];
		}
			return null;
	}
	
	// functie om alle cellen te resetten
	public void reset()
	{
		Cell currentCell;
		int l = _grid.Length;
		for (int x = 0; x < l; x++)
		{
			for (int y = 0; y < _grid.Length; y++)
			{
				currentCell	=	_grid[x,y];
				currentCell.f = 0;
				currentCell.g = 0;
				currentCell.h = 0;
				currentCell.isClosed	=	false;
				currentCell.isOpen		=	false;
				currentCell.parent = null;
			}	
		}
	}
	
	public int width 
	{
		get	{ return _width; }
		set {_width = value; }
	}
	
	public int height
	{
		get	{ return _height; }
		set {_height = value; }
	}
	
}