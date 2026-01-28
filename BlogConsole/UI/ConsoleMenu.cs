using BlogConsole.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogConsole.UI
{
    internal class ConsoleMenu
    {
        public void DisplayMenu()
        {
            Console.WriteLine("MENU");
            Console.WriteLine("1- Lister les articles");
            Console.WriteLine("2- Creer un article");
            Console.WriteLine("3- Voir un article");
            Console.WriteLine("4- Modifier un article");
            Console.WriteLine("5- Supprimer un article");
            Console.WriteLine("6- Ajouter un commentaire");
            Console.WriteLine("7- Supprimer un commentaire");
            Console.WriteLine("0- Quitter");
            Console.Write("Votre choix :");
        }

        public void Menu()
        {
            Console.WriteLine("===BLOG CONSOLE===");

            while (true)
            {
                this.DisplayMenu();
                string choix = Console.ReadLine() ?? "";

                switch (choix)
                {
                    case "1":
                        Console.WriteLine("===Lister les articles===");
                        ArticleService getAll = new ArticleService();
                        foreach(var article in getAll.GetArticles())
                        {
                            Console.WriteLine(article);
                        }
                        break;

                    case "2":
                        Console.WriteLine("===Creer un Article===");
                        Console.Write("Saisir un titre:");
                        string? titre = Console.ReadLine();
                        Console.Write("Saisir contenu:");
                        string? content = Console.ReadLine();

                        ArticleService create = new ArticleService();
                        create.CreateArticle(titre, content);
                        Console.WriteLine("");
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "7":
                        break;

                    case "0":
                        return;
                    default:
                        Console.WriteLine("choix non compris");
                        break;
                }
            }

        }
    }
}
