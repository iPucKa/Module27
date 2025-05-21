using UnityEngine;

public class Example : MonoBehaviour
{
	private const int MaxCount = 10;
	private const float MaxTime = 10;

	private EnemyService _enemyService;
	private float _time;

	private void Awake()
	{
		_enemyService = new EnemyService();
	}

	private void Update()
	{
		_time += Time.deltaTime;

		_enemyService.Update(Time.deltaTime);
		Debug.Log("Количество врагов: " + _enemyService.EnemiesCount);

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			Enemy enemy = new Enemy();

			_enemyService.AddEnemyTo(enemy, () => enemy.IsDead == true);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			Enemy enemy = new Enemy();

			_enemyService.AddEnemyTo(enemy, () => _time > MaxTime);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Enemy enemy = new Enemy();

			_enemyService.AddEnemyTo(enemy, () => _enemyService.EnemiesCount > MaxCount);
		}
	}	
}
