public class Currency
{
	private int _value;

	public Currency(CurrencyType type)
	{
		Type = type;
		_value = 0;
	}

	public CurrencyType Type { get; }
	public int Value => _value;

	public void SetValue(int value) => _value = value;
}
