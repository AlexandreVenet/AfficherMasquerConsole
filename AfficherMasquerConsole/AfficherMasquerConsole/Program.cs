using System.Runtime.InteropServices;

namespace AfficherMasquerConsole
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.Title = "Youpi la vie !";

            //--------------------------------------

            if (args == null || args.Length == 0)
			{
				Console.WriteLine("Arguments requis.");
				return;
			}

			string terme = args[0];
			Console.WriteLine("Terme : " + terme);
			// Tester ce terme...

			if (args.Length < 2)
			{
				Console.WriteLine("Argument d'affichage requis.");
				return;
			}

			string afficherMasquer = args[1];
			if (!afficherMasquer.Equals("afficher", StringComparison.OrdinalIgnoreCase) && !afficherMasquer.Equals("masquer", StringComparison.OrdinalIgnoreCase))
			{
				Console.WriteLine("L'argument d'affichage prend la valeur 'Afficher' ou 'Masquer', quelle que soit la casse.");
				return;
			}
			Console.WriteLine("Mode d'affichage : " + afficherMasquer);

			IntPtr handle = GetConsoleWindow();
			ShowWindow(handle, ConsoleAfficherParametre.Afficher);
			if (afficherMasquer.Equals("masquer"))
			{
				ShowWindow(handle, ConsoleAfficherParametre.Masquer);
			}

			string dateDemandee = null;
			if (args.Length == 3)
			{
				dateDemandee = args[2];
				Console.WriteLine("Date demandée : " + dateDemandee);
				// Tester la date...
			}

			//--------------------------------------

			Console.WriteLine("Début");
			Agir().Wait();
			Console.WriteLine("Fin");
		}


		// Nom de méthode spécifique
		[DllImport("kernel32.dll")]
		static extern IntPtr GetConsoleWindow();

		// Nom de méthode spécifique
		[DllImport("user32.dll")]
		static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


		private static async Task Agir()
		{
			int secondes = 10;
			await Task.Delay(1000 * secondes);
           Console.WriteLine("L'action est faite.");
        }
	}
}
