using UnityEngine;

public class Example : MonoBehaviour
{
	private EnemyService _enemyService;
	private DestroyCondition _destroyCondition;

	private void Awake()
	{
		_enemyService = new EnemyService();
	}

	private void Update()
	{
		_enemyService.Update(Time.deltaTime);
		Debug.Log("Количество врагов: " + _enemyService.EnemiesCount);

		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			_destroyCondition = new DestroyCondition(DestroyType.IsDead);
			Enemy enemy = new Enemy(_destroyCondition);

			_enemyService.Add(enemy);
		}

		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			_destroyCondition = new DestroyCondition(DestroyType.TimeIsOver);
			Enemy enemy = new Enemy(_destroyCondition);

			_enemyService.Add(enemy);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			_destroyCondition = new DestroyCondition(DestroyType.MaxCount);
			Enemy enemy = new Enemy(_destroyCondition);

			_enemyService.Add(enemy);
		}
	}
}
