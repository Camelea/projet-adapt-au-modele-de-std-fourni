using ConsoleApp4.Domain.CommonType.Services_Externes;
using ConsoleApp4.Structure.Application.Interface.ObjetPresentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleApp4.Application.Interface
{/// <summary>
/// Permet de récupérer les objets de presentation 
/// </summary>
	class ObjetPresentation
	{
		#region Attributs 
		public List<MethodeObjetPresentation> Methodes;


		#endregion

		#region Constructeur

		public ObjetPresentation(List<MethodeObjetPresentation> methodes)
		{
			this.Methodes = methodes;
		}

		#endregion

		#region Methodes

		public override string ToString(){
			StringBuilder methodes = new StringBuilder();
			foreach ( MethodeObjetPresentation methode in this.Methodes) {
				if (methode == this.Methodes.First())
				{
					methodes.Append(methode.ToString("[DataContract]") + "\r\n");

				}
				else {
					methodes.Append(methode.ToString("[DataMember]") + "\r\n");
				}
			}
			var res = "{" + methodes + "}";
			return res;
		}

		/// <summary>
		/// Fonction qui retourne la listes des objets de presentation   
		/// </summary>
		/// <param name="doc"></param>
		/// <param name="nsmgr"></param>
		/// <returns></returns>
		public static ObjetPresentation ObjetsPresentation(XmlDocument doc, XmlNamespaceManager nsmgr)
		{
			List<MethodeObjetPresentation> methodes = MethodeObjetPresentation.MethodesObjetsPresentation(doc, nsmgr);

			return (new ObjetPresentation(methodes));

		}
		#endregion
	}
}
