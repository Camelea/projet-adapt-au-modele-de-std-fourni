using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Mappers
{
	class Mapper
	{
		#region Attributs

		public string Nom { get; private set; }
		public string Description { get; private set; }
		public List<MethodeMapper> Methodes { get; private set; }

		#endregion


		#region Constructeur
		public Mapper(string nom, string description,  List<MethodeMapper> methodes)
		{
			this.Nom = nom;
			this.Description = description;
			this.Methodes = methodes;
		}
		public Mapper(string nom, string description)
		{
			this.Nom = nom;
			this.Description = description;

		}


		#endregion


		#region Méthodes 

		public override string ToString()
		{
			return (this.Nom + this.Description);
		}

		/// <summary>
		/// Retourne une liste de noms des mappers présents dans le fichier
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<string> NomsMappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{

			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeNoms = new List<string>();
			string xpath = @"//w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6]/following:: w:p[ w:pPr / w:pStyle [@w:val='Heading2']][2]/following-sibling:: w:p[ w:pPr / w:pStyle [@w:val='Heading3']]
				[count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/ preceding-sibling::w:p [ w:pPr / w:pStyle [@w:val='Heading3']])= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][7]/preceding-sibling::w:p  [ w:pPr / w:pStyle [@w:val='Heading3']])]";

			nodeList2 = root.SelectNodes(xpath, nsmgr);

			foreach (XmlNode isbn2 in nodeList2)
			{
				ListeNoms.Add(isbn2.InnerText);
			}

			return ListeNoms;


		}

		/// <summary>
		/// Fonction qui retourne la liste des descriptions des mappers  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<String> DescriptionsMapper(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			XmlNodeList nodeList2;
			XmlElement root = doc.DocumentElement;
			List<string> ListeDescriptionsMappers = new List<string>();

			for (int i = 1; i < NomsMappers(doc, nsmgr).Count + 1; i++)

			{
				string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][1] / following-sibling::w:p [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/ preceding-sibling::w:p)= count(w:p [ w:pPr / w:pStyle [@w:val='Heading1']][6] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][2] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][2]/preceding-sibling::w:p)]";

				nodeList2 = root.SelectNodes(xpath, nsmgr);

				foreach (XmlNode isbn2 in nodeList2)
				{
					ListeDescriptionsMappers.Add(isbn2.InnerText);
				}

			}
			return ListeDescriptionsMappers;


		}

	


		/// <summary>
		/// Retourne la liste des mappers du fichier  
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static List<Mapper> Mappers(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<Mapper> services = new List<Mapper>();
			List<string> noms = NomsMappers(doc, nsmgr);
			List<string> descriptions = DescriptionsMapper(doc, nsmgr);
			List<List<MethodeMapper>> methodes = MethodeMapper.MethodesMappers(doc, nsmgr);

			for (int i = 1; i < NomsMappers(doc, nsmgr).Count + 1; i++)
			{


				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] != 0)
				{

					services.Add(new Mapper(noms[i - 1], descriptions[i - 1], methodes[i - 1]));
				}

				if (MethodeMapper.NombreMethodesMappers(doc, nsmgr)[i - 1] == 0)
				{

					services.Add(new Mapper(noms[i - 1], descriptions[i - 1]));
				}



			}
			return services;

		}





		#endregion
	}
}
