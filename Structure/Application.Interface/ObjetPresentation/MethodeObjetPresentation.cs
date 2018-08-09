using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Structure.Application.Interface.ObjetPresentation
{
	class MethodeObjetPresentation
	{
		#region Attributs

		public string Nom;
		public string Description;
		public Propriete Propriete;



		#endregion

		public string ToString(string data)
		{
			var res = "///<summary>" + "\r\n" + "///" + " " + this.Description + "\r\n" + "/// </summary>" + "\r\n" + data + "public" + this.Propriete.GetType() + this.Propriete.Nom + "{ get; set;}" ;
			return res;
		}


		#region Constructeur 
		public MethodeObjetPresentation(string nom, string description, Propriete propriete)
		{
			this.Nom = nom;
			this.Description = description;
			this.Propriete = propriete;
		}
		#endregion

		#region Méthodes 


		/// <summary>
		/// Fonction qui retourne les noms des objets de presentation  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]
				/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][3]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;
		}


		/// <summary>
		/// Fonction qui retourne la liste des descriptions des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static string DescriptionObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";
			StringBuilder res = new StringBuilder();
			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				res.Append(isbn2.InnerText);
			}

			return res.ToString();


		}
		/// <summary>
		/// Fonction qui retourne la listes des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<MethodeObjetPresentation> MethodesObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<string> noms = NomsObjetsPresentation(doc, nsmgr);
			List<MethodeObjetPresentation> methodesObjetsPresentation = new List<MethodeObjetPresentation>();

			for (int i = 0; i < noms.Count; i++)
			{
				string descriptions = DescriptionObjetsPresentation(doc, nsmgr, i);
				Propriete proprietes = Propriete.ProprietesObjetsPresentation(doc, nsmgr, i);
				methodesObjetsPresentation.Add(new MethodeObjetPresentation(noms[i], descriptions, proprietes));

			}
			return methodesObjetsPresentation;

		}
		#endregion


	}
}