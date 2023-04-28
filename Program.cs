using System;

class Recipe
{
    // Auto-implemented properties for recipe details
    public int NumIngredients { get; set; } // Number of ingredients
    public string[] Ingredients { get; set; } // Ingredient names
    public double[] Quantities { get; set; } // Ingredient quantities
    public string[] Units { get; set; } // Ingredient units
    public int NumSteps { get; set; }   // Number of steps
    public string[] Steps { get; set; } // Actual Steps

    // Method to display recipe
    public void DisplayRecipe()
    {

        Console.WriteLine("\n\n\nHere is your recipe:\n");
        Console.WriteLine("Ingredients:");
        for (int i = 0; i < NumIngredients; i++) // Loop through ingredients
        {
            Console.WriteLine("- {0} {1} {2}", Quantities[i], Units[i], Ingredients[i]); // Display ingredient
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < NumSteps; i++) // Loop through steps
        {
            Console.WriteLine("{0}. {1}", i + 1, Steps[i]); // Display step
        }
        Console.WriteLine();
    }

    // Method to scale recipe by factor
    public void ScaleRecipe(double factor)
    {
        for (int i = 0; i < NumIngredients; i++)
        {
            Quantities[i] *= factor;
        }
    }

    // Method to reset recipe to original quantities
    public void ResetRecipe()
    {
        // TODO: Implement logic to reset quantities to original values
        // Hint: You will need to store the original quantities somewhere

    }

    // Method to clear recipe data
    public void ClearRecipe()
    {
        NumIngredients = 0;
        Ingredients = new string[0];
        Quantities = new double[0];
        Units = new string[0];
        NumSteps = 0;
        Steps = new string[0];
    }
}

class Program
{
    static void Main()
    {
        
        // Get recipe details from user
        Recipe recipe = getRecipeDetails(new Recipe());
        
        int choice = 0;

        // choices 1, Display Recipe
        // choices 2, Scale Recipe
        // choices 3, Reset Recipe back to original
        // choices 4, Clear Recipe and start over
        // choices 5, Exit

        while (choice != 5)
        {
            // Display menu
            choice = displayMenu();
            switch (choice)
            {
                case 1: // Display recipe
                    recipe.DisplayRecipe();
                    break;
                case 2: // Scale recipe
                    Console.Write("Enter scaling factor (0.5, 2, or 3): ");
                    try {
                        double factor = double.Parse(Console.ReadLine());
                        recipe.ScaleRecipe(factor);
                    } catch (Exception e) {
                        Console.WriteLine("Factor entered was not a number or decimal.");
                    }
                    break;
                case 3: // Reset recipe
                    recipe.ResetRecipe();
                    break;
                case 4: // Clear recipe
                    recipe.ClearRecipe();
                    recipe = getRecipeDetails(recipe);
                    break;
                case 5: // Exit
                    Console.WriteLine("Goodbye!");
                    break;
                default: // Invalid choice
                    Console.WriteLine("Invalid choice, try again.");
                    break;
            }

        }
    }

    // Method to get recipe details from user getReceipeDetails()
    public static Recipe getRecipeDetails(Recipe recipe)
    {
        Console.Write("Enter number of ingredients: ");
        recipe.NumIngredients = int.Parse(Console.ReadLine());
        recipe.Ingredients = new string[recipe.NumIngredients];
        recipe.Quantities = new double[recipe.NumIngredients];
        recipe.Units = new string[recipe.NumIngredients];
        for (int i = 0; i < recipe.NumIngredients; i++)
        {
            Console.Write("Enter ingredient name for #{0}: ", i + 1);
            recipe.Ingredients[i] = Console.ReadLine();
            Console.Write("Enter quantity for #{0}: ", i + 1);
            recipe.Quantities[i] = double.Parse(Console.ReadLine());
            Console.Write("Enter unit of measurement for #{0}: ", i + 1);
            recipe.Units[i] = Console.ReadLine();
        }
        Console.Write("Enter number of steps: ");
        recipe.NumSteps = int.Parse(Console.ReadLine());
        recipe.Steps = new string[recipe.NumSteps];
        for (int i = 0; i < recipe.NumSteps; i++)
        {
            Console.Write("Enter step #{0}: ", i + 1);
            recipe.Steps[i] = Console.ReadLine();
        }

        return  recipe;
    }

    // Method to display menu
    public static int displayMenu()
    {
        Console.WriteLine("\n\n========Recipe Menu========");
        Console.WriteLine("1. Display Recipe");
        Console.WriteLine("2. Scale Recipe");
        Console.WriteLine("3. Reset Recipe");
        Console.WriteLine("4. Clear Recipe");
        Console.WriteLine("5. Exit");
        Console.Write("Enter choice: ");
        try {
            return int.Parse(Console.ReadLine());
        } catch (Exception e) {
            Console.WriteLine("Choice entered was not a number.");
            return 0;
        }
    }
    
}
