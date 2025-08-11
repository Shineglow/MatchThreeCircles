using System.Collections;
using com.shineglow.di.Runtime;
using Gameplay.Balls;
using Infrastructure.Factories.BallsFactory;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Spawners
{
    public class BallSpawner : MonoBehaviour
    {
        private IBallFactory _ballsFactory;
        private (GameObject obj, Rigidbody2D rb2d, CircleCollider2D collider) currentBall;
        private Coroutine _dropBallAsync;

        [Inject]
        public void Construct(IBallFactory ballsFactory)
        {
            _ballsFactory = ballsFactory;
            CreateNewBall();
        }

        private void Update()
        {
            SyncTransform();
        }

        public void TryDropBall()
        {
            if(_dropBallAsync == null)
                _dropBallAsync = StartCoroutine(DropBallAsync());
        }

        private IEnumerator DropBallAsync()
        {
            DropBall();
            yield return new WaitForSeconds(0.5f);
            CreateNewBall();
            _dropBallAsync = null;
        }

        private void DropBall()
        {
            currentBall.obj.GetComponent<BallFallChecker>().SetDropped();
            currentBall.rb2d.bodyType = RigidbodyType2D.Dynamic;
            currentBall.rb2d.gravityScale = 1;
            currentBall.collider.enabled = true;
            currentBall = default;
        }

        private async void CreateNewBall()
        {
            var ball = await _ballsFactory.GetRandomBall();
            FillCurrentBall(ball);
            currentBall.rb2d.bodyType = RigidbodyType2D.Kinematic;
            currentBall.collider.enabled = false;
            SyncTransform();
        }

        private void FillCurrentBall(GameObject ball)
        {
            currentBall.obj = ball;
            currentBall.rb2d = ball.GetComponent<Rigidbody2D>();
            currentBall.collider = ball.GetComponent<CircleCollider2D>();
        }

        private void SyncTransform()
        {
            if (!currentBall.obj) return;
            currentBall.obj.transform.position = transform.position;
            currentBall.obj.transform.rotation = transform.rotation;
        }
    }
}
