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
		public static string DescriptionsConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				
			return res;


		}

		/// <summary>
		/// Fonction qui retourne la liste des algorithmes des constructeurs d'instanciation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string AlgorithmesConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
		
				var res = "";
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}
				
			return res;


		}


		/// <summary>
		/// Fonction qui permet de retourner la liste des constructeurs d'instanciation
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static ConstructeurInstanciation ConstructeursInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			
			string algorithmes = AlgorithmesConstructeursInstanciation(doc, nsmgr,i);
			string descriptions = DescriptionsConstructeursInstanciation(doc, nsmgr,i);
			List<Parametre> parametres = Parametre.ParametresEntites(doc, nsmgr,i);


			return ( new ConstructeurInstanciation(descriptions, parametres, algorithmes));
		}

		#endregion

	}
}
