using ConsoleApp4.Domain.CommonType.Services_Externes;
using ConsoleApp4.Structure.Domain.CommonType.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType
{
	class Enumeration
	{
		/// <summary>
		/// Classe qui permet de récupérer les enumerations 
		/// </summary>
	 
		#region Attributs

		public string Nom;
		public string Description;
		public List<ProprieteEnumeration> Valeurs;



		#endregion

		#region Constructeur 
		public Enumeration(string nom, string description, List<ProprieteEnumeration> valeurs)
		{
			this.Nom = nom;
			this.Description = description;
			this.Valeurs = valeurs;
		}
		#endregion

		#region Méthodes 

		public override string ToString()
		{
			var doc = "/// <summary>" + "\r\n" + "/// " + this.Description.Trim() + "." + "\r\n" + "/// </summary>" + "\r\n";
			var prop = "";
			foreach (ProprieteEnumeration p in this.Valeurs)
			{
				prop = prop + "\r\n";

				if (p == this.Valeurs.Last())
				{
					prop = prop + p.ToString() + "\r\n";
				}
				else
				{
					prop = prop + p.ToString() + "," + "\r\n";
				}
				
			}
			var res = doc + "\r\n" +  "public enum " + this.Nom + "\r\n" + "{ " + "\r\n" + prop + "\r\n" + "}";

			return res;

		}

		/// <summary>
		/// Fonction qui retourne les noms des DTOs enumerations
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsEnumeration(XmlDocument doc, XmlNamespaceManager nsmgr)
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
			List<string> noms = NomsEnumeration(doc, nsmgr);
			List<Enumeration> enumerations = new List<Enumeration>();
			for (int i = 1; i < noms.Count+1; i++)
			{
				string descriptions = DescriptionEnumeration(doc, nsmgr,i);
				List<ProprieteEnumeration> proprietes = ProprieteEnumeration.ValeursEnumeration(doc, nsmgr, i);
				enumerations.Add(new Enumeration(noms[i-1], descriptions, proprietes));

			}
			return enumerations;

		}
		#endregion
	}
}
