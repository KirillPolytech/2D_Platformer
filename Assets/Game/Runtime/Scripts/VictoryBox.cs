using Game.Runtime.Scripts.EventBusThings;
using Game.Runtime.Scripts.PlayerLogic;
using UnityEngine;
using Zenject;

public class VictoryBox : MonoBehaviour
{
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player _player = other.gameObject.GetComponent<Player>();

        if (!_player)
            return;

        _signalBus.Fire<VictorySignal>();
    }
}