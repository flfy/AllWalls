using Il2Cpp;
using MelonLoader;

using UnityEngine;
using UnityEngine.InputSystem;

[assembly: MelonInfo(typeof(AllWalls.AllWallsMod), "Unlock All", "1.0.0", "derrick")]

namespace AllWalls
{
	public sealed class AllWallsMod : MelonMod
	{
		public const string ModName = "AllWalls";

		public override void OnInitializeMelon()
		{
			MelonLogger.Msg($"{ModName}: Will unlock all walls in all saves.");
		}

		public override void OnUpdate()
		{
			var gameManager = MainGameManager.instance;
			if (gameManager == null || gameManager.loadingFirstTime || gameManager.walls == null)
			{
				return;
			}

			var walls = UnityEngine.Object.FindObjectsOfType<Wall>();
			if (walls == null || walls.Length == 0)
			{
				return;
			}

			var originalPrice = gameManager.wallPrice;
			var unlocked = 0;

			try
			{
				foreach (var wall in walls)
				{
					if (wall == null || wall.isWallOpened)
					{
						continue;
					}

					gameManager.wallToBuy = wall;

					gameManager.ButtonBuyWall();
					wall.OpenWall();

					unlocked++;
				}
			}
			finally
			{
				gameManager.wallPrice = originalPrice;
			}

			MelonLogger.Msg($"{ModName}: unlocked {unlocked} wall section(s).");
		}
	}
}
