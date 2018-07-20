using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class ParametreSortant
	{
		#region Attributs
		public string Type;
		public string Description;
		#endregion

		#region Constructeur

		public ParametreSortant(string type, string description)
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

		#region ServicesExternes
		public static List<List<ParametreSortant>> ParametresSortantsMethodesClasses(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeMethodesInterfacesServices = new List<List<string>>();
			List<List<ParametreSortant>> ParametresSortantsInterfacesServices = new List<List<ParametreSortant>>();

			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] + 1; cmp++)
					{
						if ((i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1 && cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]) || (i == InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1 && cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]))
						{
							ListeMethodesInterfacesServices.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeMethodesInterfacesServices[cmp].Add(isbn2.InnerText);

							}
							ParametresSortantsInterfacesServices.Add(ListeAParametresSortants(ListeMethodesInterfacesServices[cmp]));

						}
						if (i == InterfaceService.NomsInterfacesServices(doc, nsmgr).Count  && cmp == Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1])
						{
							ListeMethodesInterfacesServices.Add(new List<string>());
							string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /preceding-sibling:: w:tbl / w:tr /w:tc)]";


							nodeList2 = root.SelectNodes(xpath, nsmgr);

							foreach (XmlNode isbn2 in nodeList2)
							{

								ListeMethodesInterfacesServices[cmp].Add(isbn2.InnerText);

							}
							ParametresSortantsInterfacesServices.Add(ListeAParametresSortants(ListeMethodesInterfacesServices[cmp]));




						}
					}
				}
			}
			return ParametresSortantsInterfacesServices;

		}


		#endregion

		/// <summary>
		/// Fonction qui prend une liste de string et la transforme en liste de parametres sortants
		/// 
		/// </summary>
		/// <param name="liste"></param>
		/// <returns></returns>
		public static List<ParametreSortant> ListeAParametresSortants(List<string> liste)
		{
			List<ParametreSortant> ListeParametresSortants= new List<ParametreSortant>();
			for (int i = 2; i < liste.Count; i = i + 2)
			{
				ListeParametresSortants.Add(new ParametreSortant(liste[i], liste[i + 1]));
			}
			return ListeParametresSortants;
		}



		#endregion
	}
}