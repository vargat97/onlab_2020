using MetaDslx.GraphViz;
using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization;
using MetaDslx.Modeling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfDiagramDesigner.Model
{
    public class LogicalViewModelLoader : GraphLayoutLoader
    {

        public LogicalViewModelLoader() : base() { }

        public void LoadLayout(string fileName)
        {


            this.loadModel(fileName);

            this.AddClasses(model.Objects.OfType<Class>());

            this.AddInterfaces(model.Objects.OfType<Interface>());

            this.AddEnumerations(model.Objects.OfType<Enumeration>());

            this.AddGeneralizations(model.Objects.OfType<Generalization>());

            this.AddInterfaceRealizations(model.Objects.OfType<InterfaceRealization>());

            this.AddDependecies(model.Objects.OfType<Dependency>());

            this.AddAssociations(model.Objects.OfType<Association>());
            
            Layout.NodeSeparation = 10;
            Layout.RankSeparation = 50;
            Layout.EdgeLength = 30;
            Layout.NodeMargin = 20;
            Layout.ComputeLayout();
        }
        
    }
}
