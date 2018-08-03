using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class TypeRetourInterfaceService
	{
		#region Attributs
		public string Type { get; private set; }
		public string Description { get; private set; }
		#endregion

		#region Constructeur

		public TypeRetourInterfaceService(string type, string description)
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


		/// <summary>
		/// Fonction qui permet de renvoyer la liste des colonnes de types de retour des interfaces de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static TypeRetourInterfaceService TypesRetourInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeTypeRetourInterfacesServices = new List<string>();


				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1) != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1) + 1; cmp++)
					{
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						if (i == InterfaceService.NomsInterfacesServices(doc, nsmgr).Count && cmp == Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1))
						{

							 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:tbl / w:tr /w:tc)]";
						}
							
						
						if (i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count && cmp == Methode.NombreMethodesInterfacesServices(doc, nsmgr,i - 1) - 1)
						{

							 xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + (i + 1) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";
						}


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourInterfacesServices.Add(isbn2.InnerText);

							}

						
					}
				}
			
			return  new TypeRetourInterfaceService(ListeTypeRetourInterfacesServices[2], ListeTypeRetourInterfacesServices[3]);

		}




		#endregion
	}
}