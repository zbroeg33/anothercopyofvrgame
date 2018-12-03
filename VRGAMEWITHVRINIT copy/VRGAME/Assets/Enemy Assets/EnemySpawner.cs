using UnityEngine;
using UnityEngine.Networking;

public class EnemySpawner : NetworkBehaviour {

	public GameObject enemyPrefab;
    public GameObject pickupPrefab;
   

    public GameObject fogPrefab;

   
    public int numberOfEnemies;
    public int numberOfPickups;

   

    public int Fog;

    public override void OnStartServer()
    {
        for (int i=0; i < numberOfEnemies; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(0.0f, 500.0f),
                0.0f,
                Random.Range(0.0f, 500.0f));

            var spawnRotation = Quaternion.Euler( 
                0.0f, 
                Random.Range(0,180), 
                0.0f);

            var enemy = (GameObject)Instantiate(enemyPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(enemy);
        }

        

        for (int i=0; i < numberOfPickups; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(0.0f, 500.0f),
                0.0f,
                Random.Range(0.0f, 500.0f));

            var spawnRotation = Quaternion.Euler( 
                0.0f, 
                Random.Range(0,180), 
                0.0f);

            var pickup = (GameObject)Instantiate(pickupPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(pickup);
        }

        for (int i=0; i < Fog; i++)
        {
            var spawnPosition = new Vector3(
                Random.Range(0.0f, 500.0f),
                1.0f,
                Random.Range(0.0f, 500.0f));

            var spawnRotation = Quaternion.Euler( 
                2.0f, 
                Random.Range(0,180), 
                0.0f);

            var fog = (GameObject)Instantiate(fogPrefab, spawnPosition, spawnRotation);
            NetworkServer.Spawn(fog);
        }

       
        
    }
}
