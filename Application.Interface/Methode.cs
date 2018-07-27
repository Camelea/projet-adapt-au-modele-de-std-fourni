using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{
	public class Methode
	{
		#region Attributs 

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<ParametreInterfaceService> parametreEntrant { get; private set; }
		public List<TypeRetourInterfaceService> parametreSortant { get; private set; }

		#endregion

		#region Constructeur 

		public Methode(string nom, string description, List<ParametreInterfaceService> parametreEntrant, List<TypeRetourInterfaceService> parametreSortant)
		{
			this.Nom = nom;
			this.Description = description;
			this.parametreEntrant = parametreEntrant;
			this.parametreSortant = parametreSortant;

		}

		#endregion

		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne la liste des noms des méthodes des interfaces de service présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMethodesInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfacesServices = new List<string>();

				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ following-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading5']]  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']] )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][2]/preceding-sibling:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']])]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					MethodesInterfacesServices.Add(isbn2.InnerText);
				}
			
			

			return MethodesInterfacesServices;


		}



		/// <summary>
		/// Retourne la liste des descriptions des méthodes des interfaces de service présentes dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> DescriptionsMethodesinterfacesService(XmlDocument doc, XmlNamespaceManager nsmgr,int i )
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> MethodesInterfacesServices = new List<string>();

	
				for (int cmp = 0; cmp < NombreMethodesInterfacesServices(doc, nsmgr,i-1)+1 ; cmp++)
				{
					string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][1]/ following-sibling::w:p  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][3] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][1] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading6']][2]/preceding-sibling:: w:p)]";
					var res=""; 
					nodeList2 = root.SelectNodes(xpath, nsmgr);

					foreach (XmlNode isbn2 in nodeList2)
					{
						res=res+(isbn2.InnerText);
					}
				MethodesInterfacesServices.Add(res);

				}
			
			return MethodesInterfacesServices;


		}

		/// <summary>
		/// Retourne le nombre de methodes de chaque interface de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static int NombreMethodesInterfacesServices(XmlDocument doc, XmlNamespaceManager nsmgr, int i)
		{

			return NomsMethodesInterfacesServices(doc, nsmgr, i).Count;
		}



		/// <summary>
		/// Fonction qui renvoie la liste de toutes les méthodes des interfaces de service 
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Methode> Methodes(XmlDocument doc, XmlNamespaceManager nsmgr,int i)
		{
			List<Methode> methodesInterfacesServices = new List<Methode>();
			

				List<string> descriptionsMethodes = DescriptionsMethodesinterfacesService(doc, nsmgr,i-1);
				List<TypeRetourInterfaceService> parametresSortants = TypeRetourInterfaceService.TypesRetourInterfacesServices(doc, nsmgr,i);
				List<string> nomsMethodes = NomsMethodesInterfacesServices(doc, nsmgr, i-1);
				List<ParametreInterfaceService> parametresEntrants = ParametreInterfaceService.ParametresInterfacesServices(doc, nsmgr,i);
			if (NombreMethodesInterfacesServices(doc, nsmgr,i - 1) != 0)
				{
				

					for (int cmp = 0; cmp < NombreMethodesInterfacesServices(doc, nsmgr,i-1); cmp++)
					{

						methodesInterfacesServices.Add(new Methode(nomsMethodes[cmp], descriptionsMethodes[cmp], parametresEntrants, parametresSortants));


					}
					
				}

			return methodesInterfacesServices;
		}





		#endregion

	}
}
