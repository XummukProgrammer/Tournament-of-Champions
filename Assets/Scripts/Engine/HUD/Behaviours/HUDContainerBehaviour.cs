using UnityEngine;

public class HUDContainerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _topContainer;
    [SerializeField] private Transform _sideLeftContainer;
    [SerializeField] private Transform _sideRightContainer;
    [SerializeField] private Transform _downContainer;

    public HUDBehaviour CreateBehaviour(HUDBehaviour prefab, HUDLocation location)
    {
        Transform container = null;
        switch (location)
        {
            case HUDLocation.Top:
                container = _topContainer;
                break;
            case HUDLocation.SideLeft:
                container = _sideLeftContainer;
                break;
            case HUDLocation.SideRight:
                container = _sideRightContainer;
                break;
            case HUDLocation.Down:
                container = _downContainer;
                break;
            default:
                break;
        }

        HUDBehaviour behaviour = null;
        if (container != null)
        {
            behaviour = Instantiate(prefab, container);
        }

        return behaviour;
    }
}
