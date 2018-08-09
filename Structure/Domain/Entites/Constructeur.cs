using ConsoleApp4.Domain.Entites;
using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Domain.CommonType.Services_Externes
{
	/// <summary>
	/// Classe qui permet de récupérer le constructeur d'une table 
	/// </summary>
	/// 
	public class Constructeur
	{
		#region Attributs

		public ConstructeurParDefaut ConstructeurParDefautEntite { get; private set; }
		public ConstructeurInstanciation ConstructeurInstanciationEntite { get; private set; }

		#endregion

		#region Constructeur 

		public Constructeur(ConstructeurParDefaut constructeurParDefaut, ConstructeurInstanciation constructeurInstanciation)
		{
			this.ConstructeurParDefautEntite = constructeurParDefaut;
			this.ConstructeurInstanciationEntite = constructeurInstanciation;
		}

		#endregion

		#region Méthodes

		public static bool AConstructeurInstanciation(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;

			List<string> NombreConstructeurs = new List<string>();
			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][6]/ following-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']])= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][7] /preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				NombreConstructeurs.Add(isbn2.InnerText);
			}

			return (NombreConstructeurs.Count == 2);

		}

		public string ToString(string constructeurDefaut , string constructeurInitialisation)
		{	
			return (this.ConstructeurParDefautEntite.ToString() + constructeurDefaut + this.ConstructeurInstanciationEntite + constructeurInitialisation);
			
		}

		public string ToStringSansConstructeurInstanciation(string constructeurDefaut)
		{
			return (this.ConstructeurParDefautEntite.ToString() + constructeurDefaut);
		}

		/// <summary>
		/// Renvoie la list des constructeurs des enites 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static Constructeur Constructeurs(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{
	
				ConstructeurParDefaut constructeursParDefaut = ConstructeurParDefaut.ConstructeursParDefaut(doc, nsmgr, i);
			

			if (AConstructeurInstanciation(doc, nsmgr, i))
			{
				ConstructeurInstanciation constructeursInstanciation = ConstructeurInstanciation.ConstructeursInstanciation(doc, nsmgr, i);
				return new Constructeur(constructeursParDefaut, constructeursInstanciation);
			}

			return new Constructeur(constructeursParDefaut, null);
		}



		#endregion
	}
}