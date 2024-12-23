using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement sectionMenu;

    private VisualElement containerCategories;

    private MenuScript menuScript;

    private CategoriesScript categoriesScript;

    private void Awake()
    {

        sectionMenu = uiDocument.rootVisualElement.Q<VisualElement>("sectionMenu");

        containerCategories = uiDocument.rootVisualElement.Q<VisualElement>("containerCategories");

        categoriesScript = new CategoriesScript(containerCategories);

        menuScript = new MenuScript(sectionMenu);

        menuScript.InitializeMenu();

        categoriesScript.InitializeCategoriesMenu();
    }
}
