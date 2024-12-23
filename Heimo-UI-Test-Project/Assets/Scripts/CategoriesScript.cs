using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CategoriesScript
{
    private VisualElement containerCategories;
    private Button currentSelectedButton;

    private readonly Category[] categoriesList =
    {
        new Category { labelButton = "ALL" },
        new Category { labelButton = "COMMON" },
        new Category { labelButton = "RARE" },
        new Category { labelButton = "LEGENDARY" },
        new Category { labelButton = "EPIC" },
        new Category { labelButton = "UNIQUE" },
        new Category { labelButton = "SPECIAL" }
    };

    public CategoriesScript(VisualElement categoriesContainer)
    {
        containerCategories = categoriesContainer;
    }

    public void InitializeCategoriesMenu()
    {

        foreach (var item in categoriesList)
        {
            containerCategories.Add(CreateButtonCategory(item));
        }
    }

    private Button CreateButtonCategory(Category item)
    {
        var newButton = new Button
        {
            name = "buttonCategory" + item.labelButton
        };
        newButton.AddToClassList("body__buttonCategory");

        newButton.text = item.labelButton;

        newButton.clicked += () => HandleMenuButtonClick(newButton);

        return newButton;
    }

    private void HandleMenuButtonClick(Button clickedButton)
    {
        if (currentSelectedButton != null)
        {
            currentSelectedButton.style.backgroundImage = StyleKeyword.Null;
        }

        SetBackgroundImage(clickedButton, "Sprites/Menu/BackgroundHeader");
        currentSelectedButton = clickedButton;
    }

    private void SetBackgroundImage(VisualElement element, string imagePath)
    {
        var texture = Resources.Load<Texture2D>(imagePath);

        element.style.backgroundImage = new StyleBackground(texture);

    }

}

[System.Serializable]
public struct Category
{
    public string labelButton;
}