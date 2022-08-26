using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public ConveyorBelt ConveyorBeltScript;
    public ObjectSpawner ObjectSpawnerScript;
    public Slingshot SlingshotScript;

    public void Pause(bool pauseGame)
    {
        ConveyorBeltScript.GamePause(pauseGame);
        ConveyorBeltScript.enabled = !pauseGame;
        ObjectSpawnerScript.enabled = !pauseGame;
        SlingshotScript.enabled = !pauseGame;
    }
}
