using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	class MethodeInterfaceServiceExterne
	{
		#region Attributs 

		public string Nom;
		public string Description;
		public List<ParametreInterfaceServiceExterne> ParametresInterfaceServiceExterne;
		public List<TypeRetourInterfaceServiceExterne> TypesRetourInterfaceServiceExterne;

		#endregion

		#region Constructeur 

		public MethodeInterfaceServiceExterne(string nom, string description, List<ParametreInterfaceServiceExterne> parametresInterfaceServiceExterne, List<TypeRetourInterfaceServiceExterne> typesRetourInterfaceServiceExterne)
		{
			this.Nom = nom;
			this.Description = description;
			this.ParametresInterfaceServiceExterne = parametresInterfaceServiceExterne;
			this.TypesRetourInterfaceServiceExterne = typesRetourInterfaceServiceExterne;

		}

		#endregion

		#region Méthodes

		/// <summary>
		/// Retourne la liste des noms des méthodes des interfaces de services externes présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> NomsMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesInterfaceServiceExterne = new List<List<string>>();

			for (int i = 1; i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1; i++)

			{
				if (i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count)
				{
					List<string> ListeMethodesInterfaceServiceExterne = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i +1)+ "]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesInterfaceServiceExterne.Add(isbn2.InnerText);
					}
					MethodesInterfaceServiceExterne.Add(ListeMethodesInterfaceServiceExterne);

				}

				if (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count)
				{
					List<string> ListeMethodesInterfaceServiceExterne = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading4']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']])]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesInterfaceServiceExterne.Add(isbn2.InnerText);
					}
					MethodesInterfaceServiceExterne.Add(ListeMethodesInterfaceServiceExterne);
				}
			}

			return MethodesInterfaceServiceExterne;


		}

		/// <summary>
		/// Retourne la liste des descriptions des méthodes des interfaces de service externe présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<string>> DescriptionsMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> MethodesInterfaceServiceExterne = new List<List<string>>();

			for (int i = 1; i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1; i++)

			{
				for (int cmp = 0; cmp < NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1] + 1; cmp++)
				{
					List<string> ListeMethodesInterfaceServiceExterne = new List<string>();
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']]["+(cmp+1)+"]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeMethodesInterfaceServiceExterne.Add(isbn2.InnerText);
					}
					MethodesInterfaceServiceExterne.Add(ListeMethodesInterfaceServiceExterne);

				}
			}

			return MethodesInterfaceServiceExterne;


		}

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de service externe 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<int> NombreMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<int> NombreMethodesInterfaceServiceExterne = new List<int>();
			foreach (List<string> liste in NomsMethodesInterfaceServiceExterne(doc, nsmgr))
			{
				NombreMethodesInterfaceServiceExterne.Add(liste.Count);

			}
			return NombreMethodesInterfaceServiceExterne;
		}

		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de de services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<MethodeInterfaceServiceExterne>> MethodeServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<List<MethodeInterfaceServiceExterne>> methodes = new List<List<MethodeInterfaceServiceExterne>>();
			List<List<string>> nomsMethodes = NomsMethodesInterfaceServiceExterne(doc, nsmgr);
			List<List<string>> descriptionsMethodes = DescriptionsMethodesInterfaceServiceExterne(doc, nsmgr);
			List<List<ParametreInterfaceServiceExterne>> parametres = ParametreInterfaceServiceExterne.ParametresMethodesInterfaceServiceExterne(doc, nsmgr);
			List<List<TypeRetourInterfaceServiceExterne>> typesRetour = TypeRetourInterfaceServiceExterne.TypeRetourMethodesInterfaceServiceExterne(doc, nsmgr);
			for (int i = 1; i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1; i++)
			{
				if (NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1] != 0)
				{
					List<MethodeInterfaceServiceExterne> methodesInterfaceServiceExterne = new List<MethodeInterfaceServiceExterne>();

					for (int cmp = 0; cmp < NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1]; cmp++)
					{

						methodesInterfaceServiceExterne.Add(new MethodeInterfaceServiceExterne(nomsMethodes[i - 1][cmp], descriptionsMethodes[i - 1][cmp], parametres[cmp], typesRetour[cmp]));


					}
					methodes.Add(methodesInterfaceServiceExterne);
				}




			}
			return methodes;

		}

		#endregion
	}
}
