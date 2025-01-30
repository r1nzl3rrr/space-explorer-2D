using UnityEngine;

public class SceneScroller : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;
    Vector2 offset;
    Material material;

    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }
    
    void Update()
    {
        // Set material offset
        offset = moveSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
