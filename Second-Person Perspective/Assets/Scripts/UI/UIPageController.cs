using System.Collections.Generic;
using UnityEngine;

public class UIPageController : MonoBehaviour
{
    [Header("All Pages In This Scene")]
    [SerializeField] private List<GameObject> pages = new List<GameObject>();

    [Header("Default First Page")]
    [SerializeField] private GameObject defaultPage;

    private void Awake()
    {
        // 运行时检查 pages 里有没有空引用，避免后面切页时报错
        for (int i = pages.Count - 1; i >= 0; i--)
        {
            if (pages[i] == null)
            {
                Debug.LogWarning($"[UIPageController] pages 列表里有空对象，索引: {i}", this);
                pages.RemoveAt(i);
            }
        }
    }

    private void Start()
    {
        // 启动时只显示默认页
        if (defaultPage != null)
        {
            ShowOnly(defaultPage);
        }
        else
        {
            Debug.LogWarning("[UIPageController] 没有设置 defaultPage，启动时不会自动切页。", this);
        }
    }

    // 隐藏所有页面
    public void HideAll()
    {
        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i] != null)
            {
                pages[i].SetActive(false);
            }
        }
    }

    // 只显示目标页面，其余全部隐藏
    public void ShowOnly(GameObject targetPage)
    {
        if (targetPage == null)
        {
            Debug.LogWarning("[UIPageController] ShowOnly 失败：targetPage 是空的。", this);
            return;
        }

        for (int i = 0; i < pages.Count; i++)
        {
            if (pages[i] != null)
            {
                pages[i].SetActive(pages[i] == targetPage);
            }
        }
    }

    // 单独显示某个页面，不影响其他页
    public void ShowPage(GameObject targetPage)
    {
        if (targetPage == null)
        {
            Debug.LogWarning("[UIPageController] ShowPage 失败：targetPage 是空的。", this);
            return;
        }

        targetPage.SetActive(true);
    }

    // 单独隐藏某个页面
    public void HidePage(GameObject targetPage)
    {
        if (targetPage == null)
        {
            Debug.LogWarning("[UIPageController] HidePage 失败：targetPage 是空的。", this);
            return;
        }

        targetPage.SetActive(false);
    }

    // 从一个页面切到另一个页面
    // 常用于按钮直接绑定：关掉当前页，打开目标页
    public void SwitchPage(GameObject fromPage, GameObject toPage)
    {
        if (fromPage == null || toPage == null)
        {
            Debug.LogWarning("[UIPageController] SwitchPage 失败：fromPage 或 toPage 为空。", this);
            return;
        }

        fromPage.SetActive(false);
        toPage.SetActive(true);
    }
}
