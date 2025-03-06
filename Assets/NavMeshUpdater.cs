using UnityEngine;
using Unity.AI.Navigation;

public class NavMeshUpdater : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private NavMeshSurface navMeshSurface = null;

    void Start()
    {
        navMeshSurface.BuildNavMesh();
    }

    void Update()
    {
        navMeshSurface.UpdateNavMesh(navMeshSurface.navMeshData);
    }
}
