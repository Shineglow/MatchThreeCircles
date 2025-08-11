using System;
using System.Collections.Generic;
using Infrastructure.DI;
using Infrastructure.GameplayFSM.States;

namespace Infrastructure.GameplayFSM
{
	public class GameplayStateMachine : IGameplayStateMachine
	{
		private readonly IResolver _resolver;
		private readonly Dictionary<Type, IState> _states;
		private IState _currentState;

		public GameplayStateMachine(DIResolverWrapper resolver)
		{
			resolver.Bind<IResolver>().AsInstance(resolver);
			resolver.Bind<DIResolverWrapper>().AsInstance(resolver);
			BindStates(resolver);
			resolver.Bind<IGameplayStateMachine>().AsInstance(this);
			_resolver = resolver;
			_states = new Dictionary<Type, IState>();
		}

		private static void BindStates(DIResolverWrapper resolver)
		{
			resolver.Bind<BootstrapState>().To<BootstrapState>().IsCachingInstance();
			resolver.Bind<StartGameState>().To<StartGameState>().IsCachingInstance();
			resolver.Bind<GameplayMainState>().To<GameplayMainState>().IsCachingInstance();
			resolver.Bind<GameOverState>().To<GameOverState>().IsCachingInstance();
		}

		public void Enter<TState>() where TState : IState
		{
			_currentState?.Exit();
			_currentState = GetState<TState>();
			_currentState?.Enter();
		}

		private IState GetState<TState>() where TState : IState
		{
			if (!_states.TryGetValue(typeof(TState), out var state))
			{
				state = _resolver.Resolve<TState>();
				_states.Add(typeof(TState), state);
			}
			return state;
		}
	}
}