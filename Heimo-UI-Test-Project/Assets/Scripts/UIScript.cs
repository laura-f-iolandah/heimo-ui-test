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
        public string labelText;  // Texto do botão
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

        // Criação de botões de forma otimizada
        foreach (var item in buttonsMenu)
        {
            containerMenu.Add(CreateButton(item));
        }
    }

    // Função otimizada para criar o botão
    private Button CreateButton(MenuItem item)
    {
        var newButton = new Button
        {
            text = "", // Não usamos texto diretamente
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

        // Ação de clique
        newButton.clicked += () => Debug.Log($"Clicou no item: {item.labelText}");

        return newButton;
    }

    // Função otimizada para criar o VisualElement com a imagem do botão
    private VisualElement CreateImageButton(string imagePath)
    {
        var imageButton = new VisualElement();
        var backgroundTexture = Resources.Load<Texture2D>(imagePath);
        imageButton.style.backgroundImage = backgroundTexture ? new StyleBackground(backgroundTexture) : new StyleBackground();

        imageButton.AddToClassList("body__iconButtonMenu");
        return imageButton;
    }

    // Função otimizada para criar o Label do botão
    private Label CreateTextButton(string labelText)
    {
        var textButton = new Label
        {
            text = labelText
        };

        // Ajusta o estilo apenas quando necessário
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
//        public string labelText;  // Texto do botão
//    }

//    private void Awake()
//    {
//        // Acessa o rootVisualElement do UIDocument
//        var root = uiDocument.rootVisualElement;
//        containerMenu = root.Q<Button>("containerMenu");

//        // Criação de uma lista de itens de menu
//        MenuItem[] buttonsMenu = new MenuItem[]
//        {
//            new MenuItem { imagePath = "Sprites/IconColors", labelText = "Color" },
//            new MenuItem { imagePath = "Sprites/IconWheels", labelText = "Wheels" },
//            new MenuItem { imagePath = "Sprites/IconBumper", labelText = "Bumper" }
//        };

//        // Para cada item no menu, cria-se um botão
//        foreach (var item in buttonsMenu)
//        {
//            // Cria um VisualElement para o botão (que será o contêiner da imagem)
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
//                Debug.LogError($"Imagem não encontrada: {item.imagePath}");
//            }

//            // Aplica a classe CSS para o botão de imagem
//            imageButton.AddToClassList("body__iconButtonMenu");

//            // Cria um Label para o texto do botão
//            var textButton = new Label();
//            textButton.text = item.labelText;
//            textButton.AddToClassList("body__labelButtonMenu");

//            // Cria um novo botão (sem texto, pois a imagem e o texto já são adicionados como elementos filhos)
//            var newButton = new Button();
//            newButton.text = ""; // Não é necessário texto aqui, pois já temos a label
//            newButton.style.backgroundColor = new StyleColor(new Color(0, 0, 0, 0)); // Transparente
//            newButton.style.borderTopColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderRightColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderBottomColor = new StyleColor(new Color(0, 0, 0, 0));
//            newButton.style.borderLeftColor = new StyleColor(new Color(0, 0, 0, 0));

//            // Aplica a classe CSS para o botão
//            newButton.AddToClassList("body__buttonMenu");

//            // Adiciona a imagem e o texto ao botão
//            newButton.Add(imageButton);
//            newButton.Add(textButton);

//            // Adiciona o botão à raiz do menu
//            root.Add(newButton);

//            // Define o comportamento ao clicar no botão
//            newButton.clicked += () => Debug.Log($"Clicou no item: {item.labelText}");
//        }
//    }
//}
