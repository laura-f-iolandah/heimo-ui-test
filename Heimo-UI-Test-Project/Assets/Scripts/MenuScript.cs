using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MenuScript
{
    private VisualElement sectionMenu;
    private Button currentSelectedButton;

    private readonly MenuItem[] menuList =
    {
        new MenuItem { imagePath = "Sprites/Menu/IconKart", labelText = "Skins" },
        new MenuItem { imagePath = "Sprites/Menu/IconColors", labelText = "Color" },
        new MenuItem { imagePath = "Sprites/Menu/IconWheels", labelText = "Wheels" },
        new MenuItem { imagePath = "Sprites/Menu/IconAccessories", labelText = "Accessories" },
        new MenuItem { imagePath = "Sprites/Menu/IconBumper", labelText = "Bumper" },
        new MenuItem { imagePath = "Sprites/Menu/IconSpoiler", labelText = "Spoiler" }
    };

    private Dictionary<string, Texture2D> imageCache = new Dictionary<string, Texture2D>();

    public MenuScript(VisualElement menu)
    {
        sectionMenu = menu;
    }

    public void InitializeMenu()
    {
        LoadMenuImages();

        foreach (var item in menuList)
        {
            sectionMenu.Add(CreateButtonMenu(item));
        }
    }

    private void LoadMenuImages()
    {
        foreach (var item in menuList)
        {
            if (!imageCache.ContainsKey(item.imagePath))
            {
                var texture = Resources.Load<Texture2D>(item.imagePath);
                    imageCache[item.imagePath] = texture;
            }
        }
    }

    private Button CreateButtonMenu(MenuItem item)
    {
        var newButton = new Button
        {
            name = "buttonMenu" + item.labelText
        };
        newButton.AddToClassList("body__buttonMenu");

        newButton.Add(CreateImageElement(item.imagePath));
        newButton.Add(CreateLabelElement(item.labelText));

        newButton.clicked += () => HandleMenuButtonClick(newButton);

        ApplyDefaultButtonStyle(newButton);

        return newButton;
    }

    private VisualElement CreateImageElement(string imagePath)
    {
        var imageElement = new VisualElement();
        if (imageCache.TryGetValue(imagePath, out var texture))
        {
            imageElement.style.backgroundImage = new StyleBackground(texture);
        }
        imageElement.AddToClassList("body__iconButtonMenu");
        return imageElement;
    }

    private Label CreateLabelElement(string labelText)
    {
        var labelElement = new Label { text = labelText };
        labelElement.AddToClassList("body__labelButtonMenu");

        if (labelText == "Accessories")
        {
            labelElement.style.fontSize = 20;
        }

        return labelElement;
    }

    private void HandleMenuButtonClick(Button clickedButton)
    {
        if (currentSelectedButton != null)
        {
            SetBackgroundImage(currentSelectedButton, "Sprites/Menu/BackgroundButton");
        }

        SetBackgroundImage(clickedButton, "Sprites/Menu/BackgroundButtonClicked");
        currentSelectedButton = clickedButton;
    }

    private void ApplyDefaultButtonStyle(Button button)
    {
        button.style.backgroundColor = Color.clear;
    }

    private void SetBackgroundImage(VisualElement element, string imagePath)
    {
        var texture = Resources.Load<Texture2D>(imagePath);

        element.style.backgroundImage = new StyleBackground(texture);

    }
}

[System.Serializable]
public struct MenuItem
{
    public string imagePath;
    public string labelText;
}

