using UnityEngine;


public class ParticleHelperScript : MonoBehaviour
{
    public static ParticleHelperScript Instance;

    public ParticleSystem ExplosionEffect;
    public ParticleSystem WinnerEffect;


    void Awake(){
        Instance = this;
    }

    public void Explosion(Vector3 position, int colorId) {

        Color c;
        if (colorId == 0)
            c = new Color(0.6f, 0.8f, 0.9f,  1f);
        else
            c = new Color(1f, 0.8f, 0.35f, 1f);

        instantiate(ExplosionEffect, position, c);

    }

    public void Winner(Vector3 position, int colorId)
    {

        Color c;
        if (colorId == 0)
            c = new Color(0.6f, 0.8f, 0.9f, 1f);
        else
            c = new Color(1f, 0.8f, 0.35f, 1f);

        instantiateLoop(WinnerEffect, position, c);

    }

private ParticleSystem instantiateLoop(ParticleSystem prefab, Vector3 position, Color c){

        ParticleSystem newParticleSystem = Instantiate(
          prefab,
          position,
          Quaternion.identity
        ) as ParticleSystem;

        newParticleSystem.startColor = c;

        return newParticleSystem;
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
