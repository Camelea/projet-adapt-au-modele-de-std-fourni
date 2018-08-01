using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	class ParametreInterfaceServiceExterne
	{
		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public ParametreInterfaceServiceExterne(string nom, string type, string description)
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

		
		public static List<ParametreInterfaceServiceExterne> ParametresMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresInterfaceServiceExterne = new List<string>();


				if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr,i - 1)!= 0)
				{


						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeParametresInterfaceServiceExterne.Add(isbn2.InnerText);

						}
					
					}

				

			return (ListeAParametresInterfaceServiceExterne(ListeParametresInterfaceServiceExterne));

		}




		/// <summary>
		/// Renvoie la liste des parametres des methodes des interfaces de services externes associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreInterfaceServiceExterne> ListeAParametresInterfaceServiceExterne(List<string> liste)
		{
			List<ParametreInterfaceServiceExterne> ListeParametreInterfaceServiceExterne = new List<ParametreInterfaceServiceExterne>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametreInterfaceServiceExterne.Add(new ParametreInterfaceServiceExterne(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametreInterfaceServiceExterne;
		}
		#endregion
	}
}
