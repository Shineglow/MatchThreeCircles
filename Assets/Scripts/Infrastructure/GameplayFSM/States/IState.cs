using System.Threading.Tasks;

namespace Infrastructure.GameplayFSM.States
{
	public interface IState
	{
		void Exit();
		void Enter();
	}
}