using UnityEngine;

public class Example : MonoBehaviour
{
	private EnemyService _enemyService;
	private Enemy _enemy;

	private void Awake()
	{
		_enemyService = new EnemyService();
	}

	private void Update()
	{
		Debug.Log("Число врагов: " + _enemyService.Count);

		_enemyService.Update(Time.deltaTime);

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Enemy enemy = new Enemy(DestroyTypeCondition.IsDead);

			_enemyService.Add(enemy);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Enemy enemy = new Enemy(DestroyTypeCondition.TimeIsOver);

			_enemyService.Add(enemy);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Enemy enemy = new Enemy(DestroyTypeCondition.MaxCount);

			_enemyService.Add(enemy);
		}
	}
}
