using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class Methode
	{
		public string Nom;
		public string Description;
		public List<ParametreMethode> ParametresMethode;
		public List<TypeRetour> TypeRetour;

#endregion

		#region Constructeur 

		public Methode(string nom, string description, List<ParametreMethode> parametresMethode, List<TypeRetour> typeRetour)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresMethode = parametresMethode;
			this.TypeRetour = typeRetour;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
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
		/// Retourne la liste des descriptions des méthodes des interfaces de service présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> DescriptionsMethodesinterfacesService(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesInterfacesServices = new List<List<string>>();

			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					List<string> ListeMethodesInterfacesServices = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesInterfacesServices.Add(isbn2.InnerText);
					}
					MethodesInterfacesServices.Add(ListeMethodesInterfacesServices);

				}
			}

			return MethodesInterfacesServices;


		}

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesInterfacesServices = new List<int>();
			foreach (List<string> liste in NomsMethodesInterfacesServices(doc, nsmgr))
			{
				NombreMethodesInterfacesServices.Add(liste.Count);

			}
			return NombreMethodesInterfacesServices;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Methode>> Methodes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<Methode>> methodes = new List<List<Methode>>();
			List<List<string>> nomsMethodes = NomsMethodesInterfacesServices(doc, nsmgr);
			List<List<string>> descriptionsMethodes = DescriptionsMethodesinterfacesService(doc, nsmgr);
			List<List<ParametreSortant>> parametresSortants = ParametreSortant.ParametresSortantsMethodesClasses(doc, nsmgr);
			List<List<ParametreEntrant>> parametresEntrants = ParametreEntrant.ParametresEntrantsMethodesClasses(doc, nsmgr);
			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0)
				{
					List<Methode> methodesInterfacesServices = new List<Methode>();

					for (int cmp = 0; cmp < NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfacesServices.Add(new Methode(nomsMethodes[i - 1][cmp], descriptionsMethodes[i - 1][cmp], parametresEntrants[cmp], parametresSortants[cmp]));


					}
					methodes.Add(methodesInterfacesServices);
				}




			}
			return methodes;
		}





		#endregion
	}
}