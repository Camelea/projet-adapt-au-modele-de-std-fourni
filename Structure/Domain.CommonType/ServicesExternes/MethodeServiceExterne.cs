using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{/// <summary>
 /// Classe qui permet de récupérer la liste des services externes  
 /// </summary>
	class MethodeServiceExterne
	{
		#region Attributs

		public string Nom;
		public string Description;
		public List<Propriete> Proprietes;



		#endregion

		#region Constructeur 
		public MethodeServiceExterne(string nom, string description, List<Propriete> proprietes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Proprietes = proprietes;
		}
		#endregion

		#region Méthodes 

		public string ToString(string data)
		{
			var res = "///<summary>" + "\r\n" + "///" + " " + this.Description + "\r\n" + "/// </summary>" + "\r\n" + data + "public" + "{ get; set;}";
			return res;
		}

		/// <summary>
		/// Fonction qui retourne les noms des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsClassesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][1]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1]/ following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1]/ following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
			var res = "";
				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					res = res + (isbn2.InnerText);
				}

		
			return res;


		}




		/// <summary>
		/// Fonction qui retourne la listes des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeServiceExterne> MethodesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsClassesServicesExternes(doc, nsmgr);
			List<MethodeServiceExterne> servicesExternes = new List<MethodeServiceExterne>();
			
			for (int i = 1; i < noms.Count +1 ; i++)
			{
				string descriptions = DescriptionServicesExternes(doc, nsmgr,i);
				List<Propriete> proprietes = Propriete.ProprietesServicesExternes(doc, nsmgr,i);
				servicesExternes.Add(new MethodeServiceExterne(noms[i-1], descriptions, proprietes));

			}
			return servicesExternes;

		}













		#endregion


	}
}
