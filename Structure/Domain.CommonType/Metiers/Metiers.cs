using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Metiers
{/// <summary>
/// Classe qui permet de récupérer la liste des metiers 
/// </summary>
	class Metier
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Propriete> Proprietes;



		#endregion

		#region Constructeur 
		public Metier(string nom, string description, List<Propriete> proprietes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Proprietes = proprietes;
		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Fonction qui retourne les noms des DTOs métiers  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClassesMetier(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des metiers 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionMetiers(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
			StringBuilder res = new StringBuilder();
			nodeList2 = root.SelectNodes(xpath, nsmgr);
			
				foreach (XmlNode isbn2 in nodeList2)
				{
					res.Append(isbn2.InnerText);
				}

			

			return res.ToString();


		}




		/// <summary>
		/// Fonction qui retourne la listes des metiers  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Metier> Metiers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsClassesMetier(doc, nsmgr);
			List<Metier> metiers = new List<Metier>();
			for (int i = 1; i < noms.Count+1; i++)
			{
				string descriptions = DescriptionMetiers(doc, nsmgr,i);
				List <Propriete> proprietes = Propriete.ProprietesMetier(doc, nsmgr,i);
				metiers.Add(new Metier(noms[i-1], descriptions, proprietes));

			}
			return metiers;

		}













		#endregion


	}
}
