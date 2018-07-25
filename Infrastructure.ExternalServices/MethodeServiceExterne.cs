using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Infrastructure.ExternalServices
{
	class MethodeServiceExterne
	{
		#region Attributs 

		public string Nom;
		public List<DescriptionServiceExterne> Descriptions;
		public List<ParametreServiceExterne> ParametresMethode;
		public List<TypeRetourServiceExterne> TypesRetour;
		public string Algorithme;
		#endregion

		#region Constructeur 

		public MethodeServiceExterne(string nom, List<DescriptionServiceExterne>  descriptions, List<ParametreServiceExterne> parametresMethode, List<TypeRetourServiceExterne> typeRetour, string algorithme)
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
		/// Retourne la liste des noms des méthodes des services externes présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesServiceExterne = new List<List<string>>();

			for (int i = 1; i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count + 1; i++)

			{
				if (i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i +1+ "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i+1) + "] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}
					MethodesServiceExterne.Add(ListeMethodes);

				}
				if (i == ServiceExterne.NomsServiceExterne(doc, nsmgr).Count)
				{
					List<string> ListeMethodes = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodes.Add(isbn2.InnerText);
					}

				}
			}

			return MethodesServiceExterne;


		}


		/// <summary>
		/// Retourne le nombre de methodes de chaque service externe
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesServiceExterne = new List<int>();
			foreach (List<string> liste in NomsMethodesServiceExterne(doc, nsmgr))
			{
				NombreMethodesServiceExterne.Add(liste.Count);

			}
			return NombreMethodesServiceExterne;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des services externes
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeServiceExterne>> MethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<MethodeServiceExterne>> methodes = new List<List<MethodeServiceExterne>>();
			List<List<string>> nomsMethodes = NomsMethodesServiceExterne(doc, nsmgr);
			List<List<string>> algorithmes = AlgorithmesMethodesServiceExterne(doc, nsmgr);
			List<List<DescriptionServiceExterne>> descriptions =  DescriptionServiceExterne.DescriptionsMethodesServiceExterne(doc, nsmgr);
			List<List<ParametreServiceExterne>> parametresMethodes = ParametreServiceExterne.ParametresMethodesServiceExterne(doc, nsmgr);
			List<List<TypeRetourServiceExterne>> typesRetour = TypeRetourServiceExterne.TypeRetourMethodesServiceExternes(doc, nsmgr);
			for (int i = 1; i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesServiceExterne(doc, nsmgr)[i - 1] != 0)
				{
					List<MethodeServiceExterne> methodesServiceExterne = new List<MethodeServiceExterne>();

					for (int cmp = 0; cmp < NombreMethodesServiceExterne(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesServiceExterne.Add(new MethodeServiceExterne(nomsMethodes[i - 1][cmp], descriptions[cmp], parametresMethodes[cmp], typesRetour[cmp], algorithmes[i - 1][cmp]));


					}
					methodes.Add(methodesServiceExterne);
				}


			}
			return methodes;
		}

		/// <summary>
		/// Retourne la liste des Algorithmes des méthodes des services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> AlgorithmesMethodesServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesServiceExterne = new List<List<string>>();

			for (int i = 1; i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesServiceExterne(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					if (i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count || (i == ServiceExterne.NomsServiceExterne(doc, nsmgr).Count && cmp < NombreMethodesServiceExterne(doc, nsmgr)[i - 1] - 1))
					{
						List<string> ListeMethodesServiceExterne = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i+ "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodesServiceExterne.Add(res);
						MethodesServiceExterne.Add(ListeMethodesServiceExterne);

					}



					if (i == ServiceExterne.NomsServiceExterne(doc, nsmgr).Count && cmp == NombreMethodesServiceExterne(doc, nsmgr)[i - 1] - 1)
					{
						List<string> ListeMethodeServiceExterne = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']]["+i+ "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp+1)+ "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodeServiceExterne.Add(res);
						MethodesServiceExterne.Add(ListeMethodeServiceExterne);

					}
					if (i < ServiceExterne.NomsServiceExterne(doc, nsmgr).Count && cmp == NombreMethodesServiceExterne(doc, nsmgr)[i - 1] - 1)
					{
						List<string> ListeMethodeServiceExterne = new List<string>();
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + i + "] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][3]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][4]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][" + (i + 1) + "] /preceding-sibling:: w:p)]";

						nodeList2 = root.SelectNodes(xpath, nsmgr);
						var res = "";
						foreach (XmlNode isbn2 in nodeList2)
						{
							res = res + (isbn2.InnerText);
						}
						ListeMethodeServiceExterne.Add(res);
						MethodesServiceExterne.Add(ListeMethodeServiceExterne);

					}
				}
			}


			return MethodesServiceExterne;
		}

		

		#endregion

	}
}
