using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;
using UnityEngine;

public class ImageTrackerManager : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager trackerManager;
    [SerializeField]
    private GameObject[] prefabs;

    private GameObject spawnedObject;

    private void OnEnable()
    {
        trackerManager.trackedImagesChanged += OnImageChanged;
    }

    private void OnDisable()
    {
        trackerManager.trackedImagesChanged -= OnImageChanged;
    }

    private void OnImageChanged(ARTrackedImagesChangedEventArgs args)
    {
        var trackedImage = args.updated[0];
        if (trackedImage.trackingState == UnityEngine.XR.ARSubsystems.TrackingState.Tracking)
        {
            if (spawnedObject == null)
            {
                int index = GetImageCount(trackedImage.referenceImage.name) - 1;
                spawnedObject = Instantiate(prefabs[index], trackedImage.transform.position,
                    trackedImage.transform.rotation);
            }else
            {
                spawnedObject.transform.position = trackedImage.transform.position;
            }
        }else
        {
            Destroy(spawnedObject);
        }
    }

    private int GetImageCount(string imageName)
    {
        string[] value = imageName.Split("_");
        return int.Parse(value[1]);
    }
}
