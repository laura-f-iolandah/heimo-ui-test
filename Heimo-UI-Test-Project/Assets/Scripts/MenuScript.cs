using UnityEngine.UIElements;
using UnityEngine;

public class MenuScript
{
    private readonly VisualElement sectionMenu;
    private Button currentSelectedButton;
    public System.Action<Button> OnMenuButtonSelected;

    private readonly MenuItem[] menuItems =
    {
        new MenuItem { imagePath = "Sprites/Menu/IconKart", labelText = "Skins" },
        new MenuItem { imagePath = "Sprites/Menu/IconColors", labelText = "Color" },
        new MenuItem { imagePath = "Sprites/Menu/IconWheels", labelText = "Wheels" },
        new MenuItem { imagePath = "Sprites/Menu/IconAccessories", labelText = "Accessories" },
        new MenuItem { imagePath = "Sprites/Menu/IconBumper", labelText = "Bumpers" },
        new MenuItem { imagePath = "Sprites/Menu/IconSpoiler", labelText = "Spoiler" }
    };

    private string currentSelectedMenu = "Skins";

    private readonly Texture2D defaultBackground;
    private readonly Texture2D hoverBackground;

    public MenuScript(VisualElement menu)
    {
        sectionMenu = menu;
        defaultBackground = Resources.Load<Texture2D>("Sprites/Menu/BackgroundMenu");
        hoverBackground = Resources.Load<Texture2D>("Sprites/Menu/BackgroundMenuHover");
    }

    public void InitializeMenu()
    {
        Button initialButton = null;

        foreach (var item in menuItems)
        {
            var button = CreateMenuButton(item);
            sectionMenu.Add(button);

            if (item.labelText == currentSelectedMenu)
                initialButton = button;
        }

        HandleMenuButtonClick(initialButton ?? sectionMenu.Q<Button>());
    }

    private Button CreateMenuButton(MenuItem item)
    {
        var button = new Button
        {
            name = item.labelText,
            style =
            {
                backgroundImage = new StyleBackground(defaultBackground)
            }
        };

        button.AddToClassList("body__buttonMenu");
        button.Add(CreateImageElement(item.imagePath));
        button.Add(CreateLabelElement(item.labelText));

        button.clicked += () => HandleMenuButtonClick(button);
        return button;
    }

    private VisualElement CreateImageElement(string imagePath)
    {
        var texture = Resources.Load<Texture2D>(imagePath);

        return new VisualElement
        {
            style = { backgroundImage = new StyleBackground(texture) }
        }.WithClass("body__iconButtonMenu");
    }

    private Label CreateLabelElement(string labelText)
    {
        var label = new Label(labelText)
        {
            style = { fontSize = labelText == "Accessories" ? 20 : StyleKeyword.Null }
        };
        return label.WithClass("body__labelButtonMenu");
    }

    public void HandleMenuButtonClick(Button selectedButton)
    {
        if (currentSelectedButton != null && currentSelectedButton != selectedButton)
        {
            currentSelectedButton.style.backgroundImage = new StyleBackground(defaultBackground);
        }

        selectedButton.style.backgroundImage = new StyleBackground(hoverBackground);
        currentSelectedButton = selectedButton;
        currentSelectedMenu = selectedButton.Q<Label>()?.text ?? currentSelectedMenu;

        OnMenuButtonSelected?.Invoke(selectedButton);
    }

    public string GetSelectedMenu()
    {
        return currentSelectedButton?.Q<Label>()?.text ?? currentSelectedMenu;
    }
}

public static class VisualElementExtensions
{
    public static T WithClass<T>(this T element, string className) where T : VisualElement
    {
        element.AddToClassList(className);
        return element;
    }
}

[System.Serializable]
public struct MenuItem
{
    public string imagePath;
    public string labelText;
}
