using UnityEngine;

namespace GDS.MenuSystem
{
	public class MenuSimple : MenuBase
	{

		#region Serialized fields

		[SerializeField] private GameObject menu;

		#endregion


		#region Public methods

		protected override void TurnOn(MenuType menuType)
		{
			base.TurnOn(menuType);
			menu.SetActive(true);
			TurnOnComplete(menuType);
		}

		protected override void TurnOff(MenuType menuType)
		{
			base.TurnOff(menuType);
			menu.SetActive(false);
			TurnOffComplete(menuType);
		}

		#endregion

	} 
}
