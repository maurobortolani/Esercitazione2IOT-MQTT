using System.Data.SqlClient;

public class Program
{

	static void Main()
	{
		string cS = 
			"Data Source=(LocalDB)\\MSSQLLocalDB;" +
			"AttachDbFilename=C:\\Users\\bortolanim\\Desktop\\Esercitazione2IOT\\Esercitazione2IOT-MQTT\\cal.mdf;" +
			"Integrated Security=True;" +
			"Connect Timeout=30";

		// 1 Acquisire i dati
		Console.Write("Inserisci il cognome del docente: ");
		string Cognome = Console.ReadLine();
		Console.Write("Inserisci il nome del docente: ");
		string Nome = Console.ReadLine();
		Console.Write("Inserisci la materia: ");
		string Materia = Console.ReadLine();

		/*  2 Scriverli nel DB   */

		// 2.1 Creazione della Connessione al DB
		try
		{
			using (SqlConnection connessione = new SqlConnection(cS))
			{				
				connessione.Open();
				// 2.2 Creazione del Comando da eseguire
				string query = 
					"INSERT INTO Docenti " +
					"(Cognome, Nome, Materia, Abilita, DataIns) " +
					"VALUES " +
					$"('{Cognome}', '{Nome}', '{Materia}', 1, " +
					$"'" + DateTime.Now.ToString("MM/dd/yyyy") + "');";
				Console.WriteLine(query);

				// 2.3 Esecuzione del Comando


				connessione.Close();
			}
		}
		catch (Exception errore)
		{
			Console.WriteLine(errore.Message);
		}
	}
}