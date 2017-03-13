using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace WebServiceASP
{
    ///// <summary>
    ///// Description résumée de WebService1
    ///// </summary>
    //[WebService(Namespace = "http://tempuri.org/")]
    //[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    //[System.ComponentModel.ToolboxItem(false)]
    //// Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    //// [System.Web.Script.Services.ScriptService]

    /// <summary>
    /// Web service LemonWay.WebService1 contient 2 méthodes, 
    ///     1 pour le calcule de fibonacci de 1 a 100 
    ///     et 1 pour la convertion de XML vers Json
    /// </summary>
    [WebService(Namespace = "http://cagnet.name/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Pour autoriser l'appel de ce service Web depuis un script à l'aide d'ASP.NET AJAX, supprimez les marques de commentaire de la ligne suivante. 
    [System.Web.Script.Services.ScriptService]//Pour fournir le résultat en Json
    public class WebService1 : System.Web.Services.WebService
    {
        /// <summary>
        /// Crée une inatance de CoreLib qui contient toute les méthodes métier
        /// </summary>
        LemonWay.CoreLib intance = new LemonWay.CoreLib();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        #region Fibonacci

        /// <summary>
        /// Méthode permattant de connaitre la valeur de Fibonacci pour les valeur de 1 à 100
        /// </summary>
        /// <param name="n">Valeur de fibonacci</param>
        /// <returns>Résutat du calcule de Fibonacci si n compris entre 0 et 101 sinon return -1</returns>
        [WebMethod]
        //La valeur de retour a été changée car dans l'ennoncé il est demandé un int hors au dela de 50 la valeur ne tient plus dans un int
        public double Fibonacci(int n)
        {
            return this.intance.Fibonacci(n);
        }
        #endregion

        #region XmlToJson
        /// <summary>
        /// Méthode servant à convertir un block Xml en text Json
        /// </summary>
        /// <param name="xml">text Xml</param>
        /// <returns>text Json</returns>
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]    // Permet de formatter le résultat en Json
        public string XmlToJson(string xml)
        {
            return this.intance.XmlToJson(xml);
        }
        #endregion
    }

}

