using ConsoleApp4.Domain.CommonType.Services_Externes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.Interface.De.Registre
{
	public class TypeRetourInterfaceRegistre
	{
		#region Attributs
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public TypeRetourInterfaceRegistre( string type, string description)
		{
			this.Type = type;
			this.Description = description;

		}

		#endregion

		#region Méthodes

		public override string ToString()
		{
			return ( Type + " " + Description);

		}

		
		public static List<TypeRetourInterfaceRegistre> TypeRetourMethodesInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTypeRetourInterfacesRegistres = new List<string>();

				if (MethodeInterfaceRegistre.NombreMethodesInterfacesRegistres(doc, nsmgr,i - 1) != 0)
				{
						
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][4]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{

					ListeTypeRetourInterfacesRegistres.Add(isbn2.InnerText);

				}
						}
				
				
			return ListeATypeRetourInterfaceRegistre(ListeTypeRetourInterfacesRegistres);

		}



		


		/// <summary>
		/// Renvoie la liste des types de retour des interfaces de registre associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<TypeRetourInterfaceRegistre> ListeATypeRetourInterfaceRegistre(List<string> liste)
		{
			List<TypeRetourInterfaceRegistre> ListeTypeRetourInterfaceRegistre = new List<TypeRetourInterfaceRegistre>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourInterfaceRegistre.Add(new TypeRetourInterfaceRegistre(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourInterfaceRegistre;
		}
		#endregion
	}
}
