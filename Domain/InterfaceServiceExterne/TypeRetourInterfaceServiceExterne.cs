using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Domain.InterfaceServiceExterne
{
	public class TypeRetourInterfaceServiceExterne
	{
		
	
			#region Attributs
			public string Type;
			public string Description;

			#endregion

			#region Constructeur 
			public TypeRetourInterfaceServiceExterne(string type, string description)
			{
				this.Type = type;
				this.Description = description;

			}

			#endregion

			#region Méthodes

			public override string ToString()
			{
				return (Type + " " + Description);

			}

			/// <summary>
			/// Methode qui renvoie la liste des colonnes des types de retour des methodes des services externes
			/// </summary>
			/// <param name="doc"></param>
			/// <param name="nsmgr"></param>
			/// <returns></returns>
			public static List<List<TypeRetourInterfaceServiceExterne>> TypeRetourMethodesInterfaceServiceExterne(XmlDocument doc, XmlNamespaceManager nsmgr)
			{

				XmlNodeList nodeList2;
				XmlElement root = doc.DocumentElement;
				List<List<string>> ListeTypeRetourInterfaceServiceExterne = new List<List<string>>();
				List<List<TypeRetourInterfaceServiceExterne>> TypeRetourInterfaceServiceExterne = new List<List<TypeRetourInterfaceServiceExterne>>();

				for (int i = 1; i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1; i++)
				{

					if (MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1] != 0)
					{

						for (int cmp = 0; cmp < MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1] + 1; cmp++)
						{
							if ((i < InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1 && cmp < MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1]) || (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count + 1 && cmp < MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1]))
							{
								ListeTypeRetourInterfaceServiceExterne.Add(new List<string>());
								string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 2) + "]/preceding-sibling:: w:tbl / w:tr /w:tc)]";


								nodeList2 = root.SelectNodes(xpath, nsmgr);

								foreach (XmlNode isbn2 in nodeList2)
								{

									ListeTypeRetourInterfaceServiceExterne[cmp].Add(isbn2.InnerText);

								}
								TypeRetourInterfaceServiceExterne.Add(ListeATypeRetourInterfaceServiceExterne(ListeTypeRetourInterfaceServiceExterne[cmp]));

							}
							if (i == InterfaceServiceExterne.NomsInterfacesServicesExternes(doc, nsmgr).Count && cmp == MethodeInterfaceServiceExterne.NombreMethodesInterfaceServiceExterne(doc, nsmgr)[i - 1])
							{
								ListeTypeRetourInterfaceServiceExterne.Add(new List<string>());
								string xpath = @"// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading2']][4] /following:: w:p [ w:pPr / w:pStyle [@w:val='Heading3']][" + i + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading4']][" + (cmp + 1) + "]/following:: w:p [ w:pPr / w:pStyle [@w:val='Heading5']][3]/ following-sibling::w:tbl / w:tr /w:tc  [count(. | // w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5] /preceding-sibling:: w:tbl / w:tr /w:tc )= count(// w:p [ w:pPr / w:pStyle [@w:val='Heading1']][5]  /preceding-sibling:: w:tbl / w:tr /w:tc)]";


								nodeList2 = root.SelectNodes(xpath, nsmgr);

								foreach (XmlNode isbn2 in nodeList2)
								{

									ListeTypeRetourInterfaceServiceExterne[cmp].Add(isbn2.InnerText);

								}
							}
							TypeRetourInterfaceServiceExterne.Add(ListeATypeRetourInterfaceServiceExterne(ListeTypeRetourInterfaceServiceExterne[cmp]));


						}

					}
				}
				return TypeRetourInterfaceServiceExterne;

			}






			/// <summary>
			/// Renvoie la liste des types de retour des services externes associés à une liste donnée
			/// </summary>
			/// <returns></returns>
			public static List<TypeRetourInterfaceServiceExterne> ListeATypeRetourInterfaceServiceExterne(List<string> liste)
			{
				List<TypeRetourInterfaceServiceExterne> ListeTypeRetourInterfaceServiceExterne = new List<TypeRetourInterfaceServiceExterne>();
				for (int i = 2; i < liste.Count; i = i + 2)
				{
					ListeTypeRetourInterfaceServiceExterne.Add(new TypeRetourInterfaceServiceExterne(liste[i], liste[i + 1]));
				}
				return ListeTypeRetourInterfaceServiceExterne;
			}
			#endregion
		}
	}

