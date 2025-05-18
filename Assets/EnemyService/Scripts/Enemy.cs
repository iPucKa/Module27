public class Enemy
{
	private DestroyCondition _destroyCondition;	

	public Enemy(DestroyCondition destroyCondition)
	{
		_destroyCondition = destroyCondition;
	}

	public DestroyType Type => _destroyCondition.Type;
	public bool IsDead => _destroyCondition.IsDead;
	public bool TimeIsOver => _destroyCondition.TimeIsOver;
}
