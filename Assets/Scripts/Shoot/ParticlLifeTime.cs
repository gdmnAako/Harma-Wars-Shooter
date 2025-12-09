using UnityEngine;

public class ParticlLifeTime : MonoBehaviour
{
    private ParticleSystem partSys;

    public void SetSartLifeTime()
    {
        partSys = GetComponent<ParticleSystem>();
        partSys.Stop();

        var particlMainSettings = partSys.main;
        particlMainSettings.startLifetime = 2f; 
        
        partSys.Play();
    }
}
