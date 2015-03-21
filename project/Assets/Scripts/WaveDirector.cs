using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveDirector : MonoBehaviour {

	[System.Serializable]
	public class KeyFrame
    {
		[HideInInspector] public bool kf_switch = true;
        public float seconds;

		public bool Timeline(float baseTime)
        {
			if( Time.time > baseTime + seconds )
			{
				if( kf_switch )
				{
					kf_switch = false;
					return true;
				}
			}
			return false;
        }
    }

	[System.Serializable]
	public class SpawningKeyframe : KeyFrame
    {
		public EnemySpawner[] spawners;
        public void SetActiveAllSpawners(bool active) { foreach (EnemySpawner s in spawners) { s.gameObject.SetActive(active); } }
        public void DeactivateAllSpawners() { SetActiveAllSpawners(false); }
        public void ActivateAllSpawners() { SetActiveAllSpawners(true); }
	}

	// nube y se cambia el sprite a vampiros
    public KeyFrame transformation;

	// las personas que estaban en el bar se convierten en vampiros
    public KeyFrame firstWave;

	// se spawnean enemigos continuamente desde las ventanas
    public SpawningKeyframe secondWave;

	// ... espera ...
	public KeyFrame secondRelax;

	// spawn continuo desde la puerta
    public SpawningKeyframe thirdWave;

    float baseTime;
    bool isPlaying;

	// Use this for initialization
	void Start () {
        baseTime = Time.time;
        isPlaying = false;
        Play();
	}

	public void Play()
    {
		baseTime = Time.time;
        isPlaying = true;
    }
	
	// Update is called once per frame
	void Update () {
        if (isPlaying)
        {
			// REVERSE ORDER
            if (thirdWave.Timeline(baseTime))
            {
                Debug.Log("OH SHIT NOT AGAIN!");
				thirdWave.ActivateAllSpawners();
			}
			else if( secondRelax.Timeline(baseTime) )
            {
                Debug.Log("Phew, it seems they stopped spawning...");
				secondWave.DeactivateAllSpawners();
			}
			else if( secondWave.Timeline(baseTime) )
            {
                Debug.Log("they're coming from the windows!");
				secondWave.ActivateAllSpawners();
			}
			else if( firstWave.Timeline(baseTime) )
            {
                Debug.Log("OMG OMG OMG!");
				TurnEnemiesAggresive();
			}
			else if( transformation.Timeline(baseTime) )
            {
                Debug.Log("look! these rednecks are turning into vampires!");
				HumanToVampireTransformation();
			}
        }
	}

    private void HumanToVampireTransformation()
    {
        Debug.Log("HumanToVampireTransformation");
    }

    private void TurnEnemiesAggresive()
    {
        Debug.Log("TurnEnemiesAggresive");
    }
}
