using UnityEngine;


public class ParticleHelperScript : MonoBehaviour
{
    public static ParticleHelperScript Instance;

    public ParticleSystem ExplosionEffect;

    void Awake(){
        Instance = this;
    }

    public void Explosion(Vector3 position, int colorId) {

        Color c;
        if (colorId == 0)
            c = new Color(0.6f, 0f, 0f,  1f);
        else
            c = new Color(0f, 0f, 0.6f, 1f);

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
