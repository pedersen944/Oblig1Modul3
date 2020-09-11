using System;
using System.Collections.Generic;
using System.Text;

namespace Oblig1
{
    public class FamilyApp
    {
        public List<Person> People;

        public FamilyApp(params Person[] people)
        {
            People = new List<Person>(people);
        }

        public string WelcomeMessage()
        {
            return "Welcome to the Family App to get started, please type 'help' ";
        }

        public string CommandPrompt = "Enter text here: ";

        public string HandleCommand(string command)
        {
            string inputCommand = command;

            if (inputCommand.ToLower() == "help")
            {
                return "'help' shows a list of commands\n" +
                       "'list' lists every person with id, name etc..\n" +
                       "'show <id>' shows a specific person with mother, father and child including ids\n";
            }

            if (inputCommand.ToLower() == "list")
            {
                string listString = "";

                foreach (var people in People)
                {
                    listString += people.GetDescription() + "\n";
                }

                return listString;
            }

            if (inputCommand.Substring(0, 4).ToLower() == "show")
            {
                int idNum = int.Parse(inputCommand.Substring(5));
                return IdSorter(idNum);
            }

            return "please enter a valid id";
        }

        public string IdSorter(int idNum)
        {
            string result;

            foreach (var searchResult in People)
            {
                if (searchResult.Id == idNum)
                {
                    result = searchResult.GetDescription();
                    result += ChildSearch(idNum);
                    return result;
                }
            }

            result = "did not find a person with that id, please try another id";
            return result;
        }

        public string ChildSearch(int idNum)
        {
            int childNumber = People.Count;
            string[] listOfIds = new string[childNumber];
            string child = null;
            int iterations = 0;

            for (int a = 0; a < childNumber; a++)
            {
                if (People[a].Mother != null && People[a].Mother.Id == idNum)
                {
                    listOfIds[iterations] = "    " + People[a].FirstName + " (Id=" + People[a].Id + ") Født: " +
                                            People[a].BirthYear + "\n";
                    iterations++;
                }
                else if (People[a].Father != null && People[a].Father.Id == idNum)
                {
                    listOfIds[iterations] = "    " + People[a].FirstName + " (Id=" + People[a].Id + ") Født: " +
                                            People[a].BirthYear + "\n";
                    iterations++;
                }
            }

            if (listOfIds[0] != null)
            {
                child = "\n  Barn:\n";
                for (int i = 0; i < listOfIds.Length; i++)
                {
                    if (listOfIds[i] != null)
                    {
                        child += listOfIds[i];
                    }
                }
            }

            else if (listOfIds[0] == null)
            {
                child = " ";
            }


            return child;
        }
    }
}
