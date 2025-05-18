public class DestroyCondition
{
	private DestroyType _type;
	private bool _isDead;

	private float _maxTime;
	private float _time;

	public DestroyCondition(DestroyType type)
	{
		_type = type;
		_isDead = false;
		_time = 0;
		_maxTime = 20;
	}

	public DestroyType Type => _type;
	public bool IsDead => _isDead;
	public bool TimeIsOver => _time > _maxTime;

	public void Kill() => _isDead = true;	

	public void SetTime() => _time = 100;
}
