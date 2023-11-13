using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CookingMaster
{
	public enum FoodItemName
	{
		None,
		Apple,
		Banana,
		PineApple,
		Graps,
		Pear,
		Watermalon
	}

	public interface IPickupItems
	{
		public Player player { get; }
		public PlayerPickUpManager manager { get; }
	}
}
