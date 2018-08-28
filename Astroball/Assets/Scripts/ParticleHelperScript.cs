using UnityEngine;


public class ParticleHelperScript : MonoBehaviour
{
    public static ParticleHelperScript Instance;

    public ParticleSystem ExplosionEffect;

    void Awake(){
        Instance = this;
    }

    public void Explosion(Vector3 position, Color c){

        instantiate(ExplosionEffect, position, c);

    }
   
    private ParticleSystem instantiate(ParticleSystem prefab, Vector3 position, Color c){

        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        // Make sure it will be destroyed
        Destroy(
          newParticleSystem.gameObject,
          newParticleSystem.startLifetime
        );

        newParticleSystem.startColor = c;

        return newParticleSystem;
    }
}
