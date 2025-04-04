using System;
using System.Speech.Synthesis;
using Figgle;

namespace Example1
{
    class Voice
    {
        static void Main(String[] args)
        {
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //Configure the synthesizer
            synth.Volume = 100; // set the volume (100-0)
            synth.Rate = 0; // set the speaking rate (-10 to 10)

            //Shows ASCII art through Figgle
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));

            //speaks a message
            Console.WriteLine("Chatbot: Hello I can talk.");
            synth.Speak("Hello I can talk.");

            //speaks for user's name
            Console.WriteLine("Chatbot: Please enter your name: \nYou:");
            synth.Speak("Please enter your name.");
            String userText = Console.ReadLine();

            //Shows ASCII art through Figgle
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));

            //Greets user with their added name.
            Console.WriteLine($"Chatbot: Welcome: {userText}, how are you?");
            synth.Speak($"Welcome: {userText}, how are you?");
            String greeting = Console.ReadLine();

            Console.WriteLine($"\nYou:{greeting}");
            Console.WriteLine($"Chatbot: I'm doing fine thanks {userText}.");
            synth.Speak($"I'm doing fine thanks {userText}.");

            //Prompts user to enter a key response to start explanation
            //Shows ASCII art through Figgle
            Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is is cool!"));
            Console.WriteLine("Chatbot: Let's learn more about Cyber Security!! I can tell you more about passwords, wifi, updates, antiviruses as well as phising! However if you'd like, you can type 'exit' if you would like to leave:");
            synth.Speak("Let's learn more about Cyber Security!! I can tell you more about passwords, wifi, updates, antiviruses as well as phising! However if you'd like, you can type 'exit' if you would like to leave:");

            //If user enters one of selected key response, an explanation will pop up.
            Dictionary<string, string> responses = new Dictionary<string, string>()
            {
                { "password", "Always use strong passwords with a mix of letters, numbers, and symbols." },
                { "phishing", "Phishing scams often involve fake emails or websites. Never click on links from unknown sources." },
                { "antivirus", "Keep your antivirus software up to date to protect your system." },
                { "update", "Regularly update your software to patch vulnerabilities." },
                { "wifi", "Avoid using public Wi-Fi for sensitive activities like online banking." }
            };

            bool foundResponse = false;
            while (true)
            {
                Console.Write("\nYou: ");
                string userInput = Console.ReadLine()?.ToLower();

                //If user enters exit, while statement stops loop
                if (userInput == "exit")
                {
                    //Shows ASCII art through Figgle
                    Console.WriteLine(FiggleFonts.Standard.Render("CyberSecurity is cool!"));
                    string goodbyeMessage = "Goodbye! Have great caution online.";
                    Console.WriteLine("Chatbot: " + goodbyeMessage);
                    synth.Speak(goodbyeMessage);
                    break;
                }

                foreach (var key in responses.Keys)
                {
                    if (userInput.Contains(key))
                    {
                        string response = responses[key];
                        Console.WriteLine("Chatbot: " + response);
                        synth.Speak(response);
                        foundResponse = true;
                        break;
                    }
                }

                if (!foundResponse)
                {
                    string defaultResponse = "Dang it!!! I don't have that knowledge on that. However I can tell you more about phishing, passwords, updates, antiviruses or wifi.";
                    Console.WriteLine("Chatbot: " + defaultResponse);
                    synth.Speak(defaultResponse);
                }

                foundResponse = false;
            }
        }
    }
}





