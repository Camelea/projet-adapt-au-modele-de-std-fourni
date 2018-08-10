using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Entites
{/// <summary>
/// Classe qui permet de récupérér le constructeur d'instanciation 
/// </summary>
	public class ConstructeurInstanciation
	{
		#region Attributs

		public string Description { get; private set; }
		public List<Parametre> Parametres { get; private set; }
		public string Algorithme { get; private set; }

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

		public override string ToString()
		{ StringBuilder paramDoc = new StringBuilder();
			foreach (Parametre p in this.Parametres) {
				paramDoc.Append("/// <param name=\"" + p.Nom.ToLower() + "\">" + p.Description + "." + "</param>" + "r\n") ;
			}
			var doc = "/// <summary>" + "\r\n" + "///" + this.Description + "\r\n" + "/// </summary>" + "\r\n" + paramDoc.ToString();
			return doc;
		}

		public string ParametresToString()
		{

			StringBuilder paramMethode = new StringBuilder();
			paramMethode.Append("(");


			foreach (Parametre p in this.Parametres)
			{

				if (p == this.Parametres.Last())
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + " )" + "\r\n");
				}
				else
				{
					paramMethode = paramMethode.Append(p.Type + p.Nom + ",");
				}
			}
			return paramMethode.ToString();

		
	}

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

			StringBuilder res = new StringBuilder();
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2] /preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}
				
			return res.ToString();


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

			StringBuilder res = new StringBuilder();
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] / preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}
				
			return res.ToString();


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
