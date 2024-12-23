using UnityEngine;
using UnityEngine.UIElements;

public class UIScript : MonoBehaviour
{
    [SerializeField] private UIDocument uiDocument;
    private VisualElement containerMenu;

    // Estrutura para armazenar dados do menu (imagem e texto)
    [System.Serializable]
    public struct MenuItem
    {
        public string imagePath;  // Caminho para a imagem
        public string labelText;  // Texto do bot�o
    }

    private void Awake()
    {
        var root = uiDocument.rootVisualElement;
        containerMenu = root.Q<VisualElement>("containerMenu");

        // Itens de menu
        MenuItem[] buttonsMenu =
        {
            new MenuItem { imagePath = "Sprites/IconKart", labelText = "Skins" },
            new MenuItem { imagePath = "Sprites/IconColors", labelText = "Color" },
            new MenuItem { imagePath = "Sprites/IconWheels", labelText = "Wheels" },
            new MenuItem { imagePath = "Sprites/IconAccessories", labelText = "Accessories" },
            new MenuItem { imagePath = "Sprites/IconBumper", labelText = "Bumper" },
            new MenuItem { imagePath = "Sprites/IconSpoiler", labelText = "Spoiler" }
        };

        // Cria��o de bot�es de forma otimizada
        foreach (var item in buttonsMenu)
        {
            containerMenu.Add(CreateButton(item));
        }
    }

    // Fun��o otimizada para criar o bot�o
    private Button CreateButton(MenuItem item)
    {
        var newButton = new Button
        {
            text = "", // N�o usamos texto diretamente
            style =
            {
                backgroundColor = new StyleColor(Color.clear),
                paddingTop = 0,
                paddingBottom = 0,
                paddingLeft = 0,
                paddingRight = 0
            }
        };
        newButton.AddToClassList("body__buttonMenu");

        // Adicionando imagem e texto
        newButton.Add(CreateImageButton(item.imagePath));
        newButton.Add(CreateTextButton(item.labelText));

        // A��o de clique
        newButton.clicked += () => Debug.Log($"Clicou no item: {item.labelText}");

        return newButton;
    }

    // Fun��o otimizada para criar o VisualElement com a imagem do bot�o
    private VisualElement CreateImageButton(string imagePath)
    {
        var imageButton = new VisualElement();
        var backgroundTexture = Resources.Load<Texture2D>(imagePath);
        imageButton.style.backgroundImage = backgroundTexture ? new StyleBackground(backgroundTexture) : new StyleBackground();

        imageButton.AddToClassList("body__iconButtonMenu");
        return imageButton;
    }

    // Fun��o otimizada para criar o Label do bot�o
    private Label CreateTextButton(string labelText)
    {
        var textButton = new Label
        {
            text = labelText
        };

        // Ajusta o estilo apenas quando necess�rio
        if (labelText == "Accessories")
        {
            textButton.style.fontSize = 20;
        }

        textButton.AddToClassList("body__labelButtonMenu");
        return textButton;
    }
}







//using UnityEngine;
//using UnityEngine.UIElements;

//public class UIScript : MonoBehaviour
//{
//    [SerializeField]
//    private UIDocument uiDocument;

//    private VisualElement containerMenu;

//    // Estrutura para armazenar dados do menu (imagem e texto)
//    [System.Serializable]
//    public struct MenuItem
//    {
//        public string imagePath;  // Caminho para a imagem
//        public string labelText;  // Texto do bot�o
//    }

//    private void Awake()
//    {
//        // Acessa o rootVisualElement do UIDocument
//        var root = uiDocument.rootVisualElement;
//        containerMenu = root.Q<Button>("containerMenu");

//        // Cria��o de uma lista de itens de menu
//        MenuItem[] buttonsMenu = new MenuItem[]
//        {
//            new MenuItem { imagePath = "Sprites/IconColors", labelText = "Color" },
//            new MenuItem { imagePath = "Sprites/IconWheels", labelText = "Wheels" },
//            new MenuItem { imagePath = "Sprites/IconBumper", labelText = "Bumper" }
//        };

//        // Para cada item no menu, cria-se um bot�o
//        foreach (var item in buttonsMenu)
//        {
//            // Cria um VisualElement para o bot�o (que ser� o cont�iner da imagem)
//            var imageButton = new VisualElement();

//            // Carrega a textura da imagem a partir da pasta Resources
//            Texture2D backgroundTexture = Resources.Load<Texture2D>(item.imagePath);

//            // Verifica se a imagem foi carregada corretamente
//            if (backgroundTexture != null)
//            {
//                imageButton.style.backgroundImage = new StyleBackground(backgroundTexture);
//            }
//            else
//            {
//                Debug.LogError($"Imagem n�o encontrada: {item.imagePath}");
//            }

//            // Aplica a classe CSS para o bot�o de imagem
//            imageButton.AddToClassList("body__iconButtonMenu");

//            // Cria um Label para o texto do bot�o
//            var textButton = new Label();
//            textButton.text = item.labelText;
//            textButton.AddToClassList("body__labelButtonMenu");

//            // Cria um novo bot�o (sem texto, pois a imagem e o texto j� s�o adicionados como elementos filhos)
//            var newButton = new Button();
//            newButton.text = ""; // N�o � necess�rio texto aqui, pois j� temos a label
//            newButton.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0)); // Transparente
//            newButton.style.borderTopColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderRightColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderBottomColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderLeftColor = new StyleColor(new Color(0, 0, 0, 0));

//            // Aplica a classe CSS para o bot�o
//            newButton.AddToClassList("body__buttonMenu");

//            // Adiciona a imagem e o texto ao bot�o
//            newButton.Add(imageButton);
//            newButton.Add(textButton);

//            // Adiciona o bot�o � raiz do menu
//            root.Add(newButton);

//            // Define o comportamento ao clicar no bot�o
//            newButton.clicked += () => Debug.Log($"Clicou no item: {item.labelText}");
//        }
//    }
//}
