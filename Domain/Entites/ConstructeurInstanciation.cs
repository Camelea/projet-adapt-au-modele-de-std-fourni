using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{
	public class ConstructeurInstanciation
	{
		#region Attributs

		public string Description;
		public List<Parametre> Parametres;
		public string Algorithme;

		#endregion


		#region Constructeur 

		protected ConstructeurInstanciation(string description,List<Parametre> parametres, string algorithme)
		{
			this.Description = description;
			this.Algorithme = algorithme;
			this.Parametres = parametres;
		}
		#endregion


		#region Méthodes 


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des constructeurs d'instanciation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsConstructeursInstanciation = new List<string>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeDescriptionsConstructeursInstanciation.Add(res);

			}
			return ListeDescriptionsConstructeursInstanciation;


		}

		/// <summary>
		/// Fonction qui retourne la liste des algorithmes des constructeurs d'instanciation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> AlgorithmesConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeAlgorithmesConstructeursInstanciation = new List<string>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeAlgorithmesConstructeursInstanciation.Add(res);

			}
			return ListeAlgorithmesConstructeursInstanciation;


		}


		/// <summary>
		/// Fonction qui permet de retourner la liste des constructeurs d'instanciation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ConstructeurInstanciation> ConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<ConstructeurInstanciation> constructeursInstanciation = new List<ConstructeurInstanciation>();
			List<string> algorithmes = AlgorithmesConstructeursInstanciation(doc, nsmgr);
			List<string> descriptions = DescriptionsConstructeursInstanciation(doc, nsmgr);
			List<List<Parametre>> parametres = Parametre.ParametresEntites(doc, nsmgr);


			for (int i = 0; i < Entite.NomsEntites(doc, nsmgr).Count; i++)
			{
				constructeursInstanciation.Add(new ConstructeurInstanciation(descriptions[i], parametres[i],algorithmes[i]));


			}
			return constructeursInstanciation;
		}

		#endregion

	}
}
