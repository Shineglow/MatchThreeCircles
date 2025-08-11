using System;

namespace Infrastructure.GameplayFSM.States
{
	public class GameOverState : IState
	{
		public void Exit()
		{
			throw new NotImplementedException();
			// unbind restart button action
			// unbind back to menu button action
			// hide hud 
		}

		public void Enter()
		{
			throw new NotImplementedException();
			// show gameOver HUD
			// bind restart button action
			// bind back to menu button action
		}
	}
}