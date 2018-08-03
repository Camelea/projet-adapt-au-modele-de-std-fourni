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
			var doc = "/// <returns>" + this.Description + "." + "</returns>";
			return doc;

		}



		public static TypeRetourInterfaceRegistre TypeRetourMethodesInterfacesRegistres(XmlDocument doc, XmlNamespaceManager nsmgr,int i,int cmp )
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
				
				
			return new TypeRetourInterfaceRegistre(ListeTypeRetourInterfacesRegistres[2], ListeTypeRetourInterfacesRegistres[3]);

		}



		#endregion
	}
}
