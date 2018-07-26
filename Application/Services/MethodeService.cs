using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Services
{
	class MethodeService
	{
		#region Attributs 

		public string Nom;
		public List<DescriptionService> Descriptions;
		public List<ParametreService> ParametresMethode;
		public List<TypeRetourService> TypesRetour;
		public string Algorithme;
		#endregion

		#region Constructeur 

		public MethodeService(string nom, List<DescriptionService> descriptions, List<ParametreService> parametresMethode, List<TypeRetourService> typeRetour, string algorithme)
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
			return (this.Nom);
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des services présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesServices = new List<List<string>>();

			for (int i = 1; i < Service.NomsServices(doc, nsmgr).Count + 1; i++)

			{
				if (i < Service.NomsServices(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}
					MethodesServices.Add(ListeMethodes);

				}
				if (i == Service.NomsServices(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}

				}
			}

			return MethodesServices;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque service
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesService = new List<int>();
			foreach (List<string> liste in NomsMethodesServices(doc, nsmgr))
			{
				NombreMethodesService.Add(liste.Count);

			}
			return NombreMethodesService;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des Service
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeService>> MethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<MethodeService>> methodes = new List<List<MethodeService>>();
			List<List<string>> nomsMethodes = NomsMethodesServices(doc, nsmgr);
			List<List<string>> algorithmes = AlgorithmesMethodesServices(doc, nsmgr);
			List<List<DescriptionService>> descriptions = DescriptionService.DescriptionsMethodesServices(doc, nsmgr);
			List<List<ParametreService>> parametresMethodes = ParametreService.ParametresMethodesServices(doc, nsmgr);
			List<List<TypeRetourService>> typesRetour = TypeRetourService.TypeRetourMethodesServices(doc, nsmgr);
			for (int i = 1; i < Service.NomsServices(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesServices(doc, nsmgr)[i - 1] != 0)
				{
					List<MethodeService> methodesInterfacesServices = new List<MethodeService>();

					for (int cmp = 0; cmp < NombreMethodesServices(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfacesServices.Add(new MethodeService(nomsMethodes[i - 1][cmp], descriptions[cmp], parametresMethodes[cmp], typesRetour[cmp], algorithmes[i - 1][cmp]));


					}
					methodes.Add(methodesInterfacesServices);
				}


			}
			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des services présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> AlgorithmesMethodesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesServices = new List<List<string>>();

			for (int i = 1; i < Service.NomsServices(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesServices(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					if (i < Service.NomsServices(doc, nsmgr).Count || (i == Service.NomsServices(doc, nsmgr).Count && cmp < NombreMethodesServices(doc, nsmgr)[i - 1] - 1))
					{
						List<string> ListeMethodesServices = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodesServices.Add(res);
						MethodesServices.Add(ListeMethodesServices);

					}



					if (i == Service.NomsServices(doc, nsmgr).Count && cmp == NombreMethodesServices(doc, nsmgr)[i - 1] - 1)
					{
						List<string> ListeMethodesServices = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodesServices.Add(res);
						MethodesServices.Add(ListeMethodesServices);

					}
				}
			}


			return MethodesServices;
		}
		



		#endregion
	}
}
