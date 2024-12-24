using UnityEngine;
using UnityEngine.UIElements;

public class CategoriesScript
{
    private readonly VisualElement containerCategories;
    private Button currentSelectedButton;

    public event System.Action<string> OnCategorySelected;

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

    private const string DefaultButtonClass = "body__buttonCategory";
    private readonly string initialSelectedCategory = "ALL";

    public CategoriesScript(VisualElement categoriesContainer)
    {
        containerCategories = categoriesContainer;
    }

    public void InitializeCategoriesMenu()
    {
        foreach (var category in categoriesList)
        {
            var button = CreateCategoryButton(category);
            containerCategories.Add(button);

            if (category.labelButton == initialSelectedCategory)
                HandleCategoryButtonClick(button);
        }

        if (currentSelectedButton == null && containerCategories.childCount > 0)
        {
            HandleCategoryButtonClick(containerCategories.ElementAt(0) as Button);
        }
    }

    private Button CreateCategoryButton(Category category)
    {
        var button = new Button
        {
            name = category.labelButton,
            text = category.labelButton
        }.ApplyClass(DefaultButtonClass);

        button.clicked += () => HandleCategoryButtonClick(button);
        return button;
    }

    private void HandleCategoryButtonClick(Button clickedButton)
    {
        Color backgroundColor = clickedButton.resolvedStyle.backgroundColor;

        if (currentSelectedButton != null)
        {
            currentSelectedButton.style.backgroundImage = StyleKeyword.Null;
            currentSelectedButton.style.backgroundColor = new StyleColor(backgroundColor);
        }

        SetBackgroundImage(clickedButton, "Sprites/Categories/BackgroundHeader");

        clickedButton.style.backgroundColor = new StyleColor(Color.clear);

        currentSelectedButton = clickedButton;

        OnCategorySelected?.Invoke(clickedButton.text);
    }

    private void SetBackgroundImage(VisualElement element, string imagePath)
    {
        var texture = Resources.Load<Texture2D>(imagePath);
        element.style.backgroundImage = new StyleBackground(texture);
    }

    public string GetSelectedCategory()
    {
        return currentSelectedButton?.text ?? initialSelectedCategory;
    }
}


public static class VisualElementHelper
{
    public static T ApplyClass<T>(this T element, string className) where T : VisualElement
    {
        element.AddToClassList(className);
        return element;
    }
}

[System.Serializable]
public struct Category
{
    public string labelButton;
}
