using UnityEngine;

namespace GDS.MenuSystem
{
	public class MenuBase : MonoBehaviour
	{

		#region Serialzied fields

		[SerializeField] private MenuType menuType;

		#endregion


		#region Properties

		public MenuType Menu { get => menuType; }

		#endregion


		#region Events

		public delegate void MenuSwitch(MenuType menuType);
		public static event MenuSwitch OnMenuTurnOnComplete;
		public static event MenuSwitch OnMenuTurnOffComplete;

		#endregion


		#region Private methods

		private void TurnOnStart(MenuType menuType)
		{
			if (this.menuType == menuType)
			{
				TurnOn(menuType);
			}
		}	

		private void TurnOffStart(MenuType menuType)
		{
			if (this.menuType == menuType)
			{
				TurnOff(menuType);
			}
		}

		#endregion


		#region Public methods

		protected virtual void TurnOn(MenuType menuType)
		{
			
		}

		protected virtual void TurnOff(MenuType menuType)
		{
			
		}

		protected void TurnOnComplete(MenuType menuType)
		{
			OnMenuTurnOnComplete?.Invoke(menuType);
		}

		protected void TurnOffComplete(MenuType menuType)
		{
			OnMenuTurnOffComplete?.Invoke(menuType);
		}

		#endregion


		#region Unity methods

		private void OnEnable()
		{
			MenusController.OnMenuTurnOffStart += TurnOffStart;
			MenusController.OnMenuTurnOnStart += TurnOnStart;
		}

		private void OnDisable()
		{
			MenusController.OnMenuTurnOffStart -= TurnOffStart;
			MenusController.OnMenuTurnOnStart -= TurnOnStart;
		}

		#endregion
	} 
}
