using UnityEngine;

public class TestExample : MonoBehaviour
{
	[SerializeField] private WalletView _walletView;

	private const int MaxAmount = 100;

	private Wallet _wallet;

	private Currency _coin;
	private Currency _diamond;
	private Currency _energie;

	private void Awake()
	{
		_wallet = new Wallet(MaxAmount);
		_walletView.Initialize(_wallet);

		_coin = new Currency(CurrencyType.Coins);
		_diamond = new Currency(CurrencyType.Diamonds);
		_energie = new Currency(CurrencyType.Energie);
	}	

	private void Update()
	{

		if (Input.GetKeyDown(KeyCode.Alpha1))		
			_wallet.Add(_coin, 15);		

		if (Input.GetKeyDown(KeyCode.Alpha2))		
			_wallet.Remove(_coin, 3);		

		if (Input.GetKeyDown(KeyCode.Alpha3))
			_wallet.Add(_diamond, 10);

		if (Input.GetKeyDown(KeyCode.Alpha4))
			_wallet.Remove(_diamond, 2);

		if (Input.GetKeyDown(KeyCode.Alpha5))
			_wallet.Add(_energie, 5);

		if (Input.GetKeyDown(KeyCode.Alpha6))
			_wallet.Remove(_energie, 1);
	}

	public void ShowWallet() => _walletView.gameObject.SetActive(true);

	public void CloseWallet() => _walletView.gameObject.SetActive(false);
}
