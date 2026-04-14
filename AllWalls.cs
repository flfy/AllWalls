using Il2Cpp;
using MelonLoader;

[assembly: MelonInfo(typeof(AllWalls.AllWallsMod), "AllWalls", "1.0.1", "derrick")]
[assembly: MelonGame("Waseku", "Data Center")]

namespace AllWalls
{
	public sealed class AllWallsMod : MelonMod
	{
		public const string ModName = "AllWalls";
		
		public override void OnInitializeMelon()
		{
			LoggerInstance.Msg("Will unlock all walls in all saves.");
		}

		public override void OnUpdate()
		{
			var walls = UnityEngine.Object.FindObjectsOfType<Wall>();
			if (walls == null || walls.Length == 0)
			{
				return;
			}

			var gameManager = MainGameManager.instance;
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

			LoggerInstance.Msg($"Unlocked {unlocked} wall section{(unlocked != 1 ? "s" : "")}.");
		}
	}
}
