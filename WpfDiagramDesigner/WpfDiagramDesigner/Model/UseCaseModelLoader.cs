using MetaDslx.GraphViz;
using MetaDslx.Languages.Uml.Model;
using MetaDslx.Languages.Uml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfDiagramDesigner.Model
{
    public class UseCaseModelLoader : GraphLayoutLoader
    {
 

        public UseCaseModelLoader() : base() { }


        public void LoadLayout(string fileName)
        {
            this.loadModel(fileName);
            this.AddUseCases(model.Objects.OfType<UseCase>());
            this.AddActors(model.Objects.OfType<Actor>());
            this.AddGeneralizations(model.Objects.OfType<Generalization>());
            this.AddDependecies(model.Objects.OfType<Dependency>());
            this.AddAssociations(model.Objects.OfType<Association>());
            this.AddIncludes(model.Objects.OfType<Include>());
            this.AddExtends(model.Objects.OfType<Extend>());

            Layout.NodeSeparation = 10;
            Layout.RankSeparation = 50;
            Layout.EdgeLength = 30;
            Layout.NodeMargin = 20;
            Layout.ComputeLayout();
        }
    }
}
