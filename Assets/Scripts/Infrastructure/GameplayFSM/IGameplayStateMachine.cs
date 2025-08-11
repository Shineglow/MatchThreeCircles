using Infrastructure.GameplayFSM.States;

namespace Infrastructure.GameplayFSM
{
	public interface IGameplayStateMachine
	{
		void Enter<TState>() where TState : IState;
	}
}