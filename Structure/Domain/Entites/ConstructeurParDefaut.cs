using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{/// <summary>
/// Classe qui permet de récupérér le constructeur par defaut d'un entité 
/// </summary>
	public class ConstructeurParDefaut
	{
		#region Attributs

		public string Description { get; private set; }
		public string Algorithme { get; private set; }

		#endregion


		#region Constructeur 

		protected ConstructeurParDefaut(string description, string algorithme)
		{
			this.Description = description;
			this.Algorithme = algorithme;
		}
		#endregion


		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "///" + this.Description + "\r\n" + "/// </summary>" + "\r\n";
			return doc;
		}
		/// <summary>
		/// Fonction qui retourne la liste des descriptions des constructeurs par defaut  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionsConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;


			StringBuilder res = new StringBuilder();
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}
				

			
			return res.ToString();


		}

		/// <summary>
		/// Fonction qui retourne la liste des algorithmes des constructeurs par defaut  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string AlgorithmesConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			StringBuilder res = new StringBuilder();
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

			
			return res.ToString();


		}

		public static ConstructeurParDefaut ConstructeursParDefaut(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

				string algorithmes = AlgorithmesConstructeursParDefaut(doc, nsmgr, i);
				string descriptions = DescriptionsConstructeursParDefaut(doc, nsmgr, i);

			
			return (new ConstructeurParDefaut(descriptions, algorithmes));
		}

		#endregion



	}
}
