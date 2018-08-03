using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Interface.De.Registre
{
	public class ParametreInterfaceRegistre
	{

		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public ParametreInterfaceRegistre(string nom, string type, string description)
		{
			this.Nom = nom;
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			var doc = "/// <param name=\"" + this.Nom + "\">" + this.Description + "." + "</param>";
			return doc;
		}


		public static List<ParametreInterfaceRegistre> ParametresMethodesInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeParametresInterfacesRegistres = new List<string>();

			if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr, i-1 ) != 0)
				{

						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{

							ListeParametresInterfacesRegistres.Add(isbn2.InnerText);

						}
					

				}
			return ListeAParametresRegistres(ListeParametresInterfacesRegistres);

	}


		

		/// <summary>
		/// Renvoie la liste des parametres des methodes des interfaces de registre associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreInterfaceRegistre> ListeAParametresRegistres(List<string> liste)
		{
			List<ParametreInterfaceRegistre> ListeParametreInterfaceRegistreClasses = new List<ParametreInterfaceRegistre>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametreInterfaceRegistreClasses.Add(new ParametreInterfaceRegistre(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametreInterfaceRegistreClasses;
		}
		#endregion
	}
}
