using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{
	public class ConstructeurParDefaut
	{
		#region Attributs

		public string Description;
		public string Algorithme;

		#endregion


		#region Constructeur 

		protected ConstructeurParDefaut(string description, string algorithme)
		{
			this.Description = description;
			this.Algorithme = algorithme;
		}
		#endregion


		#region Méthodes 


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des constructeurs par defaut  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsConstructeursParDefaut = new List<string>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeDescriptionsConstructeursParDefaut.Add(res);

			}
			return ListeDescriptionsConstructeursParDefaut;


		}

		/// <summary>
		/// Fonction qui retourne la liste des algorithmes des constructeurs par defaut  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> AlgorithmesConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeAlgorithmesConstructeursParDefaut = new List<string>();

			for (int i = 1; i < Entite.NomsEntites(doc, nsmgr).Count + 1; i++)

			{
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				ListeAlgorithmesConstructeursParDefaut.Add(res);

			}
			return ListeAlgorithmesConstructeursParDefaut;


		}

		public static List<ConstructeurParDefaut> ConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<ConstructeurParDefaut> constructeursParDefaut = new List<ConstructeurParDefaut>();
			List<string> algorithmes = AlgorithmesConstructeursParDefaut(doc, nsmgr);
			List<string> descriptions = DescriptionsConstructeursParDefaut(doc, nsmgr);


			for (int i = 0; i <Entite.NomsEntites(doc, nsmgr).Count; i++)
			{
				constructeursParDefaut.Add(new ConstructeurParDefaut(descriptions[i], algorithmes[i]));


			}
			return constructeursParDefaut;
		}

		#endregion



	}
}
