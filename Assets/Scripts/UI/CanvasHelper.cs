using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Canvas))]
public class CanvasHelper : MonoBehaviour
{
    private static List<CanvasHelper> helpers = new List<CanvasHelper>();

    public static UnityEvent OnResolutionOrOrientationChanged = new UnityEvent();

    private static bool screenChangeVarsInitialized = false;
    private static ScreenOrientation lastOrientation = ScreenOrientation.LandscapeLeft;
    private static Vector2 lastResolution = Vector2.zero;
    private static Rect lastSafeArea = Rect.zero;

    private Canvas canvas;
    private RectTransform rectTransform;
    private SafeArea[] safeAreaTransforms;

    void Awake()
    {
        if (!helpers.Contains(this))
            helpers.Add(this);

        canvas = GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();

        FindSafeAreaTransforms();

        if (!screenChangeVarsInitialized)
        {
            lastOrientation = Screen.orientation;
            lastResolution.x = Screen.width;
            lastResolution.y = Screen.height;
            lastSafeArea = Screen.safeArea;

            screenChangeVarsInitialized = true;
        }

        ApplySafeArea();
    }

    private void FindSafeAreaTransforms()
    {
        GameObject[] safeAreas = GameObject.FindGameObjectsWithTag("Safe Area");
        safeAreaTransforms = new SafeArea[safeAreas.Length];
        int i = 0;
        foreach (var safeArea in safeAreas)
        {
            SafeArea safeAreaComponent = safeArea.GetComponent<SafeArea>();
            if (safeAreaComponent)
            {
                safeAreaTransforms[i] = safeAreaComponent;
            }
            else
            {
                Debug.LogError(safeArea.name + " needs a SafeArea component to use it as a safe area.");
            }
            i++;
        }
    }

    void Update()
    {
        if (helpers[0] != this)
            return;

        if (Application.isMobilePlatform && Screen.orientation != lastOrientation)
            OrientationChanged();

        if (Screen.safeArea != lastSafeArea)
            SafeAreaChanged();

        if (Screen.width != lastResolution.x || Screen.height != lastResolution.y)
            ResolutionChanged();
    }

    void ApplySafeArea()
    {
        var safeArea = Screen.safeArea;

        var anchorMin = safeArea.position;
        var anchorMax = safeArea.position + safeArea.size;
        anchorMin.x /= canvas.pixelRect.width;
        anchorMin.y /= canvas.pixelRect.height;
        anchorMax.x /= canvas.pixelRect.width;
        anchorMax.y /= canvas.pixelRect.height;

        foreach (var safeAreaObject in safeAreaTransforms)
        {
            if (!safeAreaObject)
            {
                continue;
            }

            RectTransform safeAreaRectTrasnform = (RectTransform)safeAreaObject.transform;

            if (!safeAreaObject.ApplySafeAreaMinX)
            {
                anchorMin.x = safeAreaRectTrasnform.anchorMin.x;
            }
            if (!safeAreaObject.ApplySafeAreaMaxX)
            {
                anchorMax.x = safeAreaRectTrasnform.anchorMax.x;
            }
            if (!safeAreaObject.ApplySafeAreaMinY)
            {
                anchorMin.y = safeAreaRectTrasnform.anchorMin.y;
            }
            if (!safeAreaObject.ApplySafeAreaMaxY)
            {
                anchorMax.y = safeAreaRectTrasnform.anchorMax.y;
            }
            safeAreaRectTrasnform.anchorMin = anchorMin;
            safeAreaRectTrasnform.anchorMax = anchorMax;
        }
    }

    void OnDestroy()
    {
        if (helpers != null && helpers.Contains(this))
            helpers.Remove(this);
    }

    private static void OrientationChanged()
    {
        //Debug.Log("Orientation changed from " + lastOrientation + " to " + Screen.orientation + " at " + Time.time);

        lastOrientation = Screen.orientation;
        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;

        OnResolutionOrOrientationChanged.Invoke();
    }

    private static void ResolutionChanged()
    {
        //Debug.Log("Resolution changed from " + lastResolution + " to (" + Screen.width + ", " + Screen.height + ") at " + Time.time);

        lastResolution.x = Screen.width;
        lastResolution.y = Screen.height;

        OnResolutionOrOrientationChanged.Invoke();
    }

    private static void SafeAreaChanged()
    {
        // Debug.Log("Safe Area changed from " + lastSafeArea + " to " + Screen.safeArea.size + " at " + Time.time);

        lastSafeArea = Screen.safeArea;

        for (int i = 0; i < helpers.Count; i++)
        {
            //Update the list of safe area transforms.
            helpers[i].FindSafeAreaTransforms();

            //Apply the safe area.
            helpers[i].ApplySafeArea();
        }
    }

    /// <summary>
    /// Call this to recalculate the safe area.
    /// </summary>
    public static void UpdateSafeArea()
    {
        SafeAreaChanged();
    }
}
