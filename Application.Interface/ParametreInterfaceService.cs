using System.Collections.Generic;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class ParametreInterfaceService
	{

		#region Attributs
		public string Nom;
		public string Type;
		public string Description;

		#endregion

		#region Constructeur 
		public ParametreInterfaceService(string nom, string type, string description)
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
		public static List<List<ParametreInterfaceService>> ParametresInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<List<string>> ListeParametresInterfacesServices = new List<List<string>>();
			List<List<ParametreInterfaceService>> ParametresInterfacesServices = new List<List<ParametreInterfaceService>>();

			for (int i = 1; i < InterfaceService.NomsInterfacesServices(doc, nsmgr).Count + 1; i++)
			{

				if (Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1] != 0)
				{

					for (int cmp = 0; cmp < Methode.NombreMethodesInterfacesServices(doc, nsmgr)[i - 1]+1; cmp++)
					{

						ListeParametresInterfacesServices.Add(new List<string>());
						string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][3]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


						nodeList2 = root.SelectNodes(xpath, nsmgr);

						foreach (XmlNode isbn2 in nodeList2)
						{
		
								ListeParametresInterfacesServices[cmp].Add(isbn2.InnerText);
							
						}
						ParametresInterfacesServices.Add(ListeAParametresInterfacesServices(ListeParametresInterfacesServices[cmp]));

					}

				}
			}
			return ParametresInterfacesServices;

		}


		#endregion


		/// <summary>
		/// Renvoie la liste des parametres des interfaces de service associés à une liste donnée
		/// </summary>
		/// <returns></returns>
		public static List<ParametreInterfaceService> ListeAParametresInterfacesServices(List<string> liste)
		{
			List<ParametreInterfaceService> ListeParametresInterfacesServices = new List<ParametreInterfaceService>();
			for (int i = 3; i < liste.Count; i = i + 3)
			{
				ListeParametresInterfacesServices.Add(new ParametreInterfaceService(liste[i], liste[i + 1], liste[i + 2]));
			}
			return ListeParametresInterfacesServices;
		}
		#endregion

	}
}