using UnityEngine;

public class ShaderActivate : MonoBehaviour
{
    public Material shaderMaterial;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ApplyShaderEffect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            RestoreOriginalMaterial();
        }
    }

    private void ApplyShaderEffect()
    {
        if (objRenderer != null && shaderMaterial != null)
        {
            objRenderer.material = shaderMaterial;
        }
    }

    private void RestoreOriginalMaterial()
    {
        if (objRenderer != null && originalMaterial != null)
        {
            objRenderer.material = originalMaterial;
        }
    }
}
