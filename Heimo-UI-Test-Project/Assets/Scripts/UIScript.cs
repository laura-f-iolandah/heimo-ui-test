using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement sectionMenu;

    private VisualElement containerCategories;
    private VisualElement containerCardOptions;

    private MenuScript menuScript;
    private CategoriesScript categoriesScript;
    private OptionsScript optionsScript;
    private HeaderScript headerScript;

    private Label labelTicket;
    private Button buttonTicket;
    private Label labelCoins;
    private Button buttonCoins;
    private Label titleOptions;



    private void Awake()
    {
        sectionMenu = uiDocument.rootVisualElement.Q<VisualElement>("sectionMenu");
        containerCategories = uiDocument.rootVisualElement.Q<VisualElement>("containerCategories");
        containerCardOptions = uiDocument.rootVisualElement.Q<VisualElement>("containerCardsOptions");
        labelTicket = uiDocument.rootVisualElement.Q<Label>("labelTicket");
        buttonTicket = uiDocument.rootVisualElement.Q<Button>("buttonTickets");
        labelCoins = uiDocument.rootVisualElement.Q<Label>("labelCoins");
        buttonCoins = uiDocument.rootVisualElement.Q<Button>("buttonCoins");
        titleOptions = uiDocument.rootVisualElement.Q<Label>("titleOptions");

        menuScript = new MenuScript(sectionMenu);
        categoriesScript = new CategoriesScript(containerCategories);
        optionsScript = new OptionsScript(containerCardOptions, categoriesScript, menuScript, titleOptions);
        headerScript = new HeaderScript(labelTicket, buttonTicket, labelCoins, buttonCoins);

        menuScript.InitializeMenu();
        categoriesScript.InitializeCategoriesMenu();
        optionsScript.InitializeOptions();
    }

}
