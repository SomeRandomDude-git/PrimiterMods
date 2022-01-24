using PrimitierModdingFramework;
using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnhollowerRuntimeLib;

namespace TestMod2
{
	public class TestMod2 : PrimitierMod
	{

		public float tick1 = Time.fixedTime;
		public float tick2 = 0.0f;
		public float health1 = 1000.0f;
		public float health2 = 1000.0f;
		public float delay = 0.0f;
		
		public bool isFed = false; // Im sure theres a way to use SelfHealing to do this but idk how to do it.
		public bool isActive = false;

		public override void OnUpdate()
		{
			base.OnUpdate();
			tick2 = Time.fixedTime;

			if (isFed == true)
			{
				if (tick1 < tick2 - 1.0f & PlayerLife.MaxLife < 2000.00f)
				{
					PlayerLife.MaxLife = PlayerLife.MaxLife + 2;
					tick1 = Time.fixedTime;
					health1 = PlayerLife.Life;
					delay = delay - 1.0f;
				}
			}

			if (isFed == false)
			{
				if (tick1 < tick2 - 30.0f & PlayerLife.MaxLife > 500.00f)
				{
					PlayerLife.MaxLife = PlayerLife.MaxLife - 1;
					PlayerLife.Life = PlayerLife.Life - 2;
					tick1 = Time.fixedTime;
					health1 = PlayerLife.Life;
				}
			}

			// Compares the players health to what it was before the above functions. If its higher, it will set isFed to true.
			health2 = PlayerLife.Life;
			if (health1 < health2)
			{
				delay = (health2 - health1) * 0.1f + 1.0f;
				isFed = true;
			}

			if (delay <= 0)
			{
				isFed = false;
			}
			
			// Checks if the player dies, resets their max health to default.
			if (PlayerLife.Life <= 0) 
			{
				PlayerLife.MaxLife = 1000.0f;
				health1 = 1000.0f;
				health2 = 1000.0f;
			}

		}
	}
}
