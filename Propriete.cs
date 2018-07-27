using ConsoleApp4.Application.Interface;
using ConsoleApp4.Domain.CommonType.Metiers;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	public class Propriete
	{
		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public Propriete(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return (Nom + " " + Type + " " + Description);

		}

		#region ServicesExternes
		/// <summary>
		/// Renvoie la liste des informations de parametres des services externes 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Propriete>> ProprietesServicesExternes(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeProprietesServicesExternes = new List<List<string>>();
			List<List<Propriete>> ProprietesServicesExternes = new List<List<Propriete>>();

			for (int i = 1; i < ServiceExterne.NomsClassesServicesExternes(doc, nsmgr).Count + 1; i++)
			{
				if (i < ServiceExterne.NomsClassesServicesExternes(doc, nsmgr).Count)
				{
					ListeProprietesServicesExternes.Add(new List<string>());
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesServicesExternes[i - 1].Add(isbn2.InnerText);

					}
					ProprietesServicesExternes.Add(ListeAParametresEntrants(ListeProprietesServicesExternes[i - 1]));
				}
				if (i == ServiceExterne.NomsClassesServicesExternes(doc, nsmgr).Count)
				{
					ListeProprietesServicesExternes.Add(new List<string>());
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling::w:tbl / w:tr /w:tc)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesServicesExternes[i - 1].Add(isbn2.InnerText);

					}
					ProprietesServicesExternes.Add(ListeAParametresEntrants(ListeProprietesServicesExternes[i - 1]));
				}
			}
			return ProprietesServicesExternes;

		}
		#endregion

		#region Metiers 

		/// <summary>
		/// Renvoie la liste des informations de parametres des metier pour le métier donné en parametre 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Propriete> ProprietesMetier(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeProprietesMetier = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";


			if (i == Metier.NomsClassesMetier(doc, nsmgr).Count)
			{

				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3]/preceding-sibling::w:tbl / w:tr /w:tc)]";
			}
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesMetier.Add(isbn2.InnerText);

					}

		return ListeAParametresEntrants(ListeProprietesMetier);

		}


		#endregion


		#region Enumerations 
		/// <summary>
		/// Renvoie la liste des informations de parametres des enumerations 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Propriete> ValeursEnumeration(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeValeursEnumerations = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

			if (i == Metier.NomsClassesMetier(doc, nsmgr).Count)
			{
				 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /preceding-sibling::w:tbl / w:tr /w:tc)]";
			}

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeValeursEnumerations.Add(isbn2.InnerText);

					}
				
			
			return (ListeAParametresEntrants(ListeValeursEnumerations));

		}

		#endregion

		#region Objets Presentation

		/// <summary>
		/// Renvoie la liste des informations de parametres des objets de presentation 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<Propriete>> ProprietesObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeProprietesObjetsPresentation = new List<List<string>>();
			List<List<Propriete>> ProprietesObjetsPresentation = new List<List<Propriete>>();

			for (int i = 1; i < ObjetPresentation.NomsObjetsPresentation(doc, nsmgr).Count + 1; i++)
			{
				if (i < ObjetPresentation.NomsObjetsPresentation(doc, nsmgr).Count)
				{
					ListeProprietesObjetsPresentation.Add(new List<string>());
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesObjetsPresentation[i - 1].Add(isbn2.InnerText);

					}
					ProprietesObjetsPresentation.Add(ListeAParametresEntrants(ListeProprietesObjetsPresentation[i - 1]));

				}
				if (i == ObjetPresentation.NomsObjetsPresentation(doc, nsmgr).Count)
				{
					ListeProprietesObjetsPresentation.Add(new List<string>());
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /preceding-sibling::w:tbl / w:tr /w:tc)]";

					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						ListeProprietesObjetsPresentation[i - 1].Add(isbn2.InnerText);

					}
					ProprietesObjetsPresentation.Add(ListeAParametresEntrants(ListeProprietesObjetsPresentation[i - 1]));
				}
			}
			return ProprietesObjetsPresentation;

		}



		#endregion



		/// <summary>
		/// Renvoie la liste des proprietes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<Propriete> ListeAParametresEntrants(List<string> liste)
		{
			List<Propriete> ListeParametresEntrantsClasses = new List<Propriete>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresEntrantsClasses.Add(new Propriete(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresEntrantsClasses;
		}




		
		#endregion
	}
}