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
    public class GraphLayoutLoader
    {
        public GraphLayout Layout { get; set; }
        protected ImmutableModel model;


        public GraphLayoutLoader()
        {
            Layout = new GraphLayout("dot");
        }

       

        protected void loadModel(string fileName)
        {
            UmlDescriptor.Initialize();
            var umlSerializer = new WhiteStarUmlSerializer();
            var model = umlSerializer.ReadModelFromFile(fileName, out var diagnostics);

            if (this.model != null && this.model.Name.Equals(model.Name))
            {

                return;
            }
            this.model = model;
        }

        protected void AddClasses(IEnumerable<Class> classes)
        {

            foreach (var cls in classes)
            {
                if (cls.MMetaClass.Name == "Class" && cls.MParent.MName == "Logical View")
                {
                    var n = Layout.AddNode(cls);
                }

            }
        }
        protected void AddInterfaces(IEnumerable<Interface> interfaces)
        {
            foreach (var interf in interfaces)
            {
                if (interf.MMetaClass.Name == "Interface")
                {
                    var n = Layout.AddNode(interf);
                }

            }
        }

        protected void AddEnumerations(IEnumerable<Enumeration> enums)
        {
            foreach (var enu in enums)
            {
                var n = Layout.AddNode(enu);
            }
        }
        protected void AddUseCases(IEnumerable<UseCase> useCases)
        {
            foreach (var uc in useCases)
            {

                Layout.AddNode(uc);

            }
        }
        protected void AddActors(IEnumerable<Actor> actors)
        {
            foreach (var ac in actors)
            {
                Layout.AddNode(ac);
            }
        }
        protected void AddGeneralizations(IEnumerable<Generalization> generalizations)
        {
            foreach (var gen in generalizations)
            {

                var allnodes = Layout.AllNodes.ToList();
                NodeLayout specNL = null;
                NodeLayout genNL = null;
                foreach (var n in allnodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, gen.Specific.Name)) specNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, gen.General.Name)) genNL = Layout.FindNodeLayout(namedNode);

                }
                //if (specObject == null) { Layout.AddNode(gen.Specific.Name); specObject = Layout.FindNodeLayout(gen.Specific.Name); }
                //if (genObject == null) { Layout.AddNode(gen.General.Name); genObject = Layout.FindNodeLayout(gen.General.Name); }
                if (specNL != null && genNL != null)
                {
                    var e = Layout.AddEdge(specNL.NodeObject, genNL.NodeObject, specNL.NodeObject.ToString() + "-|>" + genNL.NodeObject.ToString());

                }
            }

        }

        protected void AddInterfaceRealizations(IEnumerable<InterfaceRealization> interfaceRealizations)
        {
            foreach (var intrf in interfaceRealizations)
            {
                var allNodes = Layout.AllNodes.ToList();
                Layout.FindNodeLayout(intrf.Supplier.FirstOrDefault().Name);
                NodeLayout clientNL = null;
                NodeLayout supplierNL = null;

                foreach (var n in allNodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, intrf.Client.FirstOrDefault().Name)) clientNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, intrf.Supplier.FirstOrDefault().Name)) supplierNL = Layout.FindNodeLayout(namedNode);
                }

                if (clientNL != null && supplierNL != null)
                {
                    var e = Layout.AddEdge(clientNL.NodeObject, supplierNL.NodeObject, clientNL.NodeObject.ToString() + "--|>" + supplierNL.NodeObject.ToString());
                }
            }

        }

        protected void AddDependecies(IEnumerable<Dependency> dependencies)
        {
            foreach (var dep in dependencies)
            {
                var allNodes = Layout.AllNodes.ToList();

                NodeLayout clientNL = null;
                NodeLayout supplierNL = null;

                foreach (var n in allNodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, dep.Client.FirstOrDefault().Name)) clientNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, dep.Supplier.FirstOrDefault().Name)) supplierNL = Layout.FindNodeLayout(namedNode);
                }

                if (clientNL != null && supplierNL != null)
                {
                    var e = Layout.AddEdge(clientNL.NodeObject, supplierNL.NodeObject, clientNL.NodeObject.ToString() + "-->" + supplierNL.NodeObject.ToString());
                }
            }
        }

        protected void AddAssociations(IEnumerable<Association> associations)
        {

            foreach (var aso in associations)
            {

                var allNodes = Layout.AllNodes.ToList();
                NodeLayout memberEndNL = null;
                NodeLayout memberEnd1NL = null;

                foreach (var n in allNodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, aso.MemberEnd[0].Type.Name)) memberEndNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, aso.MemberEnd[1].Type.Name)) memberEnd1NL = Layout.FindNodeLayout(namedNode);
                }

                if (memberEndNL != null && memberEnd1NL != null)
                {

                    var e = Layout.AddEdge(memberEndNL.NodeObject, memberEnd1NL.NodeObject, memberEndNL.NodeObject.ToString() + "-" + memberEnd1NL.NodeObject.ToString());

                }


            }
        }

        protected void AddIncludes(IEnumerable<Include> includes)
        {
            foreach (var inc in includes)
            {
                var allNodes = Layout.AllNodes.ToList();

                NodeLayout includingNL = null;
                NodeLayout additionNL = null;

                foreach (var n in allNodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, inc.IncludingCase.Name)) includingNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, inc.Addition.Name)) additionNL = Layout.FindNodeLayout(namedNode);
                }

                if (includingNL != null && additionNL != null)
                {
                    var e = Layout.AddEdge(additionNL.NodeObject, includingNL.NodeObject, additionNL.NodeObject.ToString() + "--|>" + includingNL.NodeObject.ToString());
                }
            }

        }

        protected void AddExtends(IEnumerable<Extend> extends)
        {
            foreach (var ext in extends) 
            {
                var allNodes = Layout.AllNodes.ToList();

                NodeLayout extendCaseNL = null;
                NodeLayout extensionNL = null;

                foreach (var n in allNodes)
                {
                    var namedNode = (MetaDslx.Languages.Uml.Model.NamedElement)n.NodeObject;
                    if (string.Equals(namedNode.Name, ext.ExtendedCase.Name)) extendCaseNL = Layout.FindNodeLayout(namedNode);
                    else if (string.Equals(namedNode.Name, ext.Extension.Name)) extensionNL = Layout.FindNodeLayout(namedNode);
                }

                if (extendCaseNL != null && extensionNL != null)
                {
                    var e = Layout.AddEdge(extensionNL.NodeObject, extendCaseNL.NodeObject, extensionNL.NodeObject.ToString() + "--|>" + extendCaseNL.NodeObject.ToString());
                }
            }
        }
    }
}
