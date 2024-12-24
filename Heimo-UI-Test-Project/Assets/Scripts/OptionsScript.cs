using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

public class OptionsScript
{
    private VisualElement containerOptions;
    private Dictionary<string, Texture2D> imageCache = new Dictionary<string, Texture2D>();
    private Button lastSelectedButton;
    private Color lastSelectedButtonColor;
    private Label titleOptions;
    private CategoriesScript categoriesScript;
    private MenuScript menuScript;
    private Dictionary<string, Option> lastSelectedMenuOptions = new Dictionary<string, Option>();

    private readonly Dictionary<string, Option[]> optionsDict = new Dictionary<string, Option[]>
    {
        { "Skins", new Option[] {
            new Option {name = "Kart", labelTag = "EPIC", imagePath = "Sprites/Options/Skins/KartSmall", backgroundColor = "#0072FF"},
            new Option {name = "Kart-2", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Skins/KartSmall2", backgroundColor = "#00EB90"},
            new Option {name = "Kart-3", labelTag = "RARE", imagePath = "Sprites/Options/Skins/KartSmall3", backgroundColor = "#EBA316"},
            new Option {name = "Kart-4", labelTag = "COMMON", imagePath = "Sprites/Options/Skins/KartSmall4", backgroundColor = "#5224D6"},
            new Option {name = "Kart-5", labelTag = "SPECIAL", imagePath = "Sprites/Options/Skins/KartSmall2", backgroundColor = "#F32650"},
            new Option {name = "Kart-6", labelTag = "UNIQUE", imagePath = "Sprites/Options/Skins/KartSmall", backgroundColor = "#C4C4C4"},
            new Option {name = "Kart-7", labelTag = "EPIC", imagePath = "Sprites/Options/Skins/KartSmall4", backgroundColor = "#0072FF"},
            new Option {name = "Kart-8", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Skins/KartSmall3", backgroundColor = "#00EB90"},
            new Option {name = "Kart-9", labelTag = "RARE", imagePath = "Sprites/Options/Skins/KartSmall4", backgroundColor = "#EBA316"},
            new Option {name = "Kart-10", labelTag = "COMMON", imagePath = "Sprites/Options/Skins/KartSmall3", backgroundColor = "#5224D6"},
            new Option {name = "Kart-11", labelTag = "SPECIAL", imagePath = "Sprites/Options/Skins/KartSmall2", backgroundColor = "#F32650"},
            new Option {name = "Kart-12", labelTag = "UNIQUE", imagePath = "Sprites/Options/Skins/KartSmall", backgroundColor = "#C4C4C4"},
        } },

        { "Color", new Option[] {
            new Option {name = "Colors-2", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Colors/Colors2", backgroundColor = ""},
            new Option {name = "Colors-4", labelTag = "COMMON", imagePath = "Sprites/Options/Colors/Colors4", backgroundColor = ""},
            new Option {name = "Colors-6", labelTag = "UNIQUE", imagePath = "Sprites/Options/Colors/Colors6", backgroundColor = ""},
            new Option {name = "Colors-7", labelTag = "EPIC", imagePath = "Sprites/Options/Colors/Colors6", backgroundColor = ""},
            new Option {name = "Colors-9", labelTag = "RARE", imagePath = "Sprites/Options/Colors/Colors4", backgroundColor = "#"},
            new Option {name = "Colors-11", labelTag = "SPECIAL", imagePath = "Sprites/Options/Colors/Colors2", backgroundColor = "#"},
            new Option {name = "Colors", labelTag = "blue", imagePath = "", backgroundColor = "#0072FF"},
            new Option {name = "Colors-3", labelTag = "orange", imagePath = "", backgroundColor = "#EBA316"},
            new Option {name = "Colors-5", labelTag = "pink", imagePath = "", backgroundColor = "#F32650"},
            new Option {name = "Colors-8", labelTag = "green", imagePath = "", backgroundColor = "#00EB90"},
            new Option {name = "Colors-12", labelTag = "gray", imagePath = "", backgroundColor = "#C4C4C4"},
            new Option {name = "Colors-10", labelTag = "purple", imagePath = "", backgroundColor = "#5224D6"},

        } },

        { "Wheels", new Option[] {  
            new Option {name = "Wheels", labelTag = "EPIC", imagePath = "Sprites/Options/Wheels/Wheels", backgroundColor = "#0072FF"},
            new Option {name = "Wheels-2", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Wheels/Wheels2", backgroundColor = "#00EB90"},
            new Option {name = "Wheels-3", labelTag = "RARE", imagePath = "Sprites/Options/Wheels/Wheels3", backgroundColor = "#EBA316"},
            new Option {name = "Wheels-4", labelTag = "COMMON", imagePath = "Sprites/Options/Wheels/Wheels4", backgroundColor = "#5224D6"},
            new Option {name = "Wheels-5", labelTag = "SPECIAL", imagePath = "Sprites/Options/Wheels/Wheels5", backgroundColor = "#F32650"},
            new Option {name = "Wheels-6", labelTag = "UNIQUE", imagePath = "Sprites/Options/Wheels/Wheels6", backgroundColor = "#C4C4C4"},
            new Option {name = "Wheels-7", labelTag = "EPIC", imagePath = "Sprites/Options/Wheels/Wheels6", backgroundColor = "#0072FF"},
            new Option {name = "Wheels-8", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Wheels/Wheels5", backgroundColor = "#00EB90"},
            new Option {name = "Wheels-9", labelTag = "RARE", imagePath = "Sprites/Options/Wheels/Wheels4", backgroundColor = "#EBA316"},
            new Option {name = "Wheels-10", labelTag = "COMMON", imagePath = "Sprites/Options/Wheels/Wheels3", backgroundColor = "#5224D6"},
            new Option {name = "Wheels-11", labelTag = "SPECIAL", imagePath = "Sprites/Options/Wheels/Wheels2", backgroundColor = "#F32650"},
            new Option {name = "Wheels-12", labelTag = "UNIQUE", imagePath = "Sprites/Options/Wheels/Wheels", backgroundColor = "#C4C4C4"},
        } },

        { "Accessories", new Option[] {         
            new Option {name = "Accessories", labelTag = "EPIC", imagePath = "Sprites/Options/Accessories/Accessories", backgroundColor = "#0072FF"},
            new Option {name = "Accessories-2", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Accessories/Accessories2", backgroundColor = "#00EB90"},
            new Option {name = "Accessories-3", labelTag = "RARE", imagePath = "Sprites/Options/Accessories/Accessories3", backgroundColor = "#EBA316"},
            new Option {name = "Accessories-4", labelTag = "COMMON", imagePath = "Sprites/Options/Accessories/Accessories4", backgroundColor = "#5224D6"},
            new Option {name = "Accessories-5", labelTag = "SPECIAL", imagePath = "Sprites/Options/Accessories/Accessories5", backgroundColor = "#F32650"},
            new Option {name = "Accessories-6", labelTag = "UNIQUE", imagePath = "Sprites/Options/Accessories/Accessories6", backgroundColor = "#C4C4C4"},
            new Option {name = "Accessories-7", labelTag = "EPIC", imagePath = "Sprites/Options/Accessories/Accessories6", backgroundColor = "#0072FF"},
            new Option {name = "Accessories-8", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Accessories/Accessories5", backgroundColor = "#00EB90"},
            new Option {name = "Accessories-9", labelTag = "RARE", imagePath = "Sprites/Options/Accessories/Accessories4", backgroundColor = "#EBA316"},
            new Option {name = "Accessories-10", labelTag = "COMMON", imagePath = "Sprites/Options/Accessories/Accessories3", backgroundColor = "#5224D6"},
            new Option {name = "Accessories-11", labelTag = "SPECIAL", imagePath = "Sprites/Options/Accessories/Accessories2", backgroundColor = "#F32650"},
            new Option {name = "Accessories-12", labelTag = "UNIQUE", imagePath = "Sprites/Options/Accessories/Accessories", backgroundColor = "#C4C4C4"}, 
        } },

        { "Bumpers", new Option[] {         new Option {name = "Bumpers", labelTag = "EPIC", imagePath = "Sprites/Options/Bumpers/Bumpers", backgroundColor = "#0072FF"},
            new Option {name = "Bumpers-2", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Bumpers/Bumpers2", backgroundColor = "#00EB90"},
            new Option {name = "Bumpers-3", labelTag = "RARE", imagePath = "Sprites/Options/Bumpers/Bumpers3", backgroundColor = "#EBA316"},
            new Option {name = "Bumpers-4", labelTag = "COMMON", imagePath = "Sprites/Options/Bumpers/Bumpers4", backgroundColor = "#5224D6"},
            new Option {name = "Bumpers-5", labelTag = "SPECIAL", imagePath = "Sprites/Options/Bumpers/Bumpers5", backgroundColor = "#F32650"},
            new Option {name = "Bumpers-6", labelTag = "UNIQUE", imagePath = "Sprites/Options/Bumpers/Bumpers6", backgroundColor = "#C4C4C4"},
            new Option {name = "Bumpers-7", labelTag = "EPIC", imagePath = "Sprites/Options/Bumpers/Bumpers6", backgroundColor = "#0072FF"},
            new Option {name = "Bumpers-8", labelTag = "LEGENDARY", imagePath = "Sprites/Options/Bumpers/Bumpers5", backgroundColor = "#00EB90"},
            new Option {name = "Bumpers-9", labelTag = "RARE", imagePath = "Sprites/Options/Bumpers/Bumpers4", backgroundColor = "#EBA316"},
            new Option {name = "Bumpers-10", labelTag = "COMMON", imagePath = "Sprites/Options/Bumpers/Bumpers3", backgroundColor = "#5224D6"},
            new Option {name = "Bumpers-11", labelTag = "SPECIAL", imagePath = "Sprites/Options/Bumpers/Bumpers2", backgroundColor = "#F32650"},
            new Option {name = "Bumpers-12", labelTag = "UNIQUE", imagePath = "Sprites/Options/Bumpers/Bumpers", backgroundColor = "#C4C4C4"},
        } },

        { "Spoiler", new Option[] { new Option { name = "Spoiler", labelTag = "EPIC", imagePath = "Sprites/Options/Bumpers/Bumpers3", backgroundColor = "#0072FF" } } }
    };

    public OptionsScript(VisualElement container, CategoriesScript categories, MenuScript menu, Label titleOptionsLabel)
    {
        containerOptions = container;
        categoriesScript = categories;
        menuScript = menu;
        titleOptions = titleOptionsLabel;
        menuScript.OnMenuButtonSelected += HandleMenuSelectionChanged;
        categoriesScript.OnCategorySelected += HandleCategorySelectionChanged;
    }

    public void InitializeOptions()
    {
        string currentMenuSelection = menuScript.GetSelectedMenu() ?? "Skins";
        titleOptions.text = currentMenuSelection;

        Option[] currentList = optionsDict.GetValueOrDefault(currentMenuSelection, new Option[] { });

        if (currentList.Any())
        {
            string selectedCategory = categoriesScript.GetSelectedCategory() ?? "ALL";
            currentList = FilterOptionsByCategory(currentList, selectedCategory);
        }

        containerOptions.Clear();
        LoadMenuImages(currentList);
        CreateCardsForOptions(currentList, currentMenuSelection);
        EquipLastSelectedOption(currentMenuSelection);
    }

    private void EquipLastSelectedOption(string currentMenuSelection)
    {
        if (lastSelectedMenuOptions.TryGetValue(currentMenuSelection, out Option lastSelected))
        {
            var buttonToEquip = containerOptions.Query<Button>().ToList()
                .FirstOrDefault(b => GetOptionFromButton(b).name == lastSelected.name);

            if (buttonToEquip != null)
            {
                buttonToEquip.AddToClassList("body__buttonOption");
                buttonToEquip.text = "EQUIPPED";
                buttonToEquip.style.backgroundColor = new StyleColor(Color.clear);
                buttonToEquip.style.left = -30;
            }
        }
    }

    private Option[] FilterOptionsByCategory(Option[] options, string category)
    {
        return category == "ALL" ? options : options.Where(option => option.labelTag == category).ToArray();
    }

    private void LoadMenuImages(Option[] currentList)
    {
        foreach (var item in currentList)
        {
            if (!imageCache.ContainsKey(item.imagePath))
            {
                var texture = Resources.Load<Texture2D>(item.imagePath);
                if (texture != null) imageCache[item.imagePath] = texture;
            }
        }
    }

    private void CreateCardsForOptions(Option[] currentList, string menuSelection)
    {
        foreach (var item in currentList)
        {
            var newCard = new VisualElement { name = item.name };
            AddCardStyle(newCard, item, menuSelection);

            var buttonElement = CreateButtonOption(item, menuSelection);
            newCard.Add(buttonElement);
            containerOptions.Add(newCard);
        }
    }

    private void AddCardStyle(VisualElement card, Option item, string menuSelection)
    {
        if (menuSelection == "Color")
        {
            if (!string.IsNullOrEmpty(item.backgroundColor) && ColorUtility.TryParseHtmlString(item.backgroundColor, out var backgroundColor))
                card.style.backgroundColor = new StyleColor(backgroundColor);

            if (!string.IsNullOrEmpty(item.imagePath) && imageCache.TryGetValue(item.imagePath, out var texture))
                card.style.backgroundImage = new StyleBackground(texture);

            card.AddToClassList("body__cardOptionColor");
        }
        else
        {
            if (ColorUtility.TryParseHtmlString(item.backgroundColor, out var backgroundColor))
                card.style.backgroundColor = new StyleColor(backgroundColor);

            card.AddToClassList("body__cardOption");

            if (!string.IsNullOrEmpty(item.imagePath))
            {
                var imageElement = CreateImageElement(item.imagePath);
                if (imageElement != null) card.Add(imageElement);
            }

            var labelElement = CreateLabelElement(item.labelTag);
            card.Add(labelElement);
        }
    }

    private VisualElement CreateImageElement(string imagePath)
    {
        if (string.IsNullOrEmpty(imagePath)) return null;

        var imageElement = new VisualElement();
        if (imageCache.TryGetValue(imagePath, out var texture))
        {
            imageElement.style.backgroundImage = new StyleBackground(texture);
        }
        imageElement.style.width = Length.Percent(100);
        imageElement.style.height = Length.Percent(100);
        imageElement.AddToClassList("body__imageOption");

        return imageElement;
    }

    private Label CreateLabelElement(string labelText)
    {
        var labelElement = new Label(labelText);
        labelElement.AddToClassList("body__labelOption");
        return labelElement;
    }

    public Button CreateButtonOption(Option item, string menuSelection)
    {
        var button = new Button { name = item.name, text = "EQUIP" };
        button.AddToClassList("body__buttonOption");
        if (menuSelection == "Color") button.style.top = 150;

        button.RegisterCallback<ClickEvent>(evt => HandleButtonClick(button, item, menuSelection));
        return button;
    }

    public void HandleButtonClick(Button clickedButton, Option item, string menuSelection)
    {
        if (lastSelectedButton != null && lastSelectedButton != clickedButton)
        {
            lastSelectedButton.style.backgroundColor = new StyleColor(lastSelectedButtonColor);
            lastSelectedButton.text = "EQUIP";
            lastSelectedButton.style.left = 0;
        }

        clickedButton.style.backgroundColor = new StyleColor(Color.clear);
        clickedButton.text = "EQUIPPED";
        clickedButton.style.left = -30;
        clickedButton.MarkDirtyRepaint();

        lastSelectedButton = clickedButton;
        lastSelectedMenuOptions[menuSelection] = item;
    }

    private Option GetOptionFromButton(Button button)
    {
        return optionsDict.Values.SelectMany(list => list).FirstOrDefault(o => o.name == button.name);
    }

    private void HandleMenuSelectionChanged(Button selectedButton)
    {
        InitializeOptions();
    }

    private void HandleCategorySelectionChanged(string selectedCategory)
    {
        InitializeOptions();
    }
}

[System.Serializable]
public struct Option
{
    public string name;
    public string labelTag;
    public string imagePath;
    public string backgroundColor;
}
