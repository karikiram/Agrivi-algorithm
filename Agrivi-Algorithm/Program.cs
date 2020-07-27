using System;

class Program
{

	static int kolTaxi = 3;
	static int kolPutnika = 3;
	static int maxRandom = 1000;
	private static readonly Random random = new Random();

	//Trazenje najnize cijene po stupcu
	public static int[,] ProvjeraNajnizi(int[,] mapa)
	{
		int najnizaCijenaPoRedu, x = kolPutnika, y = kolTaxi;
		int[,] mapaNajnizihCijena = new int[kolTaxi, kolPutnika];

		for (int i = 0; i < mapa.GetLength(0); i++)
		{
			najnizaCijenaPoRedu = maxRandom;

			for (int j = 0; j < mapa.GetLength(1); j++)
			{
				if (mapa[i, j] <= najnizaCijenaPoRedu && ProvjeraPoTaksiju(mapaNajnizihCijena, j))
				{
					if (najnizaCijenaPoRedu != maxRandom)
					{
						mapaNajnizihCijena[x, y] = 0;
					}
					najnizaCijenaPoRedu = mapa[i, j];
					mapaNajnizihCijena[i, j] = mapa[i, j];
					x = i;
					y = j;
				}
			}
		}
		return mapaNajnizihCijena;
	}

	//Provjera stupaca ako postoji vec najniza cijena za tog taksista
	public static bool ProvjeraPoTaksiju(int[,] mapaNajnizihCijena, int j)
	{
		bool najnizi = true;
		for (int i = 0; i < mapaNajnizihCijena.GetLength(0); i++)
		{
			if (mapaNajnizihCijena[i, j] != 0)
			{
				najnizi = false;
			}
		}
		return najnizi;
	}

	//Generiranje X troskova od strane taksista za svakog putnika
	public static int[,] Mapa(int[,] mapa)
	{
		for (int i = 0; i < mapa.GetLength(0); i++)
		{
			for (int j = 0; j < mapa.GetLength(1); j++)
			{
				mapa[i, j] = random.Next(maxRandom);
			}
		}

		Ispis(mapa);
		Console.WriteLine();

		return mapa;
	}

	public static void Ispis(int[,] mapa)
	{
		for (int i = 0; i < mapa.GetLength(0); i++)
		{
			for (int j = 0; j < mapa.GetLength(1); j++)
			{
				Console.Write(mapa[i, j] + " ");
			}
			Console.WriteLine("");
		}
	}

	public static void Main()
	{
		int[,] mapa = new int[kolTaxi, kolPutnika];
		Ispis(ProvjeraNajnizi(Mapa(mapa)));
	}
}