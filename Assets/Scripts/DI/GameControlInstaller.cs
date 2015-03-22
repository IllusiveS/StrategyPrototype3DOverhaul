using UnityEngine;
using System.Collections;
using AdvancedInspector;
using Zenject;

[AdvancedInspector]
public class GameControlInstaller : MonoInstaller {

	[Inspect]
	public GameObject gameControlPrefab;

	public override void InstallBindings()
	{
		Container.Bind<GameControl> ().ToSingleFromPrefab<GameControl> (gameControlPrefab);
	}
}
