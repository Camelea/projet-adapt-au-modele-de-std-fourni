using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class TypeRetourInterfaceService
	{
		#region Attributs
		public string Type;
		public string Description;
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
			return ( Type + " " + Description);

		}

		/// <summary>
		/// Fonction qui permet de renvoyer la liste des colonnes de types de retour des interfaces de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<List<TypeRetourInterfaceService>> TypesRetourInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeTypeRetourInterfacesServices = new List<List<string>>();
			List<List<TypeRetourInterfaceService>> TypesRetourInterfacesServices = new List<List<TypeRetourInterfaceService>>();

			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] + 1; cmp++)
					{
						if ((i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1 && cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]) || (i == InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1 && cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]))
						{
							ListeTypeRetourInterfacesServices.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourInterfacesServices[cmp].Add(isbn2.InnerText);

							}
							TypesRetourInterfacesServices.Add(ListeATypeRetourInterfaceService(ListeTypeRetourInterfacesServices[cmp]));

						}
						if (i == InterfaceService.NomsInterfacesServices(doc, nsmgr).Count  && cmp == Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1])
						{
							ListeTypeRetourInterfacesServices.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeTypeRetourInterfacesServices[cmp].Add(isbn2.InnerText);

							}
							TypesRetourInterfacesServices.Add(ListeATypeRetourInterfaceService(ListeTypeRetourInterfacesServices[cmp]));




						}
					}
				}
			}
			return TypesRetourInterfacesServices;

		}


		

		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de types de retour
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<TypeRetourInterfaceService> ListeATypeRetourInterfaceService(List<string> liste)
		{
			List<TypeRetourInterfaceService> ListeTypeRetourInterfacesServices= new List<TypeRetourInterfaceService>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeTypeRetourInterfacesServices.Add(new TypeRetourInterfaceService(liste[i], liste[i + 1]));
			}
			return ListeTypeRetourInterfacesServices;
		}



		#endregion
	}
}