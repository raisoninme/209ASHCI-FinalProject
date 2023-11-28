using UnityEngine;
using UnityEngine.UI;

public class DynamicMenuGenerator : MonoBehaviour
{
    // TODO: This variable should be removed after database is implemented
    private int numberOfButtons = 6; // The number of buttons to generate
    [SerializeField]
    private Transform content; // The content object of the scroll view
    [SerializeField]
    private Transform menuScrollView;        // Menu ScrollView
    [SerializeField]
    private Transform ingredientCheckView;   // IngredientCheck ScrollView

    void Start()
    {
        GenerateButtons();
    }

    void GenerateButtons()
    {
        VerticalLayoutGroup verticalLayoutGroup = content.gameObject.AddComponent<VerticalLayoutGroup>();

        // TODO: Get number of buttons from database
        // TODO: Generate buttons with database data

        // Test data:
        string[] buttonNames = new string[] { "Quick Beef Stir-Fry", "Grilled Cheese Sandwich", "Simple Beef Stroganoff",
                                                     "Reuben Sandwich", "Pan-Seared Tilapia", "Chicken Parmesan"};

        for (int i = 0; i < numberOfButtons; i++)
        {
            GameObject buttonObject = new GameObject("Button" + i.ToString());
            buttonObject.transform.SetParent(content);

            Button button = buttonObject.AddComponent<Button>();

            Text buttonText = buttonObject.AddComponent<Text>();
            buttonText.text = buttonNames[i];

            button.onClick.AddListener(() => ButtonClickHandler(buttonObject));
        }
    }

    void ButtonClickHandler(GameObject button)
    {
        // Do something
        menuScrollView.gameObject.SetActive(false);

        // Find the IngredientText within ingredientCheckView
        Text ingredientText = ingredientCheckView.Find("Scroll View/Viewport/Content/IngredientsText").GetComponent<Text>();

        // Update the text value
        // TODO: Get ingredients from database
        ingredientText.text = "2 tablespoons vegetable oil 1 pound beef sirloin, cut into 2-inch strips 1 ½ cups fresh broccoli florets 1 red bell pepper, cut into matchsticks 2 carrots, thinly sliced 1 green onion, chopped 1 teaspoon minced garlic 2 tablespoons soy sauce 2 tablespoons sesame seeds, toasted";
        ingredientCheckView.gameObject.SetActive(true);
    }
}
