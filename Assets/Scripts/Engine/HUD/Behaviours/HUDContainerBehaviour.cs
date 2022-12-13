using UnityEngine;

public class HUDContainerBehaviour : MonoBehaviour
{
    [SerializeField] private Transform _topSideLeftContainer;
    [SerializeField] private Transform _topSideRightContainer;
    [SerializeField] private Transform _sideLeftContainer;
    [SerializeField] private Transform _sideRightContainer;
    [SerializeField] private Transform _downSideLeftContainer;
    [SerializeField] private Transform _downSideRightContainer;

    public HUDBehaviour CreateBehaviour(HUDBehaviour prefab, HUDLocation location)
    {
        Transform container = null;
        switch (location)
        {
            case HUDLocation.TopSideLeft:
                container = _topSideLeftContainer;
                break;
            case HUDLocation.TopSideRight:
                container = _topSideRightContainer;
                break;
            case HUDLocation.SideLeft:
                container = _sideLeftContainer;
                break;
            case HUDLocation.SideRight:
                container = _sideRightContainer;
                break;
            case HUDLocation.DownSideLeft:
                container = _downSideLeftContainer;
                break;
            case HUDLocation.DownSideRight:
                container = _downSideRightContainer;
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
