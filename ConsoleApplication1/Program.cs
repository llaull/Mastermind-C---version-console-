using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

public class Mastermind
{
    //Debut du programme
    class Programm
    {
        public enum Jeux
        {
            Jeu1,
            Jeu2
        };

        static void Main() // fonction principal
        {
            Console.Title = "Le jeu du Mastermind"; // Affiche le nom du programme dans la barre de titre de la console
            menu();
            Fermeture_programme();
        }

        static void DecorerTexte(string texte) // fonction qui encadre les differentes fenetres du programme
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\t╔" + new String('═', texte.Length + 2) + "╗");
            Console.Write("\t║ ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(texte);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(" ║\n");
            Console.WriteLine("\t╚" + new String('═', texte.Length + 2) + "╝");
        }

        static void affichage_principal() // Titre du programme
        {
            DecorerTexte(" Jeu du MASTERMIND version console ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void but() // affiche le principe du mastermind
        {
            Console.WriteLine("   Le but d’une partie de mastermind est de découvrir une combinaison cachée");
            Console.WriteLine("\n (de couleurs dans le jeu du commerce, mais ici, avec une application console,");
            Console.WriteLine("nous prendrons une combinaison de chiffres).");
            Console.WriteLine(); Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
        }

        static void affichage_aide() // titre de l'aide
        {
            DecorerTexte(" Jeu du MASTERMIND - Aide et Réglement ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void affichage_V1() // titre du mastermind ( version simple ) 
        {
            DecorerTexte(" Jeu du MASTERMIND - V1 - 4 chiffres et 8 coups possible ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" \t * => 1 chiffre bien placé\n\t ° => 1 chiffre mal placé");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void affichage_V2() // titre du "super" mastermind
        {
            DecorerTexte(" Jeu du MASTERMIND - V2 - 5 chiffres et 10 coups possible ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" \t * => 1 chiffre bien placé\n\t ° => 1 chiffre mal placé");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void affichage_record_V1() // titre du record V1
        {
            DecorerTexte(" Jeu du MASTERMIND - Salle des records  ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void affichage_record_V2() // titre du record V2
        {
            DecorerTexte(" Jeu du MASTERMIND - Salle des records  ");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }

        static void reglement() // fonction appelé si on choisie A
        {
            Console.Clear();
            affichage_aide();
            Console.Write(" La combinaison est composée de 4 chiffres de 0 à 7. Un chiffre peut se trouver plusieurs");
            Console.Write(" fois dans la combinaison cachée (7177, 4353, ...).\n\nLe joueur dispose de huit propositions pour trouver la solution.");
            Console.Write("\n\nSi la solution n’est pas trouvée, elle sera montrée au joueur.");
            Console.Write("\nLa proposition du joueur doit être conforme à ce que peut être la combinaison\ncachée.\n");
            Console.Write("La proposition 8532 n’est donc pas correcte car le 8 n’appartient pas à la \nsolution. De même une proposition partielle n’est pas possible ( .5.6 ). ");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("\n\n\tAppuyez sur une touche poour revenir au menu général");
            Console.ReadLine();
            menu();
        }

        static void Fermeture_programme() // fonction qui ferme automatique le programme apres 5 secondes
        {
            Console.Clear();
            Console.CursorVisible = false; // Masque le curseur
            affichage_principal();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n\n\t   Merci d'avoir utilisé ce Programme ! \n\n\n\tFermeture automatiquement dans 5 secondes");
            Thread.Sleep(5000);  // delai de 5 secondes avant instruction suivante en ajoutant la librairie "using System.Threading"                  
        }

        static void Record1() // Fonction affichage Record V1
        {
            Console.Clear();
            Console.CursorVisible = false; // Masque le curseur
            affichage_record_V1();
            StreamReader sr = new StreamReader("C:\\Mastermind\\record1.txt");
            string strLine;
            while ((strLine = sr.ReadLine()) != null)
            {
                string[] champs = strLine.Split(',');
                int i = 0;
                Console.Write(" ║ {0,-10}║ {1,-10}║ {2,-16} ║\n", champs[i], champs[i + 1], champs[i + 2]);
            }
            sr.Close();
            Console.WriteLine("\nAppuyez sur " + "Entrée" + " pour revenir au menu principal\n");
        }

        static void Record2() // Fonction affichage Record V2
        {
            Console.Clear();
            Console.CursorVisible = false; // Masque le curseur
            affichage_record_V2();
            StreamReader sr = new StreamReader("C:\\Mastermind\\record2.txt");
            string strLine;
            while ((strLine = sr.ReadLine()) != null)
            {
                // traitement de la ligne lue
                string[] champs = strLine.Split(',');
                int i = 0;
                Console.Write(" ║ {0,-10}║ {1,-10}║ {2,-16} ║\n", champs[i], champs[i + 1], champs[i + 2]);
            }
            sr.Close();
            Console.WriteLine("\nAppuyez sur " + "Entrée" + " pour revenir au menu principal\n");
        }

        static void menu() // affiche le menu
        {
            //Declaration et initialisation des variables
            string choix;

            do
            {
                Console.Clear();
                Directory.CreateDirectory("c:\\Mastermind"); // creation du repertoire Mastermind pour l'enregistrement des fichiers recors 1 et 2
                affichage_principal(); // appel de la fonction affichage 
                but(); // appel de la fonction but

                if (!System.IO.File.Exists("C:\\Mastermind\\record1.txt"))
                {
                    FileInfo record1 = new FileInfo("C:\\Mastermind\\record1.txt"); // creer le fichier record1 dans le repertoire mastermind
                    StreamWriter sw = new StreamWriter("C:\\Mastermind\\record1.txt"); // on ecrit l'entete dans les fichiers Record 1 et 2
                    sw.WriteLine("NOM,TEMPS,NOMBRES DE COUPS,");
                    sw.Close();
                }

                if (!System.IO.File.Exists("C:\\Mastermind\\record2.txt"))
                {
                    FileInfo record2 = new FileInfo("C:\\Mastermind\\record2.txt"); // creer le fichier record2 dans le repertoire mastermind
                    StreamWriter sw2 = new StreamWriter("C:\\Mastermind\\record2.txt");
                    sw2.WriteLine("NOM,TEMPS,NOMBRES DE COUPS,");
                    sw2.Close();
                }

                //Affichage
                Console.WriteLine("  A - Aide et Règlement du Jeu");
                Console.WriteLine("  M - Mastermind V1 - 4 chiffres (de 0 à 7) et 8 coups possible ");
                Console.WriteLine("  S - Mastermind V2 - 5 chiffres (de 0 à 8) et 10 coups possible");
                Console.WriteLine("  R1 - Visualiser le fichier des Records Mastermind V1");
                Console.WriteLine("  R2 - Visualiser le fichier des Records Mastermind V2");
                Console.WriteLine("  Q - Quitter");
                Console.WriteLine();
                Console.Write("\tEntrez votre option : ");
                choix = Console.ReadLine();
                switch (choix.ToUpper())
                {
                    case "A":
                        reglement();
                        break;

                    case "M":
                        Console.Clear();
                        bool continuer;
                        do
                        {
                            continuer = lanceunjeu(Jeux.Jeu1);
                        }
                        while (continuer);
                        break;

                    case "S":
                        Console.Clear();
                        bool rejouer;
                        do
                        {
                            rejouer = lanceunjeu(Jeux.Jeu2);
                        }
                        while (rejouer);
                        break;

                    case "R1":
                        Console.Clear();
                        Record1();
                        Console.ReadLine();
                        Console.CursorVisible = true; // Masque le curseur
                        break;

                    case "R2":
                        Console.Clear();
                        Record2();
                        Console.ReadLine();
                        Console.CursorVisible = true; // Masque le curseur
                        break;

                    case "Q":
                        break;

                    default:
                        break;
                }
            } while (choix.ToUpper() != "Q");
        }

        static bool lanceunjeu(Jeux jeu)
        {
            bool gagne = false;
            if (jeu == Jeux.Jeu1)
                gagne = RunV1();
            if (jeu == Jeux.Jeu2)
                gagne = RunV2();
            if (gagne)
                Console.WriteLine("\nBravo vous avez gagnez \n Partie terminée :)");
            else
                Console.WriteLine("\nDésolé vous avez perdu \n Partie terminée :(");
            Console.WriteLine("\n\nVoulez-vous rejouer (O)ui (N)on ?");
            string oui = Console.ReadLine();
            if (oui.ToUpper() == "O")
                return true;
            else
                return false;
        }

        static string GenereProposition1()
        {
            Random rand = new Random();
            string resultat = "";
            for (int j = 0; j < 4; j++)
            {
                resultat += rand.Next(-1, 8).ToString();
            }
            return resultat;
        }

        static string GenereProposition2()
        {
            Random rand = new Random();
            string resultat = "";
            for (int j = 0; j < 5; j++)
            {
                resultat += rand.Next(0, 9).ToString();
            }
            return resultat;
        }

        static string SaisieProposition1()
        {
            string saisie = "";

            while (saisie.Length != 4)
            {

                Console.Write("Entrez une proposition :");
                saisie = Console.ReadLine();
            }

            int testeur = 0;
            if (saisie.Length == 4 && int.TryParse(saisie, out testeur)) // test pour verifier que la proposition ne dépasse pas 4 chiffres
            {
                for (int i = 0; i < 4; i++)
                {
                    testeur = int.Parse(saisie[i].ToString());
                    if (testeur < 0 || testeur > 8)
                        Console.Write("Erreur de saisie\n");
                }
            }
            else
            {
                Console.Write("Erreur de saisie\n");
            }

            return saisie;
        }

        static string SaisieProposition2()
        {
            string saisie = "";

            while (saisie.Length != 5)
            {

                Console.Write("Entrez une proposition :");
                saisie = Console.ReadLine();
            }

            int testeur = 0;
            if (saisie.Length == 5 && int.TryParse(saisie, out testeur)) // test pour verifier que la proposition ne dépasse pas 4 chiffres
            {
                for (int i = 0; i < 5; i++)
                {
                    testeur = int.Parse(saisie[i].ToString());
                    if (testeur < 0 || testeur > 9)
                        Console.Write("Erreur de saisie\n");
                }
            }
            else
            {
                Console.Write("Erreur de saisie\n");
            }
            return saisie;
        }

        static void AjouteHighScore(string cheminfichier, int temps, int i)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.WriteLine("\nTemps de la partie : " + temps + " s");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nNom du joueur : ");
            string nom = Console.ReadLine();
            // Enregistrement nom du joueur ,  du nombre de coup  et du temps uniquement si le joueur a gagné
            StreamWriter sw = new StreamWriter(cheminfichier, true);
            sw.WriteLine(nom + "," + temps + "," + i + ",");
            sw.Close();
        }

        static string Compare(string strProposition, string strSolution)
        {
            //initialisation
            int i, j;
            int juste = 0;
            int flou = 0;
            char[] proposition = strProposition.ToCharArray();
            char[] solution = strSolution.ToCharArray();

            i = 0;
            while (i < solution.Length)
            {
                if (solution[i] == proposition[i])
                {
                    juste += 1; //On  a trouvé une pièce juste
                    solution[i] = '#'; //il ne faudrait pas la recompter
                    proposition[i] = '#'; //celle la non plus
                }
                i++;
            }

            i = 0;
            while (i < solution.Length)
            {
                if (solution[i] != '#')
                {
                    j = 0;
                    while ((j < solution.Length) && (solution[i] != proposition[j]))
                    {
                        j++;
                    }
                    if (j < solution.Length)
                    {
                        proposition[j] = '#';
                        flou++;
                    }
                }
                i++;
            }

            string retour = "";
            for (int v = 0; v < flou; v++)
            {
                retour += "°";
            }

            for (int b = 0; b < juste; b++)
            {
                retour += "*";
            }
            return retour;
        }

        static bool RunV1()
        {
            Console.Clear();
            string cache = GenereProposition1();
            string reponse;
            int nbre_essai = 8;

            affichage_V1();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("\nVous avez {0} d'essais pour gagner la partie. Et les chiffres vont de 0 à 7\n", nbre_essai));
            Console.ForegroundColor = ConsoleColor.White;
            DateTime newDate1 = DateTime.Now; // depart compteur de temps

            for (int i = 1; i < nbre_essai + 1; i++)
            {
                Console.Write("Essai {0} :\n", i);
                if (i == nbre_essai)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"/!\ DERNIER ESSAI /!\");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                reponse = SaisieProposition1();
                string resultat = Compare(reponse, cache);
                Console.WriteLine(resultat);


                if ((reponse == cache) & (i <= nbre_essai))
                {
                    DateTime newDate2 = DateTime.Now; //  arret du compteur 
                    TimeSpan ts = newDate2 - newDate1;
                    int temps = ts.Seconds;
                    AjouteHighScore(@"C:\Mastermind\record1.txt", temps, i);
                    return true;
                }


            }
            Console.Clear();
            Console.WriteLine(" Le bon code était {0} ", cache);
            return false;
        }

        static bool RunV2()
        {
            Console.Clear();
            string cache = GenereProposition2();
            string reponse;
            int nbre_essai = 10;

            affichage_V2();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(string.Format("\nVous avez {0} d'essais pour gagner la partie. Et les chiffres vont de 0 à 8\n", nbre_essai));
            Console.ForegroundColor = ConsoleColor.White;
            DateTime newDate1 = DateTime.Now; // depart compteur de temps

            for (int i = 1; i < nbre_essai + 1; i++)
            {
                Console.Write("Essai {0} :\n", i);
                if (i == nbre_essai)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"/!\ DERNIER ESSAI /!\");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                reponse = SaisieProposition2();
                string resultat = Compare(reponse, cache);
                Console.WriteLine(resultat);

                if ((reponse == cache) & (i <= nbre_essai))
                {
                    DateTime newDate2 = DateTime.Now; //  arret du compteur 
                    TimeSpan ts = newDate2 - newDate1;
                    int temps = ts.Seconds;
                    AjouteHighScore(@"C:\Mastermind\record2.txt", temps, nbre_essai);
                    return true;
                }
            }
            Console.Clear();
            Console.WriteLine(" Le bon code était {0} ", cache);
            return false;
        }
    }
    //FIN DU PROGRAMME
}


