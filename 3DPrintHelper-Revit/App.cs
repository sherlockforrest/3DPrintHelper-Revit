#region Namespaces
using System;
using System.Collections.Generic;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Reflection;
using System.Windows.Media.Imaging;
#endregion

namespace ThreeDPrintHelper
{
    class App : IExternalApplication
    {
        //Esse método deve obrigatoriamente ser public
        //Método invocado quando o addin é iniciado. Aqui que precisamos configurar nossa interface gráfica
        public Result OnStartup(UIControlledApplication revitAPP)
        {
            try
            {
                //Criando o painel que conterá o novo botão.
                RibbonPanel painel = revitAPP.CreateRibbonPanel("Impressão 3D");

                //Criando o botão para inserir na interface do Revit.
                string caminhoDLL = Assembly.GetExecutingAssembly().Location;
                PushButtonData configuracaoBotao = new PushButtonData("3D Print Helper", "3D Print Helper",
                                                          caminhoDLL, "ThreeDPrintHelper.IniciarInterface");

                PushButton botao = painel.AddItem(configuracaoBotao) as PushButton;
                botao.ToolTip = "Clique aqui para iniciar o 3D Print Helper.";
                Uri URIimagem = new Uri(@"C:\Users\andre.KEEPCAD\Documents\Visual Studio 2017\Projects\3DPrintHelper-Revit\3DPrintHelper-Revit\Resources\icon-32x32.png");
                BitmapImage imagemIcone = new BitmapImage(URIimagem);

                botao.LargeImage = imagemIcone;

                return Result.Succeeded;
            }

            catch (Exception e)
            {
                return Result.Failed;
            }

        }

        //Esse método deve obrigatoriamente ser public
        public Result OnShutdown(UIControlledApplication revitAPP)
        {
            return Result.Succeeded;
        }
    }

        [Transaction(TransactionMode.Manual)]
        public class IniciarInterface : IExternalCommand
        {
            public Result Execute(ExternalCommandData revit,ref string message, ElementSet elements)
            {
                TaskDialog.Show("Revit", "Hello André!");
                return Autodesk.Revit.UI.Result.Succeeded;
            }

        }
    }

