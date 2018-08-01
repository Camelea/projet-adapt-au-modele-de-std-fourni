using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType
{
	class Enumeration
	{/// <summary>
	 /// Classe qui permet de récupérer les enumerations 
	 /// </summary>
		#region Attributs

		public string Nom;
		public string Description;
		public List<Propriete> Valeurs;



		#endregion

		#region Constructeur 
		public Enumeration(string nom, string description, List<Propriete> valeurs)
		{
			this.Nom = nom;
			this.Description = description;
			this.Valeurs = valeurs;
		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Fonction qui retourne les noms des DTOs enumerations
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClassesEnumeration(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des enumerations
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionEnumeration(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
			var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
				res = res + (isbn2.InnerText);
				}


			return res;


		}


		/// <summary>
		/// Fonction qui retourne la listes des enumerations  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Enumeration> Enumerations(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsClassesEnumeration(doc, nsmgr);
			List<Enumeration> enumerations = new List<Enumeration>();
			for (int i = 1; i < noms.Count+1; i++)
			{
				string descriptions = DescriptionEnumeration(doc, nsmgr,i);
				List<Propriete> proprietes = Propriete.ValeursEnumeration(doc, nsmgr, i);
				enumerations.Add(new Enumeration(noms[i-1], descriptions, proprietes));

			}
			return enumerations;

		}
		#endregion
	}
}
