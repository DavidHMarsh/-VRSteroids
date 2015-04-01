using UnityEngine;
using System.Collections;

public class StaticDetonatorBurstEmitter : MonoBehaviour
{
    private ParticleEmitter _particleEmitter;
    private ParticleRenderer _particleRenderer;
    private ParticleAnimator _particleAnimator;

    public float size;
    public float particleSize;
    public float sizeVariation;
    public Color color;

    //unused
    
    public void Awake()
    {
        _particleEmitter = (gameObject.GetComponent("EllipsoidParticleEmitter")) as ParticleEmitter;
        _particleRenderer = (gameObject.GetComponent("ParticleRenderer")) as ParticleRenderer;
        _particleAnimator = (gameObject.GetComponent("ParticleAnimator")) as ParticleAnimator;

        _particleEmitter.Emit();

    }
    
    

}
