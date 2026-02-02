using BlogConsole.Models;
using BlogConsole.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogConsole.UI
{
    internal class ConsoleMenu
    {
        public static void DisplayMenu()
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

        public static void Menu()
        {
            Console.WriteLine("===BLOG CONSOLE===");
            ArticleService article = new ArticleService();
            CommentService comment = new CommentService();

            while (true)
            {
                DisplayMenu();
                string choice = Console.ReadLine() ?? "";

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("===Lister les articles===");
                        List<Article> articles = article.GetArticles();
                        foreach (Article a in articles)
                        {
                            Console.WriteLine(a);
                        }
                        break;

                    case "2":
                        Console.WriteLine("===Creer un Article===");
                        Console.Write("Saisir un titre:");
                        string? title = Console.ReadLine();
                        Console.WriteLine("Saisir contenu:");
                        string? content = Console.ReadLine();

                        article.CreateArticle(title, content);
                        
                        break;

                    case "3":
                        Console.WriteLine("===Voir un article===");
                        Console.Write("Saisir id de l'article:");
                        bool okId = int.TryParse(Console.ReadLine(), out int id);

                        if (okId)
                        {
                            Console.WriteLine(article.ArticleDetails(id));
                            Console.WriteLine("#Commentaires#");
                            List<Comment> comments = comment.GetByArticle(id);
                            foreach (Comment c in comments)
                            {
                                Console.WriteLine(c);
                            }

                        } 
                        else
                        {
                            Console.WriteLine("Article introuvable");
                        }
                            break;

                    case "4":
                        Console.WriteLine("===Modifier un article===");
                        Console.Write("Saisir id de l'article:");
                        okId = int.TryParse(Console.ReadLine(), out id);

                        if (okId)
                        {
                            Console.Write("Saisir un nouveau titre:");
                            string newTitle = Console.ReadLine();
                            Console.WriteLine("Saisir un nouveau contenu:");
                            string newContent = Console.ReadLine();
                            article.UpdateArticle(id,newTitle, newContent);
                        }
                        else
                        {
                            Console.WriteLine("Article introuvable");
                        }
                        break;

                    case "5":
                        Console.WriteLine("===Supprimer un article");
                        Console.Write("Saisir id de l'article: ");
                        okId = int.TryParse(Console.ReadLine(), out id);

                        if (okId)
                        {
                            article.DeleteArticle(id);
                        }
                        else
                        {
                            Console.WriteLine("Article introuvable");
                        }
                        break;

                    case "6":
                        Console.WriteLine("===Ajouter un commentaire===");
                        Console.Write("Saisir id de l'article à commenter:");
                        okId = int.TryParse(Console.ReadLine(), out int articleId);

                        if (okId)
                        {
                            Console.Write("Saisir un auteur:");
                            string author = Console.ReadLine();
                            Console.WriteLine("Saisir un contenu:");
                            content = Console.ReadLine();
                            comment.CreateComment(articleId,author,content);
                        }
                        else
                        {
                            Console.WriteLine("Article introuvable");
                        }
                            break;

                    case "7":
                        Console.WriteLine("===Supprimer un commentaire===");
                        Console.Write("Saisir id du commentaire: ");
                        okId = int.TryParse(Console.ReadLine(), out int commentId);

                        if (okId)
                        {
                            article.DeleteArticle(commentId);
                        }
                        else
                        {
                            Console.WriteLine("Article introuvable");
                        }
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
