using System.Collections;
using UnityEngine;

public class ShaderActivate : MonoBehaviour
{
    public Material shaderMaterial;
    public float effectDuration = 3f;

    private Material originalMaterial;
    private Renderer objRenderer;

    private void Awake()
    {
        objRenderer = GetComponent<Renderer>();
        if (objRenderer != null)
        {
            originalMaterial = objRenderer.material;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            ApplyShaderEffect();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyShaderEffect();
        }
    }

    private void ApplyShaderEffect()
    {
        if (objRenderer != null && shaderMaterial != null)
        {
            objRenderer.material = shaderMaterial;
            StartCoroutine(RestoreMaterialAfterDelay());
        }
    }

    private IEnumerator RestoreMaterialAfterDelay()
    {
        yield return new WaitForSeconds(effectDuration);
        if (objRenderer != null && originalMaterial != null)
        {
            objRenderer.material = originalMaterial;
        }
    }
}
