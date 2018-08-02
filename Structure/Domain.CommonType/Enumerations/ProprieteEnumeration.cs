using ConsoleApp4.Domain.CommonType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Structure.Domain.CommonType.Enumerations
{
	class ProprieteEnumeration
	{
		#region Attributs
		public string Nom;
		public string Valeur;
		public string Description;

		#endregion

		#region Constructeur 
		public ProprieteEnumeration(string nom, string valeur, string description)
		{
			this.Nom = nom;
			this.Valeur = valeur;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			var doc = "/// <summary>" + "\n" + "/// " + this.Description + "." + "\n" + "/// </summary>" + "\n";
			var res = doc + this.Nom + "= " + this.Valeur;
			return res;
		}

		
		/// <summary>
		/// Renvoie la liste des informations de parametres des enumerations 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<ProprieteEnumeration> ValeursEnumeration(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeValeursEnumerations = new List<string>();

			string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/ preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling::w:tbl / w:tr /w:tc)]";

			if (i == Enumeration.NomsEnumeration(doc, nsmgr).Count)
			{
				xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:tbl / w:tr /w:tc [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] / preceding-sibling::w:tbl / w:tr /w:tc)= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /preceding-sibling::w:tbl / w:tr /w:tc)]";
			}

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeValeursEnumerations.Add(isbn2.InnerText);

			}


			return (ListeAProprietes(ListeValeursEnumerations));

		}

		/// <summary>
		/// Renvoie la liste des proprietes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ProprieteEnumeration> ListeAProprietes(List<string> liste)
		{
			List<ProprieteEnumeration> ListeProprietes = new List<ProprieteEnumeration>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeProprietes.Add(new ProprieteEnumeration(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeProprietes;
		}



		#endregion
	}
}
