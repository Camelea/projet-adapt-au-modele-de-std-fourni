using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{

	public class Methode
	{
		#region Attributs 

		public string Nom { get; private set; }
		public List<DescriptionMethode> Descriptions { get; private set; }
		public List<ParametreMethode> ParametresMethode { get; private set; }
		public List<TypeRetour> TypesRetour { get; private set; }
		public string Algorithme { get; private set; }
		#endregion

		#region Constructeur 

		public Methode(string nom, List<DescriptionMethode> descriptions, List<ParametreMethode> parametresMethode, List<TypeRetour> typeRetour,string algorithme)
		{
			this.Nom = nom;
			this.Descriptions = descriptions;
			this.ParametresMethode = parametresMethode;
			this.TypesRetour = typeRetour;
			this.Algorithme = algorithme;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom );
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des entités présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesEntites = new List<List<string>>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				List<string> ListeMethodes = new List<string>();
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][8]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][8]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeMethodes.Add(isbn2.InnerText);
				}
				MethodesEntites.Add(ListeMethodes);

			}

			return MethodesEntites;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque entité
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesEntite = new List<int>();
			foreach (List<string> liste in NomsMethodesEntites(doc, nsmgr))
			{
				NombreMethodesEntite.Add(liste.Count);

			}
			return NombreMethodesEntite;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des entités
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Methode>> Methodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<Methode>> methodes = new List<List<Methode>>();
			List<List<string>> nomsMethodes = NomsMethodesEntites(doc, nsmgr);
			List<List<string>> algorithmes = AlgorithmesMethodesEntites(doc, nsmgr);
			List<List<DescriptionMethode>> descriptionsMethodes = DescriptionMethode.DescriptionsMethodesEntites(doc, nsmgr);
			List<List<ParametreMethode>> parametresMethodes = ParametreMethode.ParametresMethodesEntites(doc, nsmgr);
			List<List<TypeRetour>> typesRetour = TypeRetour.TypeRetourMethodesEntites(doc, nsmgr);
			for (int i = 1; i <Entite.NomsEntites(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesEntites(doc, nsmgr)[i - 1] != 0)
				{
					List<Methode> methodesInterfacesServices = new List<Methode>();

					for (int cmp = 0; cmp < NombreMethodesEntites(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfacesServices.Add(new Methode(nomsMethodes[i - 1][cmp], descriptionsMethodes[cmp], parametresMethodes[cmp], typesRetour[cmp], algorithmes[i-1][cmp]));


					}
					methodes.Add(methodesInterfacesServices);
				}


			}
			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des entités présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> AlgorithmesMethodesEntites(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesEntites = new List<List<string>>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesEntites(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					if (i < Entite.NomsEntites(doc, nsmgr).Count || (i == Entite.NomsEntites(doc, nsmgr).Count && cmp < NombreMethodesEntites(doc, nsmgr)[i - 1]-1))
					{
						List<string> ListeMethodesEntites = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							ListeMethodesEntites.Add(isbn2.InnerText);
						}
						MethodesEntites.Add(ListeMethodesEntites);

					}



					if (i == Entite.NomsEntites(doc, nsmgr).Count && cmp == NombreMethodesEntites(doc, nsmgr)[i - 1]-1)
					{
						List<string> ListeMethodesEntites = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
							ListeMethodesEntites.Add(isbn2.InnerText);
						}
						MethodesEntites.Add(ListeMethodesEntites);

					}
				}
			}


			return MethodesEntites;
		}

		



		#endregion
	}

}
