*developed @unity @meta quest3*

# CookSmart AR

## Technic selection

### Manupulation

use hands/voice command

#### Voice commands

voice command by the keywords like "next","back" and so on.

powered by @Vosk. **(Offline)**

| function                            | utterances                        |
| ----------------------------------- | --------------------------------- |
| next step                           | next                              |
| go to main menu                     | main menu                         |
| new timer                           | timer                             |
| back to previous step               | back                              |
| highlight the cookers with its name | [cookers name shown on the panel] |

### Voice guide

powered by @OpenAI. **(Online)**

| timing                                | guide words                                                  |
| ------------------------------------- | ------------------------------------------------------------ |
| open the app                          | "Hello! Welcome to CookSmart. I am your assistant. Instead of using your hands, you can give me instructions verbally! Sounds cool, right? Let's get started! Please select the cookware available to you right now" |
| at cookware panel                     | "Please select the cookware available to you right now"      |
| at recipe panel                       | "Please select the recipe"                                   |
| going through each step on the recipe | [read loud each step's text]                                 |

*The words of the steps in the recipe are generated during runtime, so please keep your headset connected to the Internet.*

## Recipe

| dish                | steps                                                        |
| ------------------- | ------------------------------------------------------------ |
| Quick Beef Stir-Fry | 1.Heat vegetable oil in a large wok or skillet over medium-high heat; cook and stir beef until browned, 3 to 4 minutes.<br />2.Move beef to the side of the wok and add broccoli, bell pepper, carrots, green onion, and garlic to the center of the wok. Cook and stir vegetables for 2 minutes.<br />3.Stir beef into vegetables and season with soy sauce and sesame seeds. Continue to cook and stir until vegetables are tender, about 2 more minutes. |
| .......             | .......                                                      |

*This project is for demo purposes, so recipe and steps are hard-coded in the project code. For commercial use, please utilize a database and complete more functions.*
